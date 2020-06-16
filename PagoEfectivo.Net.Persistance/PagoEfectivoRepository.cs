using PagoEfectivo.Net.Persistance.DataContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.Persistance
{
    public class PagoEfectivoRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["PagoEfectivoDb"].ConnectionString;

        public int RegisterPagoEfectivoPayment(RegisterPagoEfectivoPayment registerPagoEfectivoPaymentParameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.RegisterPagoEfectivoPayment(registerPagoEfectivoPaymentParameters);
            }
        }

        public void UpdateCiffOnPagoEfectivoPayment(UpdateCiffOnPagoEfectivoPayment updateCiffOnPagoEfectivoPayment)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.UpdateCiffOnPagoEfectivoPayment(updateCiffOnPagoEfectivoPayment);
            }
        }

        public void RegisterPaymentOnPagoEfectivo(RegisterPaymentOnPagoEfectivo registerPaymentOnPagoEfectivo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.RegisterPaymentOnPagoEfectivo(registerPaymentOnPagoEfectivo);
            }
        }
    }
}
