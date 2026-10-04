using DVLD_Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsUserRolesDAL
    {
        public static bool IsRoleUsedInAnyUser(int roleID)
        {
            bool isExists = false;

            string query = @"SELECT 1 
                                    From UserRoles UR 
		                            INNER JOIN Users U
		                            ON UR.FK_UserID = U.UserID 
                                    AND U.IsDeleted = 0
		                            WHERE UR.FK_RoleID = @RoleID";

            using (SqlConnection conniction = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, conniction))
            {
                command.Parameters.Add("@RoleID", System.Data.SqlDbType.Int).Value = roleID;

                conniction.Open();

                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        public static List<string> GetUserNamesByRoleID(int roleID)
        {
            List<string> userNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            {
                string query = @"SELECT 
                                        U.UserName
                                        FROM UserRoles UR
                                        INNER JOIN Users U
                                        ON UR.FK_UserID = U.UserID
                                        AND U.IsDeleted = 0
                                        WHERE UR.FK_RoleID = @RoleID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            userNames.Add(reader["UserName"].ToString());
                    }
                }
            }

            return userNames;
        }
    }
}
