using DVLD_Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsLicenseDAL
    {
        public static bool HasActiveLicenseForClass(int personID, int licenseClassID)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                string query = @"
                                SELECT CASE
                                    WHEN EXISTS
                                    (
                                        SELECT 1
                                        FROM Licenses
                                        WHERE PersonID = @PersonID
                                            AND LicenseClassID = @LicenseClassID
                                            AND IsActive = 1
                                            AND ExpirationDate >= CAST(GETDATE() AS DATE)
                                    )
                                    THEN 1
                                    ELSE 0
                                END;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", SqlDbType.Int).Value = personID;
                    command.Parameters.AddWithValue("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                    connection.Open();

                    exists = Convert.ToBoolean(command.ExecuteScalar());
                }
            }

            return exists;
        }
    }
}
