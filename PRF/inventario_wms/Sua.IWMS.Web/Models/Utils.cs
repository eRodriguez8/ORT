using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Corp.Cencosud.Supermercados.Corp.Cencosud.Supermercados.Sua.IWMS.Web.Models
{
    public static class Utils
    {
        public const string JSON = "application/json; charset=utf-8";
        public const string HTMl = "text/html; charset=utf-8";
        public const string PlainText = "text/plain; charset=utf-8";

        /// <summary>
        /// Path of the project while it is running
        /// </summary>
        public static string ContextPath = HttpContext.Current.Request.Url.Scheme + System.Uri.SchemeDelimiter + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath + ((HttpContext.Current.Request.ApplicationPath.EndsWith("/")) ? "" : "/");
        
        /// <summary>
        /// Envía un response con el tipo especificado
        /// ejemplo => Contenido.Write(ClientResponseType.JSON);
        /// </summary>
        /// <param name="Content">Contenido</param>
        /// <param name="Type">Tipo de respuesta</param>
        public static void Write(this object Content, ClientResponseType Type)
        {
            var serialize = new JavaScriptSerializer();
            switch (Type)
            {
                case ClientResponseType.JSON:
                    HttpContext.Current.Response.ContentType = JSON;
                    HttpContext.Current.Response.Write(serialize.Serialize(Content));
                    break;
                case ClientResponseType.HTML:
                    HttpContext.Current.Response.ContentType = HTMl;
                    HttpContext.Current.Response.Write(Content);
                    break;
                case ClientResponseType.PlainText:
                    HttpContext.Current.Response.ContentType = PlainText;
                    HttpContext.Current.Response.Write(Content);
                    break;
            }
        }
    }
}