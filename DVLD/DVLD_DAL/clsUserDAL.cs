using System;
using DVLD_Models.User;
using DVLD_Infrastructure;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DVLD_DAL
{
    public class clsUserDAL
    {
        public static bool CheckPersonIsUser(int personID)
        {
            bool isExists = false;

            string query = @"SELECT 1 From Users WHERE PersonID = @PersonID";

            using(SqlConnection conniction = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using(SqlCommand command = new SqlCommand(query, conniction))
            {
                command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = personID;

                conniction.Open();

                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        public static bool IsUserNameExists(string userName)
        {
            bool isExists = false;

            string query = @"SELECT 1 From Users WHERE UserName = @UserName";

            using (SqlConnection conniction = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, conniction))
            {
                command.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 250).Value = userName;

                conniction.Open();

                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        public static bool IsUserNameExists(string userName, int userID)
        {
            bool isExists = false;

            string query = @"SELECT 1 From Users WHERE UserName = @UserName AND UserID != @UserID";

            using (SqlConnection conniction = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, conniction))
            {
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = userID;
                command.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 250).Value = userName;

                conniction.Open();

                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        public static bool IsCurrentPasswordValid(string currentPassword, int userID)
        {
            bool isValid = false;

            string query = @"SELECT 1 From Users WHERE Password = @CurrentPassword AND UserID = @UserID";

            using (SqlConnection conniction = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, conniction))
            {
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = userID;
                command.Parameters.Add("@CurrentPassword", System.Data.SqlDbType.VarChar, 550).Value = currentPassword;

                conniction.Open();

                object result = command.ExecuteScalar();
                isValid = result != null;
            }

            return isValid;
        }

        // >>
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

        public static clsUser GetUserByID(int userID)
        {
            clsUser userInfo = null;

            string query = @"SELECT 
                                    [UserID], 
                                    [PersonID], 
                                    [UserName], 
                                    [IsActive]
                                From Users
                                Where UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = userID;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        userInfo = _MapReaderToUser(reader);
                }
            }

            return userInfo;
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

        public static bool AddNewUserAndGetNewID(clsUser user, out int newID)
        {
            newID = -1;

            string query = @"INSERT INTO Users 
                                                ([PersonID],
                                                [UserName],
                                                [Password],
                                                [IsActive])
                                        VALUES 
                                                (@PersonID,
                                                @UserName,
                                                @Password,
                                                @IsActive); 
                                        SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = user.PersonID;
                command.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 250).Value = user.UserName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 550).Value = user.Password;
                command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = user.IsActive;

                connection.Open();

                var result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    newID = Convert.ToInt32(result);
            }

            return newID > 0;
        }
        
        public static bool UpdatePassword(string newPassword, int userID)
        {
            bool isUpdate = false;

            string query = @"UPDATE Users SET Password = @NewPassword WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = userID;
                command.Parameters.Add("@NewPassword", System.Data.SqlDbType.VarChar, 550).Value = newPassword;

                connection.Open();

                isUpdate = (command.ExecuteNonQuery() > 0);
            }

            return isUpdate;
        }

        public static bool UpdateUserNameAndStatusInfo(clsUser user)
        {
            bool isUpdate = false;

            string query = @"UPDATE Users 
                                        SET
                                            [UserName]   = @UserName, 
                                            [IsActive]   = @IsActive
                                        WHERE UserID     = @UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 250).Value = user.UserName;
                command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = user.IsActive;
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = user.UserID;

                connection.Open();

                isUpdate = (command.ExecuteNonQuery() > 0);
            }

            return isUpdate;
        }
    }
}
