using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace PagoEfectivo.WepApi.Filters
{
    public class PagoEfectivoHeaderValidator : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

        private string getBody(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Content.Headers.ContentType.ToString() == "application/json")
            {
                var streamResult = actionExecutedContext.Request.Content.ReadAsStreamAsync().Result;
                using (var stream = new StreamReader(streamResult))
                {
                    stream.BaseStream.Position = 0;
                    return stream.ReadToEnd().Replace(" ","").Replace(" ","").Replace(Environment.NewLine,"");
                }
            }
            return "";
        }
    }
}