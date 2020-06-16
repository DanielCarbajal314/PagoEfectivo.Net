using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.Persistance.DataContracts
{
    public class UpdateCiffOnPagoEfectivoPayment
    {
        public int TransaccionCode { get; set; }
        public int Cip { get; set; }
        public string CipUrl { get; set; }
    }
}
