using DVLD_Models.Permissions;
using DVLD_Models.Roles;
using DVLD_Shared.Global_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BL.Services
{
    public class clsPermissionsFilterService
    {
        public static Dictionary<string, Func<clsPermission, string, bool>> GetPermissionsFilters()
        {
            Dictionary<string, Func<clsPermission, string, bool>> permissionsFilter = null;

            permissionsFilter = new Dictionary<string, Func<clsPermission, string, bool>>
            {
                ["PermissionID"] = (P, val) => clsValidationHelper.IsMatchingID(P.PermissionID, val),
                ["PermissionName"] = (P, val) => clsValidationHelper.ContainsIgnoreCase(P.PermissionName, val),
                ["PermissionCategory"] = (P, val) => clsValidationHelper.ContainsIgnoreCase(P.PermissionCategory, val)
            };

            return permissionsFilter;
        }

        public static List<clsPermission> PermissionsFilters( 
            List<clsPermission> permissions,
            Dictionary<string, Func<clsPermission, string, bool>> permissionsFilter,
            string filterSelected,
            string searchValue)
        {
            if (permissions == null) return null;

            return permissions.Where(P => permissionsFilter[filterSelected](P, searchValue)).ToList();
        }
    }
}
