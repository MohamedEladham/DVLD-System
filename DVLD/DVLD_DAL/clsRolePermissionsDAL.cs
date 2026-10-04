using DVLD_Infrastructure;
using DVLD_Models.Permissions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsRolePermissionsDAL
    {
        public static bool IsPermissionUsedInAnyRole(int permissionID) 
        {
            bool isExists = false;

            string query = @"SELECT 1 From RolePermissions WHERE FK_PermissionID = @PermissionID";

            using (SqlConnection conniction = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, conniction))
            {
                command.Parameters.Add("@PermissionID", System.Data.SqlDbType.Int).Value = permissionID;

                conniction.Open();

                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }


        // >>

        public static List<string> GetRoleNamesByPermissionID(int permissionID)
        {
            List<string> roleNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                string query = @"SELECT 
		                                R.RoleName
		                                FROM RolePermissions RP 
		                                INNER JOIN Roles R
		                                ON RP.FK_RoleID = R.RoleID
		                                AND R.IsDeleted = 0
		                                WHERE RP.FK_PermissionID = @PermissionID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@PermissionID", SqlDbType.Int).Value = permissionID;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            roleNames.Add(reader["RoleName"].ToString());
                    }
                }
            }

            return roleNames;
        }


        // >>
        public static List<int> GetRolePermissionIDs(int roleID)
        {
            List<int> rolePermissionIDs = new List<int>();

            string query = @"SELECT 
		                            P.PermissionID
		                            FROM RolePermissions RP 
		                            INNER JOIN Permissions P 
		                            ON RP.FK_PermissionID = P.PermissionID
		                            WHERE RP.FK_RoleID = @RoleID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = roleID;

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        rolePermissionIDs.Add((int)reader["PermissionID"]);
                }
            }

            return rolePermissionIDs;
        }

        public static List<string> GetRolePermissionNames(int roleID)
        {
            List<string> rolePermissionNames = new List<string>();

            string query = @"SELECT 
		                            P.PermissionName
		                            FROM RolePermissions RP 
		                            INNER JOIN Permissions P 
		                            ON RP.FK_PermissionID = P.PermissionID
		                            WHERE RP.FK_RoleID = @RoleID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = roleID;

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        rolePermissionNames.Add((string)reader["PermissionName"]);
                }
            }

            return rolePermissionNames;
        }

        // >>
        private static clsPermission _MapReaderToPermission(SqlDataReader reader)
        {
            return new clsPermission
            {
                PermissionID = (int)reader["PermissionID"],
                PermissionName = (string)reader["PermissionName"]
            };
        }

        public static List<clsPermission> GetRolePermissionsByRoleID(int roleID)
        {
            List<clsPermission> permissions = new List<clsPermission>();

            string query = @"SELECT 
		                            P.PermissionID,
		                            P.PermissionName
		                            FROM RolePermissions RP 
		                            INNER JOIN Permissions P 
		                            ON RP.FK_PermissionID = P.PermissionID
		                            WHERE RP.FK_RoleID = @RoleID 
                                    ORDER BY P.PermissionName";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = roleID;

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        permissions.Add(_MapReaderToPermission(reader));
                }
            }

            return permissions;
        }
    }
}
