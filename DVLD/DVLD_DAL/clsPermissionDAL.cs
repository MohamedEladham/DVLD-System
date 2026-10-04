using DVLD_Infrastructure;
using System.Data.SqlClient;
using DVLD_Models.Permissions;
using System.Collections.Generic;
using DVLD_Models.Role;
using System;
using DVLD_Models.Roles;
using DVLD_Models.User;

namespace DVLD_DAL
{
    public class clsPermissionDAL
    {
        public static bool isPermissionNameExists(string permissionName)
        {
            bool isExists = false;

            string query = "SELECT 1 FROM Permissions WHERE PermissionName = @PermissionName";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PermissionName", System.Data.SqlDbType.VarChar, 250).Value = permissionName;
                connection.Open();
                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        public static bool isPermissionNameExists(string permissionName, int permissionID)
        {
            bool isExists = false;

            string query = "SELECT 1 FROM Permissions WHERE PermissionName = @PermissionName AND PermissionID != @PermissionID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PermissionName", System.Data.SqlDbType.VarChar, 250).Value = permissionName;
                command.Parameters.Add("@PermissionID", System.Data.SqlDbType.Int).Value = permissionID;
                connection.Open();
                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }


        // >>
        private static clsPermission _MapReaderToPermission(SqlDataReader reader)
        {
            return new clsPermission
            {
                PermissionID = (int)reader["PermissionID"],
                PermissionName = (string)reader["PermissionName"],
                PermissionCategory = reader.IsDBNull(reader.GetOrdinal("PermissionCategory")) ? null : (string)reader["PermissionCategory"],
                IsActive = (bool)reader["IsActive"]
            };
        }

        public static clsPermission GetPermissionByPermissionID(int permissionID)
        {
            clsPermission permission = null;

            string query = @"SELECT 
                                    P.PermissionID,
                                    P.PermissionName,
                                    P.PermissionCategory,
                                    P.IsActive
                                    FROM Permissions P
                                    WHERE P.PermissionID = @PermissionID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PermissionID", System.Data.SqlDbType.Int).Value = permissionID;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        permission = _MapReaderToPermission(reader);
                }
            }

            return permission;
        }

        public static List<clsPermission> GetActivePermissions()
        {
            List<clsPermission> activePermissions = new List<clsPermission>();

            string query = @"SELECT 
                                    P.PermissionID,
                                    P.PermissionName,
                                    P.PermissionCategory,
                                    P.IsActive
                                    FROM Permissions P
                                    WHERE P.IsActive = 1
                                    ORDER BY P.PermissionCategory DESC, P.PermissionName DESC";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        activePermissions.Add(_MapReaderToPermission(reader));
                }
            }
            return activePermissions;
        }
       
        public static List<clsPermission> GetInActivePermissions()
        {
            List<clsPermission> inActivePermissions = new List<clsPermission>();

            string query = @"SELECT 
                                    P.PermissionID, 
                                    P.PermissionName, 
                                    P.PermissionCategory,
                                    P.IsActive
                                FROM Permissions P
                                WHERE P.IsActive = 0
                                ORDER BY P.PermissionCategory, P.PermissionName DESC";


            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        inActivePermissions.Add(_MapReaderToPermission(reader));
                }
            }
            return inActivePermissions;
        }


        // >>
        public static bool AddNewPermissionAndGetNewID(clsPermission permission, out int newID)
        {
            newID = -1;

            string query = @"INSERT INTO Permissions 
                                                    ([PermissionName],
                                                    [PermissionCategory])
                                                VALUES
                                                    (@PermissionName,
                                                    @PermissionCategory)
                                                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PermissionName", System.Data.SqlDbType.NVarChar, 250).Value = permission.PermissionName;

                if(string.IsNullOrWhiteSpace(permission.PermissionCategory))
                    command.Parameters.Add("@PermissionCategory", System.Data.SqlDbType.NVarChar, 250).Value = DBNull.Value;
                else
                    command.Parameters.Add("@PermissionCategory", System.Data.SqlDbType.NVarChar, 250).Value = permission.PermissionCategory;

                connection.Open();

                var result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    newID = Convert.ToInt32(result);
            }

            return newID > 0;
        }

        // >>
        public static bool UpdatePermissionInfo(clsPermission permission)
        {
            bool isUpdate = false;

            string query = @"UPDATE Permissions 
                                            SET
                                                [PermissionName]     = @PermissionName, 
                                                [PermissionCategory] = @PermissionCategory
                                            WHERE PermissionID       = @PermissionID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PermissionName", System.Data.SqlDbType.NVarChar, 250).Value = permission.PermissionName;

                if (string.IsNullOrWhiteSpace(permission.PermissionCategory))
                    command.Parameters.Add("@PermissionCategory", System.Data.SqlDbType.NVarChar, 250).Value = DBNull.Value;
                else
                    command.Parameters.Add("@PermissionCategory", System.Data.SqlDbType.NVarChar, 250).Value = permission.PermissionCategory;

                command.Parameters.Add("@PermissionID", System.Data.SqlDbType.Int).Value = permission.PermissionID;

                connection.Open();

                isUpdate = (command.ExecuteNonQuery() > 0);
            }

            return isUpdate;
        }

        // >>
        public static bool DisablingPermission(int permissionID)
        {
            bool isDeleted = false;

            string query = @"UPDATE Permissions 
                                            SET
                                                IsActive = 0
                                            WHERE 
                                                PermissionID = @PermissionID AND
                                                IsActive = 1";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PermissionID", System.Data.SqlDbType.Int).Value = permissionID;

                connection.Open();

                isDeleted = (command.ExecuteNonQuery() > 0);
            }

            return isDeleted;
        }

        // >>
        public static bool ActivePermission(int permissionID)
        {
            bool isRestored = false;

            string query = @"Update Permissions 
                                            Set 
		                                        IsActive = 1
		                                    WHERE
                                                PermissionID = @PermissionID AND
                                                IsActive = 0";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PermissionID", System.Data.SqlDbType.Int).Value = permissionID;

                connection.Open();

                isRestored = (command.ExecuteNonQuery() > 0);
            }

            return isRestored;
        }
    }
}
