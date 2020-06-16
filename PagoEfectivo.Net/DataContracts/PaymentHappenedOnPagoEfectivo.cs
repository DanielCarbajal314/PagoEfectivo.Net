using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.DataContracts
{
    public class PaymentHappenedOnPagoEfectivo
    {
        public string EventType { get; set; }
        public int OperationNumber { get; set; }
        public PaymentHappenedOnPagoEfectivoData Data { get; set; }
    }

    public class PaymentHappenedOnPagoEfectivoData 
    {
        public int Cip { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TransactionCode { get; set; }
    }
}
