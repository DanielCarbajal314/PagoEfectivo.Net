using PagoEfectivo.Net.Authentication;
using PagoEfectivo.Net.DataContracts;
using PagoEfectivo.Net.DataTransformation;
using PagoEfectivo.Net.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net
{
    public class PagoEfectivoClient
    {
        private readonly AuthenticateClientFactory _authenticateClientFactory = new AuthenticateClientFactory();

        public RegisterPaymentResponse RegisterNewPayment(RegisterPayment requestData)
        {
            var client = _authenticateClientFactory.BuildAuthenticatedClient();
            var pagoEfectivoRequestBody = requestData.ToModel();
            var request = new RestRequest(@"v1/cips", DataFormat.Json).AddJsonBody(pagoEfectivoRequestBody);
            return client.Post<RegisterCIPResponse>(request).Data.ToDataContract();
        }
    }
}
