using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Corp.Cencosud.Supermercados.Sua_Inventario.Dal;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz
{
    public class PosicionesBiz : BaseBiz, IPosicionesBiz
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
    }
}
