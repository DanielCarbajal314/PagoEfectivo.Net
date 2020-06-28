using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.Persistance.DataContracts
{
    public class RegisterPaymentHttpException
    {
        public string Id { get; set; }
        public string ExceptionStack { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
