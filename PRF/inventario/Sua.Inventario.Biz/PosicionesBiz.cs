﻿using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Corp.Cencosud.Supermercados.Sua_Inventario.Dal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz
{
    public partial class PosicionesBiz : BaseBiz, IPosicionesBiz
    {
        protected IUOW_CDsDB _unitOfWorkOfCDsDB { get; }

        public PosicionesBiz(IUOW_CDsDB unitOfWorkOfCDsDB) : base(unitOfWorkOfCDsDB)
        {
            _unitOfWorkOfCDsDB = unitOfWorkOfCDsDB;
        }

        public List<Posicion> GetxDocumentoId(int idDoc)
        {
            return _unitOfWorkOfCDsDB.INV_dPosicionesRepository.Get(x => x.idDocumento == idDoc).ToList().ToModel();
        }

        public List<Posicion> GetAllxFiltros(string pasillo, double? columna, double? nivel,int idDoc)
        {
            return _unitOfWorkOfCDsDB.INV_dPosicionesRepository.Get(x => x.idDocumento == idDoc && 
                                                                         (string.IsNullOrEmpty(pasillo) || (x.pasillo == pasillo)) &&
                                                                         (columna == null || (x.columna == columna)) &&
                                                                         (nivel == null || (x.nivel == nivel))).ToList().ToModel();
        }

        public void ImpactarSega(int idDoc)
        {
            _unitOfWorkOfCDsDB.sp_ImpactarSega(idDoc);
        }

        public string UpdatePosicion(PosicionUpdate posicion)
        {
            posicion.usuario = "Mobile";
            var sArticulo = posicion.articulo.Split('-');
            if(sArticulo.Any())
            {
                posicion.codigoArticulo = sArticulo[0];
            }
            else
            {
                posicion.codigoArticulo = posicion.digito.Equals(".") ? posicion.codigoArticulo = "(-.-)" : posicion.articulo;
            }
            
            if (posicion.tipoInventario.ToUpper() == TipoInventarios.Camadas.ToString().ToUpper())
            {
                posicion.bultosInv = posicion.camadas + posicion.cajasSueltas;
                posicion.cajasSueltas = posicion.cajas;
                posicion.hxPInv = (int)posicion.camadas;
            }
            else
            {
                posicion.bultosInv = posicion.camadas;
                posicion.cajasSueltas = 0;
                posicion.hxPInv = 0;
            }
            try
            {
                var resUpdate = _unitOfWorkOfCDsDB.Sp_Update_Posicion(posicion.id, posicion.usuario, posicion.digito, posicion.bultosInv, posicion.usuarioinventario,
                    posicion.hxPInv, posicion.cajasSueltas, posicion.observaciones, posicion.codigoArticulo);
            
                if ( resUpdate && posicion.registroCargado == posicion.registroTotal)
                {
                    return _unitOfWorkOfCDsDB.sp_ControlAutomatico(posicion.idDocumento);
                }
                return "Ok";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public bool ResetPosicion(int idDoc)
        {
            return _unitOfWorkOfCDsDB.sp_ResetDocumento(idDoc);
        }
    }
}
