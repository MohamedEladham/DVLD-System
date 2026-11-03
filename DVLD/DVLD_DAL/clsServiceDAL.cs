using DVLD_Infrastructure;
using DVLD_Models;
using DVLD_Models.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsServiceDAL
    {
        public static (bool ServiceExists, decimal? ApplicationFees) GetApplicationFeesByServiceID(int serviceID)
        {
            string query = @"SELECT ApplicationFees
                                             FROM Services
                                             WHERE ServiceID = @ServiceID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ServiceID", SqlDbType.Int).Value = serviceID;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return (false, null);

                    if (reader["ApplicationFees"] == DBNull.Value)
                        return (true, null);

                    return (true, Convert.ToDecimal(reader["ApplicationFees"]));
                }
            }
        }

        private static clsService _MapReaderToService(SqlDataReader reader)
        {
            return new clsService
            {
                ServiceID = (int)reader["ServiceID"],
                ServiceName = (string)reader["ServiceName"],
                ApplicationFees = reader.IsDBNull(reader.GetOrdinal("ApplicationFees")) ? null : (decimal?)reader["ApplicationFees"]
            };
        }

        public static clsService GetServiceInfoByID(int serviceID)
        {
            clsService service = null;

            string query = @"SELECT 
                                    [ServiceID], 
                                    [ServiceName],
                                    [ApplicationFees]
                                FROM Services
                                WHERE ServiceID = @ServiceID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ServiceID", System.Data.SqlDbType.Int).Value = serviceID;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        service = _MapReaderToService(reader);
                }
            }

            return service;
        }
    }
}
