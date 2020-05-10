using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Corp.Cencosud.Supermercados.Sua_Inventario.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using DocumentFormat.OpenXml.Wordprocessing;
using log4net.Repository.Hierarchy;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz
{
    public class DocumentoBiz : BaseBiz, IDocumentoBiz
    {
        protected IUOW_CDsDB _unitOfWorkOfCDsDB { get; }

        public DocumentoBiz(IUOW_CDsDB unitOfWorkOfCDsDB) : base(unitOfWorkOfCDsDB)
        {
            _unitOfWorkOfCDsDB = unitOfWorkOfCDsDB;
        }

        public List<Documento> GetByIdInventario(int idInventario)
        {
            try
            {
                var documentos = _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Get(x => x.idInventario == idInventario);
                return documentos != null ? documentos.ToList().ToModel() : new List<Documento>();
            }
            catch (Exception ex)
            {
                var a = ex;
                return new List<Documento>();
            }
        }

        private INV_dDocumentos Get(int id)
        {
            return _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Get(x => x.id == id)
            .SingleOrDefault();
        }

        public Documento GetById(int id)
        {
            return Get(id).ToModel();
        }

        public List<Documento> InsertBulk(List<Documento> documentos)
        {
            var documentosEntities = documentos.ToEntity();
            _unitOfWorkOfCDsDB.INV_dDocumentosRepository.BulkInsert(documentosEntities);
            _unitOfWorkOfCDsDB.Save();

            return documentosEntities.ToModel();
        }

        public void DeleteById(int id)
        {
            var documento = _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Get(x => x.id == id, true).SingleOrDefault();
            _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Delete(documento);
            _unitOfWorkOfCDsDB.Save();
        }

        public void CancelarDocumentosxIdInventario(int idInventario)
        {
            var docs = GetByIdInventario(idInventario);
            if(docs.Any()){
                docs = docs.Where(x => x.estado == EstadoDocumento.Creado ||
                    x.estado == EstadoDocumento.Asignado).ToList();
            }
            foreach (Documento doc in docs)
            {
                doc.estado = EstadoDocumento.Cancelado;
                _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Update(doc.ToEntity());
            }
            _unitOfWorkOfCDsDB.Save();
        }
        public string CancelarDocumentoxId(int idDoc)
        {
            var doc = Get(idDoc);
            
            doc.Estado = (int)EstadoDocumento.Cancelado;
            doc.LegajoAsignado = "";
            _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Update(doc);

            _unitOfWorkOfCDsDB.Save();

            return "OK";
        }

        public List<Documento> GetAll(int idInventario)
        {
            var documentos = _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Get(x => x.idInventario == idInventario,
                includeProperties: "INV_dPosiciones").ToList().ToModel();
            calculateData(documentos);
            return documentos;
        }

        public List<Documento> GetAllxFiltros(string pasillo, double? columna, double? nivel, string documento, int? fase, int idInventario, int? estado, string legajo)
        {
            var documentos = _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Get(x => x.idInventario == idInventario &&
                        (string.IsNullOrEmpty(pasillo) || (x.INV_dPosiciones.Where(y => y.pasillo == pasillo)
                            .Select(m => m.idDocumento).Contains(x.id))) &&
                        (columna == null || (x.INV_dPosiciones.Where(y => y.columna == columna)
                            .Select(m => m.idDocumento)).Contains(x.id)) &&
                        (nivel == null || (x.INV_dPosiciones.Where(y => y.nivel == nivel)
                            .Select(m => m.idDocumento)).Contains(x.id)) &&
                        (string.IsNullOrEmpty(documento) || (x.Documento == documento)) &&
                        (fase == null || (x.Fase == fase)) &&
                         (estado == null || (x.Estado == estado)) &&
                         (string.IsNullOrEmpty(legajo) || (x.LegajoAsignado == legajo))
                        , includeProperties: "INV_dPosiciones").ToList().ToModel();
            calculateData(documentos);
            return documentos;
        }

        private void calculateData(List<Documento> documentos)
        {
            foreach (Documento doc in documentos)
            {
                doc.lTotales = doc.posiciones.Count;
                doc.lContadas = doc.posiciones.Where(x => !string.IsNullOrEmpty(x.estado)).ToList().Count;
                doc.porcentaje = doc.lTotales.Value > 0 ? (doc.lContadas * 100) / doc.lTotales : 0;
                var Min = doc.posiciones.Where(x => x.fechaact != null).Select(x => x.fechaact).Min();
                var Max = doc.posiciones.Where(x => x.fechaact != null).Select(x => x.fechaact).Max();
                doc.pLectura = Min != null ? Convert.ToDateTime(Min) : new DateTime?();
                doc.uLectura = Max != null ? Convert.ToDateTime(Max) : new DateTime?();
                doc.tOperacionMin = Math.Round((doc.uLectura != null && doc.pLectura != null) ? ((TimeSpan)(doc.uLectura - doc.pLectura)).TotalMinutes : 0, 2);
                doc.tUltimaLectura = Math.Round((doc.uLectura != null) ? ((TimeSpan)(DateTime.Now - doc.uLectura)).TotalMinutes : 0, 2);
                if (doc.lTotales.Value > 0)
                {
                    doc.promLineasxMin = Math.Round((double)((doc.lContadas == 0) ? 0 : (((doc.tOperacionMin > 0) ? doc.tOperacionMin : 1) / doc.lContadas)), 2);
                }
                else
                {
                    doc.promLineasxMin = 0;
                }
                doc.promLineasDescuadre = doc.lTotales.Value > 0 ? (doc.posiciones.Where(x => x.estado != "Sin Conteo" && x.estado != "Sin Descuadre").ToList().Count() * 100) / doc.lTotales : 0;
                doc.documentoPadre = doc.idDocumentoPadre != null ? documentos.FirstOrDefault(x => x.id == doc.id) : null;

                doc.posiciones = new List<Posicion>();
            }
        }

        public string Asignar(int idDoc, string legajo)
        {
            string response = "";
            var doc = Get(idDoc);

            var documentos = _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Get(x => x.idInventario == doc.idInventario).ToList().ToModel();

            var asignados = _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Get(x => x.LegajoAsignado == legajo && x.Estado == (int)EstadoDocumento.Asignado).Count();

            if (asignados <= 0 && doc.Estado != (int)EstadoDocumento.Cancelado && doc.Estado != (int)EstadoDocumento.Finalizado)
            {
                doc.LegajoAsignado = legajo;
                doc.UltimoLegajoAsignado = legajo;
                doc.Estado = (int)EstadoDocumento.Asignado;
                _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Update(doc);
                _unitOfWorkOfCDsDB.Save();

                response = "OK";
            }
            else
            {
                response = "Legajo ya asignado";
            }

            return response;
        }

        public string Desasignar(int idDoc)
        {
            string response = "";
            var doc = Get(idDoc);

            if (doc.Estado != (int)EstadoDocumento.Cancelado && doc.Estado != (int)EstadoDocumento.Finalizado)
            {
                doc.LegajoAsignado = "";
                doc.Estado = (int)EstadoDocumento.Creado;
                _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Update(doc);
                _unitOfWorkOfCDsDB.Save();

                response = "OK";
            }
            else
            {
                response = "Documento Finalizado o Cancelado.";
            }

            return response;
        }

        public string ControlForzado(int idDoc)
        {
            try
            {
                return _unitOfWorkOfCDsDB.Sp_ControlForzado(idDoc);
            }
            catch (Exception)
            {
                return "error";
            }
        }
        public string UpdateEstadoSega(int idDoc)
        {
            var doc = Get(idDoc);
            _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Update(doc);
            _unitOfWorkOfCDsDB.Save();

            return "OK";
        }

        public Documento GetByLegajo(string legajo)
        {
            var documento = _unitOfWorkOfCDsDB.INV_dDocumentosRepository.Get(x => x.LegajoAsignado == legajo && x.Estado == (int)Estado.Iniciado,
                includeProperties: "INV_dPosiciones").SingleOrDefault();
            if (documento == null)
                return null;
            var docModel = documento.ToModel();
            docModel.lTotales = docModel.posiciones.Where(x => String.IsNullOrEmpty(x.usuario)).Count();
            docModel.lContadas = docModel.posiciones.Where(x => !String.IsNullOrEmpty(x.usuario)).Count();
            return docModel;
        }
    }
}