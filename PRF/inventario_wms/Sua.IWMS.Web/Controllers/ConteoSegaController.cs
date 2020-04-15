using System;
using System.Web.Mvc;
using Corp.Cencosud.Supermercados.Sua.IWMS.Web.Models.ConteoSega;
using log4net;
using Corp.Cencosud.Supermercados.Corp.Cencosud.Supermercados.Sua.IWMS.Web.Models;
using Corp.Cencosud.Supermercados.Sua.IWMS.Ent;
using Corp.Cencosud.Supermercados.Sua.IWMS.Web.Models;
using Newtonsoft.Json;
using Corp.Cencosud.Supermercados.Corp.Cencosud.Supermercados.Sua.IWMS.Biz;
using System.Configuration;

namespace Corp.Cencosud.Supermercados.Sua.IWMS.Web.Controllers
{
    public class ConteoSegaController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ConteoSegaController));
        public IInventarioSegaBiz _biz;
        public ConteoSegaViewModel conteo;

        public ConteoSegaController()
        {
            _biz = new InventarioSegaBiz();
            conteo = new ConteoSegaViewModel();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public void GetCookieUser()
        {
            try
            {
                var cookie = Request.Cookies["user"]["usuario"];

                var user = JsonConvert.DeserializeObject<UsuarioVM>(cookie);

                Session["Usuario"] = user;

                true.Write(ClientResponseType.JSON);
            }
            catch (Exception Exception)
            {
                Logger.Error(Exception);
                throw;
            }
        }

        [HttpGet]
        public void GetDocumento()
        {
            try
            {
                var user = (UsuarioVM)Session["Usuario"];

                if (Session["Conteo"] == null) Session["Conteo"] = new ConteoSegaViewModel();

                var documento = _biz.GetDocumento(user.legajo);

                if(documento != null)
                {
                    var infoDoc = _biz.GetPosicionesxIdDoc(documento.idDoc);

                    if (infoDoc.TotalRegistros > 0)
                    {
                        if (infoDoc.Escritos == infoDoc.TotalRegistros)
                        {
                            conteo.MsgError = "Ya fueron cargados todos los conteos para el documento seleccionado";
                            Session["Conteo"] = conteo;
                            conteo.Write(ClientResponseType.JSON);
                        }
                        else if (infoDoc.Escritos > 0 && infoDoc.Escritos < infoDoc.TotalRegistros)
                        {
                            //continuar o no
                            MapearDatos(infoDoc, conteo, documento);
                            conteo.Leido = true;
                            Session["Conteo"] = conteo;
                            conteo.Write(ClientResponseType.JSON);
                        }
                        else
                        {
                            //empieza de 0
                            MapearDatos(infoDoc, conteo, documento);
                            Session["Conteo"] = conteo;
                            conteo.Write(ClientResponseType.JSON);
                        }
                    }
                }
                else
                {
                    conteo.MsgError = "El usuario no tiene documentos asociados";
                    Session["Conteo"] = null;
                    conteo.Write(ClientResponseType.JSON);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        private void MapearDatos(DatosDocumento info, ConteoSegaViewModel conteo, Documento doc)
        {
            conteo.idDocumento = doc.idDoc;
            conteo.Documento = doc.documento;
            conteo.RegistroTotal = info.TotalRegistros;
            conteo.RegistroCargado = info.Escritos;
            conteo.Id = info.PrimerId;
            conteo.Indice = info.PrimerIdDisponible;
            conteo.First = false;
        }

        public void ComenzarCarga()
        {
            Comenzar();

            conteo.Write(ClientResponseType.JSON);
        }
        [HttpPost]
        public void Loggear(string opcion)
        {
            var cookie = (ConteoSegaViewModel)Session["Conteo"];
            Logger.Debug("Documento: " + cookie.idDocumento +" Opción Elegida:  " + opcion);
            Logger.Info("Documento: " + cookie.idDocumento + " Opción Elegida:  " + opcion);
            conteo.Write(ClientResponseType.JSON);
        }
        private void Comenzar()
        {
            try
            {
                if (Session["Conteo"] != null) conteo = (ConteoSegaViewModel)Session["Conteo"];

                _biz.ReiniciarDocumento(conteo.idDocumento);

                ResetConteo(conteo);

                conteo.RegistroCargado = 0;

                Session["Conteo"] = conteo;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public ActionResult ContinuarCarga()
        {
            return View();
        }

        public ActionResult Inventario()
        {
            Continuar();

            if (!conteo.Finalizado)
            {
                return View(conteo);
            }
            else
            {
                return RedirectToAction("Cerrar");
            }
        }

        private void Continuar()
        {
            try
            {
                if (Session["Conteo"] != null) conteo = (ConteoSegaViewModel)Session["Conteo"];

                var registro = _biz.PrimerRegistroDisponible(conteo.idDocumento);

                if (registro != null)
                {
                    registro.Documento = conteo.Documento;
                    conteo.Id = registro.Id;
                    conteo.Ubicacion = registro.Sector + " - " + registro.PASILLO + " - " + registro.COLUMNA + " - " + registro.NIVEL + " - " + registro.COMPART;
                    conteo.Digito = registro.Digito ?? "";
                    conteo.Camadas = registro.Bultos ?? 0;

                    conteo.TipoInventario = (registro.TipoInventario == TipoInventarios.Camadas)
                        ? conteo.TipoInventario = TipoInventarios.Camadas.ToString() : conteo.TipoInventario = "Cajas";

                    conteo.iCxHActual = registro.CxH;
                    conteo.MsgError = "";

                    conteo.Etiqueta = registro.ETIQUETA;

                    if (!string.IsNullOrEmpty(conteo.Etiqueta))
                    {
                        conteo.Articulo = string.Format("{0} - {1}", registro.ean13 != null ? registro.ean13.Trim() : string.Empty , registro.DESCRIPCION != null ? registro.DESCRIPCION.Trim() : string.Empty);
                    }

                    conteo.RegistroCargado++;

                    Session["Conteo"] = conteo;
                }
                else
                {
                    var infoDoc = _biz.GetPosicionesxIdDoc(conteo.idDocumento);

                    if (infoDoc.TotalRegistros > 0)
                    {
                        if (infoDoc.Escritos == infoDoc.TotalRegistros)
                        {
                            conteo.MsgError = "Ya fueron cargados todos los conteos para el documento seleccionado";
                            conteo.Finalizado = true;
                            Session["Conteo"] = conteo;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public ActionResult Cerrar()
        {
            return View();
        }

        [HttpPost]
        public void Grabar(ConteoSegaViewModel conteo)
        {
            try
            {
                InventarioUpdate request = new InventarioUpdate()
                {
                    usuarioInventario = conteo.UsuarioInventario,
                    digito = conteo.Digito,
                    id = conteo.Id,
                    observaciones = conteo.Observaciones,
                    usuario = System.Web.HttpContext.Current.User.Identity.IsAuthenticated ? System.Web.HttpContext.Current.User.Identity.Name : "Pocket"
                };

                if (conteo.Digito.Equals("."))
                {
                    request.codigoArticulo = "(-.-)";
                }
                else
                {
                    string[] codigo = conteo.Articulo.Split('-');
                    request.codigoArticulo = codigo[0];
                }

                if (conteo.TipoInventario.ToUpper() == TipoInventarios.Camadas.ToString().ToUpper())
                {
                    request.bultosInv = (conteo.Camadas * conteo.iCxHActual) + conteo.CajasSueltas;
                    request.cajasSueltasInv = conteo.CajasSueltas;
                    request.hxPInv = (int)conteo.Camadas;
                }
                else
                {
                    request.bultosInv = conteo.Camadas;
                    request.cajasSueltasInv = 0;
                    request.hxPInv = 0;
                }

                if (_biz.Update(request))
                {
                    ResetConteo(conteo);

                    conteo.MsgError = "Datos guardados correctamente";

                    if (conteo.RegistroCargado == conteo.RegistroTotal)
                    {
                        conteo.MsgError = _biz.ControlAutomatico(conteo.idDocumento);
                    }
                }
                else
                {
                    conteo.MsgError = "Ups! No se han guardado los datos. Reintente nuevamente";
                }

                Session["Conteo"] = conteo;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        [HttpGet]
        public void GetURL()
        {
            try
            {
                var url = ConfigurationManager.AppSettings["url"].ToString();

                url.Write(ClientResponseType.JSON);
            }
            catch (Exception Exception)
            {
                Logger.Error(Exception);
                throw;
            }
        }

        private static void ResetConteo(ConteoSegaViewModel conteo)
        {
            conteo.Observaciones = "";
            conteo.Digito = "0";
            conteo.CajasSueltas = 0;
            conteo.Bulto = 0;
            conteo.Camadas = 0;
            conteo.Articulo = "";
            conteo.First = false;
        }
    }
}
