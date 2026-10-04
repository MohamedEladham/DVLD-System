using DVLD_Models.Role;
using DVLD_Infrastructure;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using DVLD_Models.User;
using DVLD_Models;
using DVLD_Models.Roles;

namespace DVLD_DAL
{
    public class clsRoleDAL
    {
        public static bool IsRoleNameNotExists(string roleName)
        {
            bool isExists = false;

            string query = @"SELECT 1 From Roles WHERE RoleName = @RoleName";

            using (SqlConnection conniction = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, conniction))
            {
                command.Parameters.Add("@RoleName", System.Data.SqlDbType.NVarChar, 250).Value = roleName;

                conniction.Open();

                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        public static bool IsRoleNameNotExists(string roleName, int roleID)
        {
            bool isExists = false;

            string query = @"SELECT 1 From Roles WHERE RoleName = @RoleName AND RoleID != @RoleID";

            using (SqlConnection conniction = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, conniction))
            {
                command.Parameters.Add("@RoleName", System.Data.SqlDbType.NVarChar, 250).Value = roleName;
                command.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = roleID;

                conniction.Open();

                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }


        // >>
        public static List<string> GetRoleNamesByUserID(int userID)
        {
            List<string> roleNames = new List<string>();

            string query = @"SELECT 
		                            R.RoleName
		                            FROM UserRoles UR 
		                            INNER JOIN Roles R 
		                            ON UR.FK_RoleID = R.RoleID
		                            WHERE UR.FK_UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = userID;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        roleNames.Add((string)reader["RoleName"]);
                }
            }

            return roleNames;
        }



        // >>
        private static clsRole _MapReaderToRole(SqlDataReader reader)
        {
            return new clsRole
            {
                RoleID = (int)reader["RoleID"],
                RoleName = (string)reader["RoleName"],
                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (string)reader["Description"],
                IsDeleted = (bool)reader["IsDeleted"]
            };
        }

        public static List<clsRole> GetAllRoles()
        {
            List<clsRole> roles = new List<clsRole>();

            string query = @"SELECT R.RoleID, R.RoleName, R.Description, R.IsDeleted FROM Roles R ORDER BY R.RoleID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsRole role = _MapReaderToRole(reader);
                        roles.Add(role);
                    }
                }
            }
            return roles;
        }


        // >>
        public static clsRole GetRoleByRoleID(int roleID)
        {
            clsRole role = null;

            string query = @"SELECT 
                                    [RoleID], 
                                    [RoleName], 
                                    [Description],
                                    [IsDeleted]
                                FROM Roles
                                WHERE RoleID = @RoleID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = roleID;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        role = _MapReaderToRole(reader);
                }
            }

            return role;
        }



        // >>
        private static clsActiveRolesInfoGridViewDto _MapReaderToActiveRole(SqlDataReader reader)
        {
            return new clsActiveRolesInfoGridViewDto
            {
                RoleID = (int)reader["RoleID"],
                RoleName = (string)reader["RoleName"],
                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (string)reader["Description"],
                IsDeleted = (bool)reader["IsDeleted"]
            };
        }

        public static List<clsActiveRolesInfoGridViewDto> GetActiveRoles()
        {
            List<clsActiveRolesInfoGridViewDto> activeRoles = new List<clsActiveRolesInfoGridViewDto>();

            string query = @"SELECT 
                                    R.RoleID, 
                                    R.RoleName, 
                                    R.Description, 
                                    R.IsDeleted 
                                FROM Roles R 
                                WHERE R.IsDeleted = 0 
                                ORDER BY R.RoleID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsActiveRolesInfoGridViewDto activeRole = _MapReaderToActiveRole(reader);
                        activeRoles.Add(activeRole);
                    }
                }
            }
            return activeRoles;
        }

        

        // >>
        private static clsDeleteRolesInfoGridViewDto _MapReaderToDeletedRoles(SqlDataReader reader) 
        {
            return new clsDeleteRolesInfoGridViewDto
            {
                RoleID = (int)reader["RoleID"],
                RoleName = (string)reader["RoleName"],
                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (string)reader["Description"],
                IsDeleted = (bool)reader["IsDeleted"], 
                DeletedAt = reader.IsDBNull(reader.GetOrdinal("DeletedAt")) ? null : (DateTime?)reader["DeletedAt"]
            };
        }

        public static List<clsDeleteRolesInfoGridViewDto> GetDeletedRoles()
        {
            List<clsDeleteRolesInfoGridViewDto> deletedRoles = new List<clsDeleteRolesInfoGridViewDto>();

            string query = @"SELECT 
                                    R.RoleID, 
                                    R.RoleName, 
                                    R.Description,
                                    R.IsDeleted,
                                    R.DeletedAt
                                FROM Roles R
                                WHERE R.IsDeleted = 1
                                ORDER BY R.RoleID";


            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsDeleteRolesInfoGridViewDto deletedRole = _MapReaderToDeletedRoles(reader);
                        deletedRoles.Add(deletedRole);
                    }
                }
            }
            return deletedRoles;
        }

        

        // >>
        public static bool AddNewRoleAndGetNewID(clsRole role, out int newID)
        {
            newID = -1;

            string query = @"INSERT INTO Roles ([RoleName], [Description]) VALUES (@RoleName, @Description) SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@RoleName", System.Data.SqlDbType.NVarChar, 250).Value = role.RoleName;
                command.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 550).Value = role.Description;

                connection.Open();

                var result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    newID = Convert.ToInt32(result);
            }

            return newID > 0;
        }

        public static bool AddRoleAndPermissions(clsRole role, List<int> permissionIDs, out int newRoleID)
        {
            newRoleID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                connection.Open();
                 
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertRolesQuery = @"INSERT INTO Roles ([RoleName], [Description]) VALUES (@RoleName, @Description) SELECT SCOPE_IDENTITY();";

                        using (SqlCommand insertRolesCommand = new SqlCommand(insertRolesQuery, connection, transaction))
                        {
                            insertRolesCommand.Parameters.Add("@RoleName", System.Data.SqlDbType.NVarChar, 250).Value = role.RoleName;

                            if(string.IsNullOrWhiteSpace(role.Description))
                                insertRolesCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 550).Value = DBNull.Value;
                            else
                                insertRolesCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 550).Value = role.Description;

                            var result = insertRolesCommand.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                                newRoleID = Convert.ToInt32(result);
                        }

                        if (permissionIDs != null && permissionIDs.Count > 0 && newRoleID > 0)
                        {
                            string insertRolePermissionsQuery = @"INSERT INTO RolePermissions ([FK_RoleID], [FK_PermissionID]) VALUES (@RoleID, @PermissionID)";

                            using (SqlCommand insertRolePermissionsCommand = new SqlCommand(insertRolePermissionsQuery, connection, transaction))
                            {
                                insertRolePermissionsCommand.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = newRoleID;
                                insertRolePermissionsCommand.Parameters.Add("@PermissionID", System.Data.SqlDbType.Int);

                                foreach (int permissionID in permissionIDs)
                                {
                                    insertRolePermissionsCommand.Parameters["@PermissionID"].Value = permissionID;
                                    insertRolePermissionsCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static bool UpdateRoleAndPermissions(clsRole role, List<int> permissionIDs) 
        {
            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateRoleQuery = @"UPDATE Roles
                                                            SET 
                                                            [RoleName]    = @RoleName,
                                                            [Description] = @Description 
                                                            WHERE RoleID  = @RoleID";

                        using (SqlCommand updateRoleCommand = new SqlCommand(updateRoleQuery, connection, transaction))
                        {
                            updateRoleCommand.Parameters.Add("@RoleName", System.Data.SqlDbType.NVarChar, 250).Value = role.RoleName;

                            if (string.IsNullOrWhiteSpace(role.Description))
                                updateRoleCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 550).Value = DBNull.Value;
                            else
                                updateRoleCommand.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 550).Value = role.Description;

                            updateRoleCommand.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = role.RoleID;
                            updateRoleCommand.ExecuteNonQuery();
                        }

                        // >>

                        string deleteRolePermissonsQuery = @"DELETE FROM RolePermissions WHERE FK_RoleID = @RoleID";

                        using (SqlCommand deleteRolePermissionsCommand = new SqlCommand(deleteRolePermissonsQuery, connection, transaction))
                        {
                            deleteRolePermissionsCommand.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = role.RoleID;
                            deleteRolePermissionsCommand.ExecuteNonQuery();
                        }

                        // >>

                        if (permissionIDs != null && permissionIDs.Count > 0)
                        {
                            string insertRolePermissionsQuery = @"INSERT INTO RolePermissions ([FK_RoleID], [FK_PermissionID]) VALUES (@RoleID, @PermissionID)";

                            using (SqlCommand insertRolePermissionsCommand = new SqlCommand(insertRolePermissionsQuery, connection, transaction))
                            {
                                insertRolePermissionsCommand.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = role.RoleID;
                                insertRolePermissionsCommand.Parameters.Add("@PermissionID", System.Data.SqlDbType.Int);

                                foreach (int permissionID in permissionIDs)
                                {
                                    insertRolePermissionsCommand.Parameters["@PermissionID"].Value = permissionID;
                                    insertRolePermissionsCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
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
        public static bool UpdateUserRoles(int userID, List<int> roleIDs)
        {
            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteQuery = @"DELETE FROM UserRoles WHERE FK_UserID = @UserID";

                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                        {
                            deleteCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                            deleteCommand.ExecuteNonQuery();
                        }

                        string insertQuery = @"INSERT INTO UserRoles (FK_UserID, FK_RoleID) VALUES (@UserID, @RoleID)";

                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction))
                        {
                            insertCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                            insertCommand.Parameters.Add("@RoleID", SqlDbType.Int);

                            foreach (int roleID in roleIDs)
                            {
                                insertCommand.Parameters["@RoleID"].Value = roleID;
                                insertCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
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
        public static bool SoftDeleteRole(int roleID)
        {
            bool isDeleted = false;

            string query = @"UPDATE Roles 
                                        SET
                                            [IsDeleted]  = 1,
                                            [DeletedAt]  = GETDATE()
                                        WHERE RoleID     = @RoleID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = roleID;

                connection.Open();

                isDeleted = (command.ExecuteNonQuery() > 0);
            }

            return isDeleted;
        }


        public static bool SoftDeleteRoleAndDeleteRolePermission(int roleID)
        {
            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string softDeleteRoleQuiry = @"UPDATE Roles SET IsDeleted = 1, DeletedAt = GETDATE() WHERE RoleID = @RoleID";

                        using (SqlCommand softDeleteRoleCommand = new SqlCommand(softDeleteRoleQuiry, connection, transaction))
                        {
                            softDeleteRoleCommand.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                            softDeleteRoleCommand.ExecuteNonQuery();
                        }

                        string deleteRolePermissionsQuery = @"DELETE FROM RolePermissions WHERE FK_RoleID = @RoleID";

                        using (SqlCommand deleteRolePermissionsCommand = new SqlCommand(deleteRolePermissionsQuery, connection, transaction))
                        {
                            deleteRolePermissionsCommand.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                            deleteRolePermissionsCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static bool RestoreRole(int roleID)
        {
            bool isRestored = false;

            string query = @"Update Roles 
                                        Set 
		                                IsDeleted = 0,
		                                DeletedAt = null
		                                Where RoleID = @RoleID AND IsDeleted = 1";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = roleID;

                connection.Open();

                isRestored = (command.ExecuteNonQuery() > 0);
            }

            return isRestored;
        }
    }
}
