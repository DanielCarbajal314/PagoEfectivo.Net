using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.DataContracts
{
    public class RegisterPayment
    {
        public Currency Currency { get; set; }
        public double Amount { get; set; }
        public string TransactionCode { get; set; }
        public string UserEmail { get; set; }
        public DateTime DateExpiry { get; set; }
        public string AdminEmail { get; set; }
        public string PaymentConcept { get; set; }
        public string AdditionalData { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserUbigeo { get; set; }
        public string UserCountry { get; set; }
        public UserDocumentType UserDocumentType { get; set; }
        public string UserDocumentNumber { get; set; }
        public string UserPhone { get; set; }
        public string UserCodeCountry { get; set; }
    }

    public enum Currency
    {
        PEN,
        USD
    }

    public enum UserDocumentType
    {
        DNI,
        PAS,
        LMI,
        PAR,
        NAN
    }
}
