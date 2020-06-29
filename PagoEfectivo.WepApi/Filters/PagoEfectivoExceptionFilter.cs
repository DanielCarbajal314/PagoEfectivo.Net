using PagoEfectivo.Net.Persistance;
using PagoEfectivo.Net.Persistance.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web;
using System.Web.Http.Filters;

namespace PagoEfectivo.WepApi.Filters
{
    public class PagoEfectivoExceptionFilter : ExceptionFilterAttribute
    {
        private readonly PagoEfectivoRepository pagoEfectivoRepository = new PagoEfectivoRepository();
        public override void OnException(HttpActionExecutedContext context)
        {
            var requestId = HttpContext.Current.Items["HttpRequestId"];
            if (requestId != null) 
            {
                this.pagoEfectivoRepository.RegisterPagoEfectivoPaymentHttpException(new RegisterPaymentHttpException
                {
                    ExceptionMessage = context.Exception.Message,
                    ExceptionStack = context.Exception.StackTrace,
                    Id = requestId.ToString()
                });
            }
            context.Response = context.Request.CreateResponse(
                HttpStatusCode.Unauthorized,
                new
                {
                    RequestId = requestId.ToString(),
                    ErroMessage = context.Exception.Message
                });
        }
    }
}