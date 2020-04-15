using log4net;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Exceptions;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Api.Helpers
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class LogException : ExceptionFilterAttribute
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(LogException));

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotFoundException)
            {
                actionExecutedContext.Response = actionExecutedContext.ActionContext.ControllerContext.Request
                    .CreateResponse(HttpStatusCode.NotFound, new { });
                return;
            }

            if (actionExecutedContext.Exception is BadRequestException)
            {
                var exception = (BadRequestException)actionExecutedContext.Exception;
                actionExecutedContext.Response = actionExecutedContext.ActionContext.ControllerContext.Request
                    .CreateResponse(HttpStatusCode.BadRequest, new { exception.Message });
                return;
            }

            if(actionExecutedContext.Exception is ConflictException)
            {
                var exception = (ConflictException)actionExecutedContext.Exception;
                actionExecutedContext.Response = actionExecutedContext.ActionContext.ControllerContext.Request
                    .CreateResponse(HttpStatusCode.Conflict, new { });
                return;
            }

            if (actionExecutedContext.Exception is NotAllowedException)
            {
                actionExecutedContext.Response = actionExecutedContext.ActionContext.ControllerContext.Request
                    .CreateResponse(HttpStatusCode.Forbidden, new { });
                return;
            }

            Logger.Error(actionExecutedContext.Exception);
            Logger.Error("Parametro/s de entrada: " +
                    "URI: " + actionExecutedContext.Request.RequestUri +
                    "BODY: " + GetBodyFromRequest(actionExecutedContext));
        }

        /// <summary>
        /// Obtiene los datos recibidos por el método del servicio y lo parsea a json
        /// </summary>
        private string GetBodyFromRequest(HttpActionExecutedContext context)
        {
            string data;

            using (var stream = context.Request.Content.ReadAsStreamAsync().Result)
            {
                if (stream.CanSeek)
                {
                    stream.Position = 0;
                }
                data = context.Request.Content.ReadAsStringAsync().Result;
            }

            return data;
        }
    }
}