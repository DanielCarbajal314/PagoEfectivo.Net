using PagoEfectivo.Net.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.Authentication
{
    public class AuthenticationRequest
    {
        public string AccessKey { get; set; }
        public int IdService { get; set; }
        public string SecretKey { get; set; }
        public string DateRequest
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            }
        }
        public string HashString
        {
            get
            {
                var authRequest = this.IdService.ToString() + "." + this.AccessKey + "." + this.SecretKey + "." + this.DateRequest;
                return authRequest.ToSha256();
            }
        }
    }
}
