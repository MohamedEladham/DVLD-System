using System;
using DVLD_Models;
using DVLD_Infrastructure;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DVLD_DAL
{
    public class clsCountryDAL
    {
        private static clsCountryInfo MapReaderToCountry(SqlDataReader reader)
        {
            return new clsCountryInfo
            {
                CountryID = Convert.ToInt32(reader["CountryID"]),
                CountryName = Convert.ToString(reader["CountryName"]),
                CountryCode = reader["CountryCode"] == DBNull.Value ? "" : Convert.ToString(reader["CountryCode"])
            };
        }

        public static List<clsCountryInfo> GetAllCountries()
        {
            List<clsCountryInfo> countryInfos = new List<clsCountryInfo>();

            string query_GetAllCountriesInfo = @"Select 
                                                        [CountryID],
                                                        [CountryName],
                                                        [CountryCode]
                                                From Countries";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query_GetAllCountriesInfo, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        countryInfos.Add(MapReaderToCountry(reader));
                }
            }

            return countryInfos;
        }
    }
}
