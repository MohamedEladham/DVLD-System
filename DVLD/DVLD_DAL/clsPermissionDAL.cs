using DVLD_Infrastructure;
using System.Data.SqlClient;
using DVLD_Models.Permissions;
using System.Collections.Generic;

namespace DVLD_DAL
{
    public class clsPermissionDAL
    {
        private static clsPermission _MapReaderToPermission(SqlDataReader reader)
        {
            return new clsPermission
            {
                PermissionID = (int)reader["PermissionID"],
                PermissionName = (string)reader["PermissionName"]
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
    }
}
