using PagoEfectivo.Net;
using PagoEfectivo.Net.Persistance;
using PagoEfectivo.Net.Persistance.DataContracts;
using PagoEfectivo.Net.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PagoEfectivo.WepApi.Filters
{
    public class PagoEfectivoHeaderValidator : ActionFilterAttribute
    {
        private readonly ConfigurationSettings settings = new ConfigurationSettings();
        private readonly PagoEfectivoRepository pagoEfectivoRepository = new PagoEfectivoRepository();

        public override void OnActionExecuting(HttpActionContext actionExecutedContext)
        {
            var bodyContentAsString = this.getBody(actionExecutedContext);
            var expectedSignature = bodyContentAsString.GetSignature(settings.SecretKey);
            var authenticationHeader = this.getAuthenticationHeader(actionExecutedContext);
            var headerIsInvalid = !authenticationHeader.Equals(expectedSignature);
            var httpRequestId = pagoEfectivoRepository.RegisterPagoEfectivoPaymentHttpRequest(new RegisterPaymentHttpRequest
            {
                Content = bodyContentAsString,
                Signarute = authenticationHeader
            });
            HttpContext.Current.Items["HttpRequestId"] = httpRequestId;
            if (headerIsInvalid)
            {
                throw new AuthenticationException("Auth header is not present or is invalid");
            }
            base.OnActionExecuting(actionExecutedContext);
        }

        private string getAuthenticationHeader(HttpActionContext actionExecutedContext)
        {
            return actionExecutedContext.Request.Headers.Any(x => x.Key.ToLower().Equals("pe-signature")) ?
                        actionExecutedContext.Request.Headers.First(x => x.Key.ToLower().Equals("pe-signature")).Value.First() :
                        "";
        }

        private string getBody(HttpActionContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Content.Headers.ContentType.ToString() == "application/json")
            {
                var streamResult = actionExecutedContext.Request.Content.ReadAsStreamAsync().Result;
                using (var stream = new StreamReader(streamResult))
                {
                    stream.BaseStream.Position = 0;
                    return stream.ReadToEnd().Replace(" ", "").Replace(" ", "").Replace(Environment.NewLine, "");
                }
            }
            return "";
        }
    }
}