using DVLD_Infrastructure;
using DVLD_Models.Application;
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsApplicationDAL
    {

        private static clsApplicationGridViewDto _MapReaderToApplicationGridViewDto(SqlDataReader reader)
        {
            return new clsApplicationGridViewDto
            {
                ID = (int)reader["ApplicationID"],
                PersonName = (string)reader["PersonName"],
                NationalNo = (string)reader["NationalNo"],
                ServiceName = (string)reader["ServiceName"],
                Status = (string)reader["StatusName"],
                ApplicationDate = (DateTime)reader["ApplicationDate"],
                PaidFees = (decimal)reader["ApplicationPaidFees"]
            };
        }

        public static List<clsApplicationGridViewDto> GetAllApplicationsForGridView() 
        {
            List<clsApplicationGridViewDto> applicationsList = new List<clsApplicationGridViewDto>();

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                string query = @"SELECT 
			                            A.ApplicationID,
			                            P.FirstName + ' ' +
                                        P.SecondName + ' ' +
                                        P.ThirdName + ' ' +
                                        P.LastName AS PersonName,
                                        P.NationalNo,
			                            S.ServiceName,
			                            ST.StatusName,
			                            A.ApplicationDate,
			                            A.ApplicationPaidFees
		                            FROM Applications A
			                            INNER JOIN Persons P 
		                            ON A.PersonID = P.PersonID
			                            INNER JOIN Services S
		                            ON A.ServiceID = S.ServiceID
			                            INNER JOIN ApplicationStatuses ST
		                            ON A.ApplicationStatusID = ST.ApplicationStatusID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            applicationsList.Add(_MapReaderToApplicationGridViewDto(reader));
                    }
                }
            }

            return applicationsList;
        }

        public static List<clsApplicationGridViewDto> GetApplicationsByStatus(enApplicationStatuses applicationStatusID)
        {
            List<clsApplicationGridViewDto> applicationsList = new List<clsApplicationGridViewDto>();

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                string query = @"SELECT 
			                            A.ApplicationID,
			                            P.FirstName + ' ' +
                                        P.SecondName + ' ' +
                                        P.ThirdName + ' ' +
                                        P.LastName AS PersonName,
                                        P.NationalNo,
			                            S.ServiceName,
			                            ST.StatusName,
			                            A.ApplicationDate,
			                            A.ApplicationPaidFees
		                            FROM Applications A
			                            INNER JOIN Persons P 
		                            ON A.PersonID = P.PersonID
			                            INNER JOIN Services S
		                            ON A.ServiceID = S.ServiceID
			                            INNER JOIN ApplicationStatuses ST
		                            ON A.ApplicationStatusID = ST.ApplicationStatusID
		                            WHERE A.ApplicationStatusID = @ApplicationStatusID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.Add("@ApplicationStatusID", System.Data.SqlDbType.Int).Value = (int)applicationStatusID;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            applicationsList.Add(_MapReaderToApplicationGridViewDto(reader));
                    }
                }
            }

            return applicationsList;
        }


    }
}
