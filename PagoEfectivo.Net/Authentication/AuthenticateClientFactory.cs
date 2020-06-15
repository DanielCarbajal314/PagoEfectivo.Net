using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.Authentication
{
    internal class AuthenticateClientFactory
    {
        private DateTime? lastExecution;
        private AuthenticateResponseData authenticateResponseData;
        private readonly AuthenticationRequest _authenticationRequest;
        private readonly string _url;
        private readonly RestClient client;

        public AuthenticateClientFactory()
        {
            var configurationSettings = new ConfigurationSettings();
            this._url = configurationSettings.PagoEfectivoAPIEndpoint;
            this.client = new RestClient(this._url);
            this._authenticationRequest = new AuthenticationRequest
            {
                AccessKey = configurationSettings.AccessKey,
                IdService = int.Parse(configurationSettings.IdService),
                SecretKey = configurationSettings.SecretKey
            };
        }

        public RestClient BuildAuthenticatedClient()
        {
            var needToUpdateToken = !lastExecution.HasValue || lastExecution.Value.AddHours(1) > DateTime.Now;
            if (needToUpdateToken)
            {
                this.authenticateResponseData = this.getAuthenticationDataFromServer();
            }
            var client = new RestClient(this._url);
            client.AddDefaultHeader("Authorization", $"Bearer {this.authenticateResponseData.Token}");
            return client;
        }

        private AuthenticateResponseData getAuthenticationDataFromServer()
        {
            var request = new RestRequest(@"v1/authorizations", DataFormat.Json).AddJsonBody(this._authenticationRequest);
            return this.client.Post<AuthenticationResponse>(request).Data.Data;
        }

    }
}
