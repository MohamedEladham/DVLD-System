using System;
using DVLD_Models;
using DVLD_Infrastructure;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DVLD_DAL
{
    public class clsCountryDAL
    {
        private static clsCountry MapReaderToCountry(SqlDataReader reader)
        {
            return new clsCountry
            {
                CountryID = Convert.ToInt32(reader["CountryID"]),
                CountryName = Convert.ToString(reader["CountryName"]),
                CountryCode = reader["CountryCode"] == DBNull.Value ? "" : Convert.ToString(reader["CountryCode"])
            };
        }

        public static List<clsCountry> GetAllCountries()
        {
            List<clsCountry> countries = new List<clsCountry>();

            string query = @"Select 
                                    [CountryID],
                                    [CountryName],
                                    [CountryCode]
                            From Countries";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        countries.Add(MapReaderToCountry(reader));
                }
            }

            return countries;
        }
    }
}
