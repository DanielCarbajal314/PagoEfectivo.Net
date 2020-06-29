using PagoEfectivo.Net.DataContracts;
using PagoEfectivo.Net.Persistance;
using PagoEfectivo.Net.Persistance.DataContracts;
using PagoEfectivo.WepApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace PagoEfectivo.WepApi.Controllers
{
    public class PaymentsController : ApiController
    {
        [HttpPost]
        [PagoEfectivoHeaderValidator]
        [PagoEfectivoExceptionFilter]
        public object Post(PaymentHappenedOnPagoEfectivo registerPaymentOnPagoEfectivo)
        {
            var repo = new PagoEfectivoRepository();
            repo.RegisterPaymentOnPagoEfectivo(new RegisterPaymentOnPagoEfectivo 
            {
                EventType = registerPaymentOnPagoEfectivo.EventType,
                OperationNumber = registerPaymentOnPagoEfectivo.OperationNumber,
                PaymentDate = registerPaymentOnPagoEfectivo.Data.PaymentDate,
                TransaccionCode = registerPaymentOnPagoEfectivo.Data.TransactionCode
            });
            return new
            {
                message = "It Was ok!"
            };
        }
    }
}
