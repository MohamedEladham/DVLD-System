using DVLD_Models.Roles;
using DVLD_Shared.Global_Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DVLD_BL.Services
{
    public class clsRolesFilterService
    {
        public static Dictionary<string, Func<clsActiveRolesInfoGridViewDto, string, bool>> GetActiveRolesFilters()
        {
            Dictionary<string, Func<clsActiveRolesInfoGridViewDto, string, bool>> activeRolesFilter = null;

            activeRolesFilter = new Dictionary<string, Func<clsActiveRolesInfoGridViewDto, string, bool>>
            {
                ["RoleID"] = (R, val) => clsValidationHelper.IsMatchingID(R.RoleID, val),
                ["RoleName"] = (R, val) => clsValidationHelper.ContainsIgnoreCase(R.RoleName, val),
            };

            return activeRolesFilter;
        }

        public static List<clsActiveRolesInfoGridViewDto> ActiveRolesFilters(
            List<clsActiveRolesInfoGridViewDto> activeRoleGridViewDto,
            Dictionary<string, Func<clsActiveRolesInfoGridViewDto, string, bool>> activeRolesFilter,
            string filterSelected,
            string searchValue)
        {
            if (activeRoleGridViewDto == null) return null;

            return activeRoleGridViewDto.Where(r => activeRolesFilter[filterSelected](r, searchValue)).ToList();
        }


        // >>


        public static Dictionary<string, Func<clsDeleteRolesInfoGridViewDto, string, bool>> GetDeletedRolesFilters()
        {
            Dictionary<string, Func<clsDeleteRolesInfoGridViewDto, string, bool>> deletedRolesFilter = null;

            deletedRolesFilter = new Dictionary<string, Func<clsDeleteRolesInfoGridViewDto, string, bool>>
            {
                ["RoleID"] = (R, val) => clsValidationHelper.IsMatchingID(R.RoleID, val),
                ["RoleName"] = (R, val) => clsValidationHelper.ContainsIgnoreCase(R.RoleName, val),
            };

            return deletedRolesFilter;
        }


        public static List<clsDeleteRolesInfoGridViewDto> DeletedRolesFilters(
            List<clsDeleteRolesInfoGridViewDto> deletedRoleGridViewDto,
            Dictionary<string, Func<clsDeleteRolesInfoGridViewDto, string, bool>> deletedRolesFilter,
            string filterSelected,
            string searchValue)
        {
            if (deletedRoleGridViewDto == null) return null;

            return deletedRoleGridViewDto.Where(r => deletedRolesFilter[filterSelected](r, searchValue)).ToList();
        }
    }
}
