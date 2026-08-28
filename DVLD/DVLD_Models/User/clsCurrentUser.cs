using DVLD_Shared.Global_Classes;
using System.Collections.Generic;

namespace DVLD_Models.User
{
    public static class clsCurrentUser
    {
        public static int UserID { set; get; }
        public static string UserName { set; get; }
        public static List<int> Permissions { get; set; }

        public static bool HasPermission(enPermissions permission)
        {
            return Permissions.Contains((int)permission);
        }
    }
}
