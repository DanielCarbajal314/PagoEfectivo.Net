using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.Persistance.DataContracts
{
    public class RegisterPaymentHttpRequest
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public DateTime Date { get; set; } = DateTime.Now;
        public string Content { get; set; }
        public string Signarute { get; set; }
    }
}
