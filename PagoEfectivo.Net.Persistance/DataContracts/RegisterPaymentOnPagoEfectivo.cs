using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.Persistance.DataContracts
{
    public class RegisterPaymentOnPagoEfectivo
    {
        public int TransaccionCode { get; set; }
        public int OperationNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public string EventType { get; set; }
    }
}
