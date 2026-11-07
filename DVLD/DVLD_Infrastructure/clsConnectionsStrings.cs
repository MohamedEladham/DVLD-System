using System.Configuration;

namespace DVLD_Infrastructure
{
    public class clsConnectionsStrings
    {
        public static string ConnectionStringTODB_DVLD2 = ConfigurationManager.ConnectionStrings["DB_DVLD2"].ConnectionString;
    }
}
