using DVLD_Infrastructure;
using DVLD_Models;
using DVLD_Models.LicenseClass;
using DVLD_Models.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsLicenseClassDAL
    {
        public static byte? GetMinimumAllowedAgeForLicenseClass(int licenseClassID) 
        {
            string query = @"SELECT 
                                    MinimumAllowedAge
                                 FROM LicenseClasses
                                 WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                connection.Open();

                var result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    return Convert.ToByte(result);
            }
            
            return null;
        }

        // >>
        private static clsLicenseClass _MapReaderToLicenseClassBasicInfo(SqlDataReader reader)
        {
            return new clsLicenseClass
            {
                LicenseClassID = (int)reader["LicenseClassID"],
                ClassName = (string)reader["ClassName"],
                MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"])
            };
        }

        public static List<clsLicenseClass> GetAllActiveLicenseClassesBasicInfo() 
        {
            List<clsLicenseClass> licenseClasses = new List<clsLicenseClass>();

            string query = @"SELECT 
                                    [LicenseClassID], 
                                    [ClassName],
                                    [MinimumAllowedAge]
                                FROM LicenseClasses 
                                WHERE IsActive = 1";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                        licenseClasses.Add(_MapReaderToLicenseClassBasicInfo(reader));
                }
            }

            return licenseClasses;
        }
    }
}
