using System;
using System.Linq;
using log4net;
using Corp.Cencosud.Supermercados.Sua.IWMS.Dal;
using Corp.Cencosud.Supermercados.Sua.IWMS.Ent;

namespace Corp.Cencosud.Supermercados.Corp.Cencosud.Supermercados.Sua.IWMS.Biz
{
    public class InventarioSegaBiz : IInventarioSegaBiz
    {
        private readonly IContextCDsEntities _contextDb;

        private static readonly ILog Logger = LogManager.GetLogger(typeof(InventarioSegaBiz));

        protected IContextCDsEntities GetContext()
        {
            return _contextDb ?? new CDsEntities();
        }

        public InventarioSegaBiz()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public InventarioSegaBiz(IContextCDsEntities contextDb)
        {
            _contextDb = contextDb;
        }

        public bool ReiniciarDocumento(int idDoc)
        {
            try
            {
                using (var context = GetContext())
                {
                    return context.INV_dPosiciones_ReiniciarDocumento(idDoc).FirstOrDefault().Value;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public DatosDocumento GetPosicionesxIdDoc(int idDoc)
        {
            try
            {
                using (var context = GetContext())
                {
                    return context.INV_dPosiciones_SelectByDocumento(idDoc).Select(x => new DatosDocumento
                    {
                        TotalRegistros = x.TotalRegistros,
                        Escritos = x.Escritos,
                        PrimerId = x.PrimerId,
                        PrimerIdDisponible = x.PrimerIdDisponible
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public InventarioSegaEnt PrimerRegistroDisponible (int idDoc)
        {
            try
            {
                using (var context = GetContext())
                {
                    return context.INV_dPosiciones_SelectDisponible(idDoc).Select(x => new InventarioSegaEnt
                    {
                        Id = x.id,
                        Sector = x.sector,
                        PASILLO = x.pasillo,
                        COLUMNA = x.columna,
                        NIVEL = x.nivel,
                        COMPART = x.compart,
                        ETIQUETA = x.etiqueta,
                        ean13 = x.ean13 ?? "",
                        DESCRIPCION = x.descripcion,
                        Proveedor = x.proveedor,
                        ID_ORDEN_COMPRA = x.id_orden_compra,
                        Fecha_hora_recepcion = x.fecha_hora_recepcion,
                        Vencimiento = x.vencimiento,
                        VidaUtil = x.vidautil,
                        DiasVencer = x.diasvencer,
                        CxH = x.cxh,
                        HxP = x.hxp,
                        UxB = x.uxb,
                        UxPack = x.uxpack,
                        Bultos = x.bultos,
                        Packs = x.packs,
                        Unidades = x.unidades,
                        Recepcionista = x.recepcionista,
                        Almacenador = x.almacenador,
                        EstadoCalidad = x.estadocalidad,
                        CARA = x.cara,
                        Usuario = x.usuario,
                        Digito = x.digito,
                        BultosInv = x.bultosinv,
                        Ts = x.ts,
                        FechaAct = x.fechaact,
                        UsuarioInventario = x.usuarioinventario,
                        TipoInventario = x.tipoinventario != null ? (x.tipoinventario.ToUpper() == TipoInventarios.Camadas.ToString().ToUpper() ?
                                        TipoInventarios.Camadas : TipoInventarios.Bultos) : TipoInventarios.Vacio,
                        HxPInv = x.hxpinv,
                        CajasSueltasInv = x.cajassueltasinv,
                        Estado = x.estado,
                        Observaciones = x.observaciones,
                        CodigoArticulo = x.codigoarticulo
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public bool Update(InventarioUpdate data)
        {
            try
            {
                using (var context = GetContext())
                {
                    return context.INV_dPosiciones_Update(data.id, data.usuario, data.digito, data.bultosInv,
                        data.usuarioInventario, data.hxPInv, data.cajasSueltasInv, data.observaciones, data.codigoArticulo).FirstOrDefault().Value;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public Documento GetDocumento(string legajo)
        {
            try
            {
                using (var context = GetContext())
                {
                    return context.INV_dDocumentos_SelectxLegajo(legajo).Select(x => new Documento
                    {
                        idDoc = x.id,
                        documento = x.Documento
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public string ControlAutomatico(int idDocumento)
        {
            try
            {
                using (var context = GetContext())
                {
                    return context.INV_dPosiciones_ValidarYCrearControles(idDocumento).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}
