using PagoEfectivo.Net.DataContracts;
using PagoEfectivo.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.DataTransformation
{
    internal static class RegisterPaymentTransformation
    {
        internal static RegisterCIPRequest ToModel(this RegisterPayment payment)
        {
            return new RegisterCIPRequest
            {
                AdditionalData = payment.AdditionalData,
                AdminEmail = payment.AdminEmail,
                Amount = payment.Amount,
                Currency = payment.Currency.ToString("g"),
                DateExpiry = payment.DateExpiry,
                PaymentConcept = payment.PaymentConcept,
                TransactionCode = payment.TransactionCode,
                UserCodeCountry = payment.UserCodeCountry,
                UserCountry = payment.UserCountry,
                UserDocumentNumber = payment.UserDocumentNumber,
                UserDocumentType = payment.UserDocumentType.ToString("g"),
                UserEmail = payment.UserEmail,
                UserLastName = payment.UserLastName,
                UserName = payment.UserName,
                UserPhone = payment.UserPhone,
                UserUbigeo = payment.UserUbigeo
            };
        }

        internal static RegisterPaymentResponse ToDataContract(this RegisterCIPResponse response)
        {
            return new RegisterPaymentResponse
            {
                Amount = response.Data.Amount,
                Cip = response.Data.Cip,
                CipUrl = response.Data.CipUrl,
                Currency = response.Data.Currency,
                DateExpiry = response.Data.DateExpiry,
                TransactionCode = response.Data.TransactionCode,
                Code = response.Code,
                Message = response.Message
            };
        }
    }
}
