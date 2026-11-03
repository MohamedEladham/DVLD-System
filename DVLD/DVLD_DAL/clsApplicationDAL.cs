using System;
using System.Data;
using DVLD_Infrastructure;
using System.Data.SqlClient;
using DVLD_Models.Application;
using System.Collections.Generic;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;

namespace DVLD_DAL
{
    public class clsApplicationDAL
    {
        public static bool HasNewApplicationForPersonAndService(int personID, int serviceID)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                string query = @"
                                SELECT CASE
                                    WHEN EXISTS
                                    (
                                        SELECT 1
                                        FROM Applications
                                        WHERE PersonID = @PersonID
                                            AND ServiceID = @ServiceID
                                            AND ApplicationStatusID = @ApplicationStatusID
                                    )
                                    THEN 1
                                    ELSE 0
                                END;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", SqlDbType.Int).Value = personID;
                    command.Parameters.AddWithValue("@ServiceID", SqlDbType.Int).Value = serviceID;
                    command.Parameters.AddWithValue("@ApplicationStatusID", SqlDbType.Int).Value = (int)enApplicationStatuses.New;

                    connection.Open();

                    exists = Convert.ToBoolean(command.ExecuteScalar());
                }
            }

            return exists;
        }

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

        public static bool AddNewFirstTimeDrivingLicenseApplication(int personID, decimal applicationPaidFees, int licenseClassID, out int newApplicationID)
        {
            bool isSuccess = false;

            newApplicationID = -1;

            if (personID <= 0 || licenseClassID <= 0)
                return false;

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertApplicationQuery = @"INSERT INTO
                                                                Applications
                                                                    (
                                                                        [PersonID],
                                                                        [ServiceID],
                                                                        [ApplicationStatusID],
                                                                        [ApplicationDate],
                                                                        [ApplicationPaidFees]
                                                                    )
                                                                VALUES
                                                                    (
                                                                        @PersonID,
                                                                        @ServiceID,
                                                                        @ApplicationStatusID,
                                                                        GETDATE(),
                                                                        @ApplicationPaidFees
                                                                    );

                                                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        using (SqlCommand insertApplicationCommand = new SqlCommand(insertApplicationQuery, connection, transaction))
                        {
                            insertApplicationCommand.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

                            insertApplicationCommand.Parameters.Add("@ServiceID", SqlDbType.Int).Value = (int)enServices.FirstTimeLicenseIssuance;

                            insertApplicationCommand.Parameters.Add("@ApplicationStatusID", SqlDbType.Int).Value = (int)enApplicationStatuses.New;

                            var paidFeesParameter = insertApplicationCommand.Parameters.Add("@ApplicationPaidFees", SqlDbType.Decimal);

                            paidFeesParameter.Precision = 10;
                            paidFeesParameter.Scale = 2;
                            
                            paidFeesParameter.Value = applicationPaidFees;

                            var result = insertApplicationCommand.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                            {
                                transaction.Rollback();
                                return false;
                            }

                            newApplicationID = Convert.ToInt32(result);

                            if (newApplicationID <= 0)
                            {
                                newApplicationID = -1;
                                transaction.Rollback();
                                return false;
                            }
                        }

                        string insertFirstTimeLicenseDetailsQuery = @"INSERT INTO
                                                                                FirstTimeLicenseApplicationDetails
                                                                                    (
                                                                                        [ApplicationID],
                                                                                        [LicenseClassID]
                                                                                    )
                                                                                VALUES
                                                                                    (
                                                                                        @ApplicationID,
                                                                                        @LicenseClassID
                                                                                    );";

                        using (SqlCommand insertFirstTimeLicenseDetailsCommand = new SqlCommand(insertFirstTimeLicenseDetailsQuery, connection, transaction))
                        {
                            insertFirstTimeLicenseDetailsCommand.Parameters.Add("@ApplicationID", System.Data.SqlDbType.Int).Value = newApplicationID;

                            insertFirstTimeLicenseDetailsCommand.Parameters.Add("@LicenseClassID", System.Data.SqlDbType.Int).Value = licenseClassID;

                            isSuccess = insertFirstTimeLicenseDetailsCommand.ExecuteNonQuery() == 1;
                        }

                        if (!isSuccess)
                        {
                            transaction.Rollback();
                            newApplicationID = -1;
                            return false;
                        }

                        transaction.Commit();

                        return true;
                    }
                    catch
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch
                        {
                            // Preserve the original exception.
                        }

                        newApplicationID = -1;
                        throw;
                    }
                }
            }
        }
    }
}
