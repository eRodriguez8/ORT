
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Exceptions;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Helpers;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Corp.Cencosud.Supermercados.Sua_Inventario.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Transactions;
using DocumentFormat.OpenXml.Spreadsheet;
using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz
{
    public class InventarioBiz : BaseBiz, IInventarioBiz
    {
        private readonly ExcelHelper _helper = new ExcelHelper();
        private readonly DocumentoBiz _docBiz;

        protected IUOW_CDsDB _unitOfWorkOfCDsDB { get; }

        public InventarioBiz(IUOW_CDsDB unitOfWorkOfCDsDB) : base(unitOfWorkOfCDsDB)
        {
            _unitOfWorkOfCDsDB = unitOfWorkOfCDsDB;
            _docBiz = new DocumentoBiz(unitOfWorkOfCDsDB);
        }

        public string ImportarExcel(byte[] file, int idInventario, bool primeraFilaCabecera)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var detalle = _helper.ConvertirExcelADataSet(file, primeraFilaCabecera);
                var ts = DateTime.Now;
                string usuario = "";

                DataTable tabla = detalle.Tables[0];
                var filasUsadas = tabla.Rows.Cast<DataRow>()
                                    .Where(row => row.ItemArray.Any(field => !(field is DBNull || (field != null && string.IsNullOrWhiteSpace(field.ToString())))))
                                    .Select(dr => Helper.ToObject<Posicion>(dr))
                                    .ToList();

                var documentList = filasUsadas.Select(x => x.documento).Distinct().ToList().Select(y => new Documento()
                {
                    documento = y,
                    legajoAsignado = string.Empty,
                    estado = EstadoDocumento.Creado,
                    fecha = ts,
                    usuario = usuario,
                    idInventario = idInventario,
                    fase = Fase.Inventario,
                    impactadoSega = false
                }).ToList();

                var documentos = _docBiz.InsertBulk(documentList);

                filasUsadas.ForEach(x =>
                {
                    x.ts = ts;
                    x.usuario = usuario;
                    x.idDocumento = documentos.Where(y => y.documento == x.documento).FirstOrDefault().id;
                    x.ean13 = x.dun14;
                    x.tipoinventario = x.metodo;
                    x.fecha_hora_recepcion = x.fecha_hora_recepcion == string.Empty ? null : x.fecha_hora_recepcion;
                    x.vencimiento = x.vencimiento == string.Empty ? null : x.vencimiento;
                    if (x.etiqueta == null)
                    {
                        x.etiqueta = string.Empty;
                    }
                });

                var fs = filasUsadas.ToEntity();

                _unitOfWorkOfCDsDB.INV_dPosicionesRepository.BulkInsert(fs);

                _unitOfWorkOfCDsDB.Save();
                scope.Complete();
            }

            return "Metodo importar realizado con éxito";
        }

        public Entities.Inventario Create(Entities.Inventario inv)
        {
            inv.usuario = Security.GetUser();
            inv.fechaCreacion = DateTime.Now;

            if (GetxCC(inv.cc) != null)
            {
                throw new ConflictException();
            }

            _unitOfWorkOfCDsDB.INV_dInventarioRepository.Insert(inv.ToEntity());
            _unitOfWorkOfCDsDB.Save();

            return GetxCC(inv.cc);
        }

        public Entities.Inventario GetxCC(short cc)
        {
            try
            {
                var inv = _unitOfWorkOfCDsDB.INV_dInventarioRepository.Get(x => x.cc == cc && x.Estado == (short)Estado.Iniciado)
                    .FirstOrDefault();
                return inv.ToModel();
            }
            catch
            {
                throw new NotFoundException();
            }
        }

        public Entities.Inventario GetxId(int id)
        {
            try
            {
                var inv = _unitOfWorkOfCDsDB.INV_dInventarioRepository.Get(x => x.id == id)
                    .FirstOrDefault();
                return inv.ToModel();
            }
            catch
            {
                throw new NotFoundException();
            }
        }

        public List<Entities.Inventario> GetxFechas_CC(string desde, string hasta, short cc)
        {
            try
            {
                var fechaD = Convert.ToDateTime(desde);
                var fechaH = Convert.ToDateTime(hasta);

                var inv = _unitOfWorkOfCDsDB.INV_dInventarioRepository.
                    Get(x => x.cc == cc && x.FechaCreacion >= fechaD &&
                    x.FechaCreacion <= fechaH)
                    .ToList().ToModel();

                inv.Where(x => x.estado == Estado.Iniciado).ToList().ForEach(x =>
                    x.acciones.Add(""));

                return inv;
            }
            catch (Exception)
            {
                throw new NotFoundException();
            }
        }

        public string Cancelar(int id)
        {
            var inventario = _unitOfWorkOfCDsDB.INV_dInventarioRepository.Get(x => x.id == id)
                    .FirstOrDefault();
            _docBiz.CancelarDocumentosxIdInventario(id);

            inventario.Estado = (int)Estado.Cancelado;
            inventario.FechaFinalizacion = DateTime.Now;
            _unitOfWorkOfCDsDB.INV_dInventarioRepository.Update(inventario);
            _unitOfWorkOfCDsDB.Save();
            return "OK";
        }

        public List<INV_EstadoActual_Result> GetReporteInventario(int id, int? fase)
        {
             return _unitOfWorkOfCDsDB.Sp_ReporteInventario(id, fase);
        }
    }
}