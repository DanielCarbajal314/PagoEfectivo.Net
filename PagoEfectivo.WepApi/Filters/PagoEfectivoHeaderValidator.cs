using PagoEfectivo.Net;
using PagoEfectivo.Net.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PagoEfectivo.WepApi.Filters
{
    public class PagoEfectivoHeaderValidator : ActionFilterAttribute
    {
        public readonly ConfigurationSettings settings = new ConfigurationSettings();
        public override void OnActionExecuting(HttpActionContext actionExecutedContext)
        {
            var expectedSignature = this.getBody(actionExecutedContext).GetSignature(settings.SecretKey);
            var headerIsInvalid = !actionExecutedContext.Request.Headers.Any(x => x.Key.Equals("PE-Signature")) ||
                                  !actionExecutedContext.Request.Headers.First(x => x.Key.Equals("PE-Signature")).Value.First().Equals(expectedSignature);
            if (headerIsInvalid)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                    HttpStatusCode.Unauthorized,
                    new
                    {
                        ErroMessage = $"Non Valid Request"
                    });
            }
            base.OnActionExecuting(actionExecutedContext);
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