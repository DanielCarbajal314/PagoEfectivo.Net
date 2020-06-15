using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagoEfectivo.Net.DataContracts;

namespace PagoEfectivo.Net.Test
{
    [TestClass]
    public class CIPRegisterTest
    {
        [TestMethod]
        public void CanaryTest()
        {
            var client = new PagoEfectivoClient();
        }

        [TestMethod]
        public void RegisterPayment()
        {
            var client = new PagoEfectivoClient();
            var result = client.RegisterNewPayment(new RegisterPayment
            {
                AdditionalData = "First Payment",
                AdminEmail = "Daniel.carbajal@pucp.edu.pe",
                Amount = 100,
                Currency = Currency.PEN,
                DateExpiry = new DateTime(2021, 1, 3),
                PaymentConcept = "Food",
                TransactionCode = "123666321",
                UserCodeCountry = "PE",
                UserCountry = "PERU",
                UserDocumentNumber = "70007800",
                UserDocumentType = UserDocumentType.DNI,
                UserEmail = "dcarbajal@number8.com",
                UserLastName = "Carbajal",
                UserName = "Daniel",
                UserPhone = "980784506",
                UserUbigeo = "150101"          
            });
            Assert.AreEqual(result.Amount, 100);
            Assert.IsTrue(result.Cip > 0);
            Assert.IsTrue(result.CipUrl.Length > 10);
            Assert.AreEqual(result.Currency, "PEN");
            Assert.AreEqual(result.DateExpiry.DayOfYear, new DateTime(2021, 1, 3).DayOfYear);
        }
    }
}
