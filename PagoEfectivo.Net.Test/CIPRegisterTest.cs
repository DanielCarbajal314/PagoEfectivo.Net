using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagoEfectivo.Net.DataContracts;
using PagoEfectivo.Net.Persistance;
using PagoEfectivo.Net.Persistance.DataContracts;
using PagoEfectivo.Net.Security;

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

        [TestMethod]
        public void PaymentHappenOnPagoEfectivo() 
        {
            var repository = new PagoEfectivoRepository();
            var client = new PagoEfectivoClient();
            var transactionCode = repository.RegisterPagoEfectivoPayment(new RegisterPagoEfectivoPayment
            {
                AdditionalData = "First Payment",
                AdminEmail = "Daniel.carbajal@pucp.edu.pe",
                Amount = 100,
                Currency = Currency.PEN.ToString(),
                DateExpiry = new DateTime(2021, 1, 3),
                PaymentConcept = "Food",
                UserCodeCountry = "PE",
                UserCountry = "PERU",
                UserDocumentNumber = "70007800",
                UserDocumentType = UserDocumentType.DNI.ToString(),
                UserEmail = "dcarbajal@number8.com",
                UserLastName = "Carbajal",
                UserName = "Daniel",
                UserPhone = "980784506",
                UserUbigeo = "150101"
            });
            var result = client.RegisterNewPayment(new RegisterPayment
            {
                AdditionalData = "First Payment",
                AdminEmail = "Daniel.carbajal@pucp.edu.pe",
                Amount = 100,
                Currency = Currency.PEN,
                DateExpiry = new DateTime(2021, 1, 3),
                PaymentConcept = "Food",
                TransactionCode = transactionCode.ToString(),
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
            repository.UpdateCiffOnPagoEfectivoPayment(new UpdateCiffOnPagoEfectivoPayment
            {
                Cip = result.Cip,
                TransaccionCode = transactionCode,
                CipUrl = result.CipUrl
            });
        }

        [TestMethod]
        public void RegisterPaymentOnDb()
        {
            var repository = new PagoEfectivoRepository();
            var client = new PagoEfectivoClient();
            var transactionCode = repository.RegisterPagoEfectivoPayment(new RegisterPagoEfectivoPayment
            {
                AdditionalData = "First Payment",
                AdminEmail = "Daniel.carbajal@pucp.edu.pe",
                Amount = 100,
                Currency = Currency.PEN.ToString(),
                DateExpiry = new DateTime(2021, 1, 3),
                PaymentConcept = "Food",
                UserCodeCountry = "PE",
                UserCountry = "PERU",
                UserDocumentNumber = "70007800",
                UserDocumentType = UserDocumentType.DNI.ToString(),
                UserEmail = "dcarbajal@number8.com",
                UserLastName = "Carbajal",
                UserName = "Daniel",
                UserPhone = "980784506",
                UserUbigeo = "150101"
            });
            var result = client.RegisterNewPayment(new RegisterPayment
            {
                AdditionalData = "First Payment",
                AdminEmail = "Daniel.carbajal@pucp.edu.pe",
                Amount = 100,
                Currency = Currency.PEN,
                DateExpiry = new DateTime(2021, 1, 3),
                PaymentConcept = "Food",
                TransactionCode = transactionCode.ToString(),
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
            repository.UpdateCiffOnPagoEfectivoPayment(new UpdateCiffOnPagoEfectivoPayment
            {
                Cip = result.Cip,
                TransaccionCode = transactionCode,
                CipUrl = result.CipUrl
            });
            repository.RegisterPaymentOnPagoEfectivo(new RegisterPaymentOnPagoEfectivo 
            {
                EventType = "cip.paid",
                OperationNumber = 1233,
                PaymentDate = DateTime.Now,
                TransaccionCode = transactionCode
            });
        }

        [TestMethod]
        public void FinalIntegration() 
        {
            PagoEfectivoService service = new PagoEfectivoService();
            service.RegisterNewPayment(new RegisterPayment
            {
                AdditionalData = "Last Payment",
                AdminEmail = "Daniel.carbajal@pucp.edu.pe",
                Amount = 1001,
                Currency = Currency.PEN,
                DateExpiry = new DateTime(2021, 1, 3),
                PaymentConcept = "Food on Drinks",
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
        }

        [TestMethod]
        public void TestSignatureValidator() 
        {
            var key = "MsB3V0seHJY2gcdly7LsNVtXJF+QLGO+l/Oc8z4j";
            var signatureExpected = "89138e0dd0681d2463467160d41a4a9b0b0257ba14af06a7ab441b693b57699e";
            var body = "{\"EventType\":\"Test.PCDaniel\",\"OperationNumber\":2123,\"Data\":{\"Cip\":1,\"Currency\":\"PEN\",\"Amount\":1001.00,\"PaymentDate\":\"2020-06-18T23:28:45.1220545-05:00\",\"TransactionCode\":84}}";
            var signatureProduced = body.GetSignature(key);
            Assert.AreEqual(signatureExpected, signatureProduced);
        }

    }
}
