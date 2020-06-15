using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.DataContracts
{
    public class RegisterPaymentResponse
    {
        public int Cip { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
        public string TransactionCode { get; set; }
        public DateTime DateExpiry { get; set; }
        public string CipUrl { get; set; }
    }
}
