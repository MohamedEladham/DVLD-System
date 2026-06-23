using System;
using DVLD_Models;
using DVLD_Infrastructure;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DVLD_DAL
{
    public class clsPersonDAL
    {
        private static clsPersonInfo MapReaderToPerson(SqlDataReader reader)
        {
            return new clsPersonInfo
            {
                PersonID = Convert.ToInt32(reader["PersonID"]),
                NationalNO = Convert.ToString(reader["NationalNO"]),
                FirstName = Convert.ToString(reader["FirstName"]),
                SecondName = Convert.ToString(reader["SecondName"]),
                ThirdName = Convert.ToString(reader["ThirdName"]),
                LastName = Convert.ToString(reader["LastName"]),
                Gender = Convert.ToChar(reader["Gender"]),
                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                Email = reader["Email"] == DBNull.Value ? "" : Convert.ToString(reader["Email"]),
                Phone = Convert.ToString(reader["Phone"]),
                Address = Convert.ToString(reader["Address"]),
                NationalityCountryID = reader["NationalityCountryID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NationalityCountryID"]),
                ImageName = reader["ImageName"] == DBNull.Value ? "" : Convert.ToString(reader["ImageName"]),
                IsDeleted = (bool)reader["IsDeleted"],
                DeletedAt = reader.IsDBNull(reader.GetOrdinal("DeletedAt")) ? (DateTime?)null : Convert.ToDateTime(reader["DeletedAt"])
            };
        }

        public static List<clsPersonInfo> GetAllPersonsInfo()
        {
            List<clsPersonInfo> personInfos = new List<clsPersonInfo>();
            string query_GetAllPersonsInfo = @"Select 
                                                    [PersonID], 
                                                    [NationalNO], 
                                                    [FirstName], 
                                                    [SecondName], 
                                                    [ThirdName], 
                                                    [LastName], 
                                                    [Gender], 
                                                    [DateOfBirth], 
                                                    [Email], 
                                                    [Phone], 
                                                    [Address], 
                                                    [NationalityCountryID], 
                                                    [ImageName], 
                                                    [IsDeleted],
                                                    [DeletedAt]
                                                From Persons Where IsDeleted = 0";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query_GetAllPersonsInfo, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        personInfos.Add(MapReaderToPerson(reader));
                }
            }

            return personInfos;
        }
    }
}
