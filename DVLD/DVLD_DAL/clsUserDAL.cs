using System;
using DVLD_Models;
using DVLD_Infrastructure;
using System.Data.SqlClient;
using System.Collections.Generic;
using DVLD_Models.User;

namespace DVLD_DAL
{
    public class clsUserDAL
    {
        private static clsUser _MapReaderToUser(SqlDataReader reader)
        {
            return new clsUser
            {
                UserID = (int)reader["UserID"],
                PersonID = (int)reader["PersonID"],
                UserName = (string)reader["UserName"],
                IsActive = (bool)reader["IsActive"]
            };
        }

        public static List<clsUser> GetAllUsersInfo()
        {
            List<clsUser> users = new List<clsUser>();

            string query = @"Select 
                                    [UserID], 
                                    [PersonID], 
                                    [UserName], 
                                    [IsActive] 
                            From Users";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsUser user = _MapReaderToUser(reader);
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        private static clsUserInfoGridViewDto _MapReaderToUserGridViewDto(SqlDataReader reader)
        {
            return new clsUserInfoGridViewDto
            {
                UserID = (int)reader["UserID"],
                PersonID = (int)reader["PersonID"],
                UserName = (string)reader["UserName"],
                FullName = Convert.ToString(reader["FirstName"] + " " + reader["SecondName"] + " " + reader["ThirdName"] + " " + reader["LastName"]),
                IsActive = (bool)reader["IsActive"]
            };
        }

        public static List<clsUserInfoGridViewDto> GetUsersForGridView()
        {
            List<clsUserInfoGridViewDto> users = new List<clsUserInfoGridViewDto>();

            string query = @"Select 
                                    U.UserID, 
                                    U.PersonID, 
                                    U.UserName, 
                                    P.FirstName, 
                                    P.SecondName, 
                                    P.ThirdName, 
                                    P.LastName, 
                                    U.IsActive 
                            From Users U INNER JOIN Persons P ON  U.PersonID = P.PersonID ORDER BY U.UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsUserInfoGridViewDto user = _MapReaderToUserGridViewDto(reader);
                        users.Add(user);
                    }
                }
            }

            return users;
        }
    }
}
