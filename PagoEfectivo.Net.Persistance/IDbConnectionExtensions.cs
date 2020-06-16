using Dapper;
using PagoEfectivo.Net.Persistance.DataContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoEfectivo.Net.Persistance
{
    internal static class IDbConnectionExtensions
    {
        internal static int RegisterPagoEfectivoPayment(this IDbConnection connection, RegisterPagoEfectivoPayment registerPagoEfectivoPaymentParameters) 
        {
            return connection.Query<int>("RegisterPagoEfectivoPayments", registerPagoEfectivoPaymentParameters, commandType: CommandType.StoredProcedure).Single();
        }

        internal static void UpdateCiffOnPagoEfectivoPayment(this IDbConnection connection, UpdateCiffOnPagoEfectivoPayment updateCiffOnPagoEfectivoPayment)
        {
            connection.Execute("UpdateCiffOnPagoEfectivoPayments", updateCiffOnPagoEfectivoPayment, commandType: CommandType.StoredProcedure);
        }

        internal static void RegisterPaymentOnPagoEfectivo(this IDbConnection connection, RegisterPaymentOnPagoEfectivo registerPaymentOnPagoEfectivo)
        {
            connection.Execute("RegisterPaymentOnPagoEfectivoPayments", registerPaymentOnPagoEfectivo, commandType: CommandType.StoredProcedure);
        }

        
    }
}
