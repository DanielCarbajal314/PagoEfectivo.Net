using PagoEfectivo.Net;
using PagoEfectivo.Net.DataContracts;
using PagoEfectivo.Net.Persistance;
using PagoEfectivo.Net.Persistance.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo
{
    public class PagoEfectivoService
    {
        private readonly PagoEfectivoRepository repository = new PagoEfectivoRepository();
        private readonly PagoEfectivoClient client = new PagoEfectivoClient();

        public void RegisterNewPayment(RegisterPayment registerPayment) 
        {
            var transactionCode = repository.RegisterPagoEfectivoPayment(new RegisterPagoEfectivoPayment
            {
                AdditionalData = registerPayment.AdditionalData,
                AdminEmail = registerPayment.AdminEmail,
                Amount = registerPayment.Amount,
                Currency = registerPayment.Currency.ToString(),
                DateExpiry = registerPayment.DateExpiry,
                PaymentConcept = registerPayment.PaymentConcept,
                UserCodeCountry = registerPayment.UserCodeCountry,
                UserCountry = registerPayment.UserCountry,
                UserDocumentNumber = registerPayment.UserDocumentNumber,
                UserDocumentType = registerPayment.UserDocumentType.ToString(),
                UserEmail = registerPayment.UserEmail,
                UserLastName = registerPayment.UserLastName,
                UserName = registerPayment.UserName,
                UserPhone = registerPayment.UserPhone,
                UserUbigeo = registerPayment.UserUbigeo,
            });
            registerPayment.TransactionCode = transactionCode.ToString();
            var result = client.RegisterNewPayment(registerPayment);
            repository.UpdateCiffOnPagoEfectivoPayment(new UpdateCiffOnPagoEfectivoPayment
            {
                Cip = result.Cip,
                TransaccionCode = transactionCode,
                CipUrl = result.CipUrl
            });
        }
    }
}
