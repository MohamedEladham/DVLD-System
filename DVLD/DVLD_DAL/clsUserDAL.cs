using System;
using DVLD_Models.User;
using DVLD_Infrastructure;
using System.Data.SqlClient;
using System.Collections.Generic;
using DVLD_Models.Role;
using DVLD_Models.Permissions;

namespace DVLD_DAL
{
    public class clsUserDAL
    {
        // >> Fore Login Screen
        public static clsUser GetUserByUserNameAndPassword(string userName, string password)
        {
            clsUser userInfo = null;

            string query = @"SELECT 
                                    [UserID], 
                                    [PersonID], 
                                    [UserName],
                                    [IsActive]
                                From Users
                                WHERE 
                                    (UserName = @UserName AND
                                     Password = @Password AND
                                     IsActive = 1 AND IsDeleted = 0)";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 250).Value = userName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 550).Value = password;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        userInfo = _MapReaderToUser(reader);
                }
            }

            return userInfo;
        }

        // >> Fore Login Screen
        private static clsPermission _MapReaderToPermission(SqlDataReader reader)
        {
            return new clsPermission
            {
                PermissionID = (int)reader["PermissionID"],
                PermissionName = (string)reader["PermissionName"],
            };
        }
        public static List<clsPermission> GetUserPermissions(int userID)
        {
            List<clsPermission> permissions = new List<clsPermission>();

            string query = @"SELECT 
		                            P.PermissionID,
		                            P.PermissionName
		                            FROM UserRoles UR
		                            INNER JOIN RolePermissions RP 
		                            ON UR.FK_RoleID = RP.FK_RoleID
		                            INNER JOIN Permissions P 
		                            ON RP.FK_PermissionID = P.PermissionID
		                            WHERE UR.FK_UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = userID;

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        permissions.Add(_MapReaderToPermission(reader));
                }
            }

            return permissions;
        }



        // >>
        public static bool CheckPersonIsUser(int personID)
        {
            bool isExists = false;

            string query = @"SELECT 1 From Users WHERE PersonID = @PersonID AND IsDeleted = 0";

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

        public static bool AuthenticateUser(string userName, string password)
        {
            bool isAuthenticated = false;

            string query = @"SELECT 1 From Users 
                                            WHERE 
                                            (UserName = @UserName AND
                                             Password = @Password AND
                                             IsActive = 1 AND
                                             IsDeleted = 0)";

            using (SqlConnection conniction = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, conniction))
            {
                command.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 250).Value = userName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 550).Value = password;

                conniction.Open();

                object result = command.ExecuteScalar();
                isAuthenticated = result != null;
            }

            return isAuthenticated;
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

        
        
        // >>
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

        public static List<clsUserInfoGridViewDto> GetActiveUsersForGridView()
        {
            List<clsUserInfoGridViewDto> activeUsers = new List<clsUserInfoGridViewDto>();

            string query = @"SELECT 
                                    U.UserID, 
                                    U.PersonID, 
                                    U.UserName, 
                                    P.FirstName, 
                                    P.SecondName, 
                                    P.ThirdName, 
                                    P.LastName, 
                                    U.IsActive 
                                FROM Users U
                                INNER JOIN Persons P 
                                ON U.PersonID = P.PersonID 
                                AND U.IsActive = 1 
                                AND U.IsDeleted = 0 
                                ORDER BY U.UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsUserInfoGridViewDto user = _MapReaderToUserGridViewDto(reader);
                        activeUsers.Add(user);
                    }
                }
            }

            return activeUsers;
        }


        // >>
        public static List<clsUserInfoGridViewDto> GetInActiveUsersForGridView()
        {
            List<clsUserInfoGridViewDto> inActiveUsers = new List<clsUserInfoGridViewDto>();

            string query = @"SELECT 
                                    U.UserID, 
                                    U.PersonID, 
                                    U.UserName, 
                                    P.FirstName, 
                                    P.SecondName, 
                                    P.ThirdName, 
                                    P.LastName, 
                                    U.IsActive
                                FROM Users U 
                                INNER JOIN Persons P 
                                ON U.PersonID = P.PersonID
                                AND U.IsActive = 0
                                AND U.IsDeleted = 0
                                ORDER BY U.UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsUserInfoGridViewDto user = _MapReaderToUserGridViewDto(reader);
                        inActiveUsers.Add(user);
                    }
                }
            }

            return inActiveUsers;
        }

        
        
        // >>
        private static clsDeleteUserInfoGridViewDto _MapReaderToDeletedUserGridViewDto(SqlDataReader reader)
        {
            return new clsDeleteUserInfoGridViewDto
            {
                UserID = (int)reader["UserID"],
                PersonID = (int)reader["PersonID"],
                UserName = (string)reader["UserName"],
                FullName = Convert.ToString(reader["FirstName"] + " " + reader["SecondName"] + " " + reader["ThirdName"] + " " + reader["LastName"]),
                IsActive = (bool)reader["IsActive"],
                IsDeleted = (bool)reader["IsDeleted"],
                DeletedAt = reader.IsDBNull(reader.GetOrdinal("DeletedAt")) ? null : (DateTime?)reader["DeletedAt"]
            };
        }

        public static List<clsDeleteUserInfoGridViewDto> GetDeletedUsersForGridView()
        {
            List<clsDeleteUserInfoGridViewDto> users = new List<clsDeleteUserInfoGridViewDto>();

            string query = @"SELECT 
                                    U.UserID, 
                                    U.PersonID, 
                                    U.UserName, 
                                    P.FirstName, 
                                    P.SecondName, 
                                    P.ThirdName, 
                                    P.LastName, 
                                    U.IsActive,
                                    U.IsDeleted,
                                    U.DeletedAt
                                FROM Users U 
                                INNER JOIN Persons P 
                                ON  U.PersonID = P.PersonID 
                                AND U.IsDeleted = 1
                                ORDER BY U.UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsDeleteUserInfoGridViewDto user = _MapReaderToDeletedUserGridViewDto(reader);
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        
        
        // >>
        public static bool AddNewUserAndRole(clsUser user, int roleID, out int newUserID)
        {
            newUserID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertUserQuery = @"INSERT INTO Users 
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

                        using (SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, connection, transaction))
                        {
                            insertUserCommand.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = user.PersonID;
                            insertUserCommand.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 250).Value = user.UserName;
                            insertUserCommand.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 550).Value = user.Password;
                            insertUserCommand.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = user.IsActive;

                            var result = insertUserCommand.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                                newUserID = Convert.ToInt32(result);
                        }

                        if (roleID > 0 && newUserID > 0)
                        {
                            string insertUserRoleQuery = @"INSERT INTO UserRoles ([FK_UserID], [FK_RoleID]) VALUES (@UserID, @RoleID)";

                            using (SqlCommand insertUserRoleCommand = new SqlCommand(insertUserRoleQuery, connection, transaction))
                            {
                                insertUserRoleCommand.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = newUserID;
                                insertUserRoleCommand.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = roleID;

                                insertUserRoleCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        // >>
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

        
        public static bool UpdateUserPassword(string newPassword, int userID)
        {
            bool isUpdate = false;

            string query = @"UPDATE Users SET Password = @NewPassword WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@NewPassword", System.Data.SqlDbType.VarChar, 550).Value = newPassword;
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = userID;

                connection.Open();

                isUpdate = (command.ExecuteNonQuery() > 0);
            }

            return isUpdate;
        }

        public static bool ActivateUser(int userID)
        {
            bool isRestored = false;

            string query = @"Update Users 
                                        Set 
		                                IsActive = 1
		                                Where UserID = @UserID AND IsActive = 0 AND IsDeleted = 0";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = userID;

                connection.Open();

                isRestored = (command.ExecuteNonQuery() > 0);
            }

            return isRestored;
        }

        public static bool SoftDeleteUser(int userID)
        {
            bool isDeleted = false;

            string query = @"UPDATE Users 
                                        SET
                                            [IsActive]   = 0,
                                            [IsDeleted]  = 1,
                                            [DeletedAt]  = GETDATE()
                                        WHERE UserID     = @UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = userID;

                connection.Open();

                isDeleted = (command.ExecuteNonQuery() > 0);
            }

            return isDeleted;
        }

        public static bool RestoreUser(int userID)
        {
            bool isRestored = false;

            string query = @"Update Users 
                                        Set 
		                                IsActive = 0,
		                                IsDeleted = 0,
		                                DeletedAt = null
		                                Where UserID = @UserID AND IsActive = 0 AND IsDeleted = 1";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = userID;

                connection.Open();

                isRestored = (command.ExecuteNonQuery() > 0);
            }

            return isRestored;
        }
    }
}
