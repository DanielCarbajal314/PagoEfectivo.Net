using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.Authentication
{
    internal class AuthenticationResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public AuthenticateResponseData Data { get; set; }
        public string Url { get; set; }
    }

    public class AuthenticateResponseData
    {
        public string Token { get; set; }
        public string CodeService { get; set; }
        public string TokenStart { get; set; }
        public string TokenExpires { get; set; }
    }
}
