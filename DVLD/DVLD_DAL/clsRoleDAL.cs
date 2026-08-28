using DVLD_Models.Role;
using DVLD_Infrastructure;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace DVLD_DAL
{
    public class clsRoleDAL
    {
        private static clsRole _MapReaderToRole(SqlDataReader reader)
        {
            return new clsRole
            {
                RoleID = (int)reader["RoleID"],
                RoleName = (string)reader["RoleName"],
            };
        }

        public static List<clsRole> GetAllRoles()
        {
            List<clsRole> roles = new List<clsRole>();

            string query = @"SELECT R.RoleID, R.RoleName FROM Roles R ORDER BY R.RoleID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsRole user = _MapReaderToRole(reader);
                        roles.Add(user);
                    }
                }
            }
            return roles;
        }

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
    }
}
