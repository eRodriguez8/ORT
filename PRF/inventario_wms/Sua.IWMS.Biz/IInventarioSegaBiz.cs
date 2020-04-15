using System;
using System.Collections.Generic;
using Corp.Cencosud.Supermercados.Sua.IWMS.Ent;

namespace Corp.Cencosud.Supermercados.Corp.Cencosud.Supermercados.Sua.IWMS.Biz
{
    public interface IInventarioSegaBiz
    {
        bool ReiniciarDocumento(int idDoc);
        DatosDocumento GetPosicionesxIdDoc(int idDoc);
        InventarioSegaEnt PrimerRegistroDisponible(int idDoc);
        bool Update(InventarioUpdate data);
        Documento GetDocumento(string legajo);
        string ControlAutomatico(int idDocumento);
    }
}
