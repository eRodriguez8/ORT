using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using System;
using System.Collections.Generic;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces
{
    public interface IPosicionesBiz
    {
        List<Posicion> GetxDocumentoId(int idDoc);
        List<Posicion> GetAllxFiltros(string pasillo, double? columna, double? nivel,int idDoc);
        void ImpactarSega(int idDoc);
        string UpdatePosicion(PosicionUpdate posicion);
    }
}
