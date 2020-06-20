using PagoEfectivo.Net.Persistance;
using PagoEfectivo.Net.Persistance.DataContracts;
using PagoEfectivo.WepApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PagoEfectivo.WepApi.Controllers
{
    public class PaymentsController : ApiController
    {
        [HttpPost]
        [PagoEfectivoHeaderValidator]
        public void Post(RegisterPaymentOnPagoEfectivo registerPaymentOnPagoEfectivo)
        {
            var repo = new PagoEfectivoRepository();
            repo.RegisterPaymentOnPagoEfectivo(registerPaymentOnPagoEfectivo);
        }
    }
}
