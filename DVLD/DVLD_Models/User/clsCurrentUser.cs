using DVLD_Models.Permissions;
using DVLD_Shared.Global_Classes;
using System.Collections.Generic;

namespace DVLD_Models.User
{
    public static class clsCurrentUser
    {
        public static int UserID { set; get; }
        public static string UserName { set; get; }
        public static List<clsPermission> UserPermissions { get; set; } 
        
        public static bool HasPermission(enPermissions permissionID)
        {
            foreach (clsPermission permission in UserPermissions)
            {
                if (permission.PermissionID == (int)permissionID)
                    return true;
            }

            return false;
        }
    }
}
