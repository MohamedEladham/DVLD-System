using DVLD_Models;
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BL.Services
{
    public class clsUserFilterService
    {
        public static Dictionary<string, Func<clsUserInfoGridViewDto, string, bool>> GetActiveAndInActiveUserFilters()
        {
            Dictionary<string, Func<clsUserInfoGridViewDto, string, bool>> userFilter = null;

            userFilter = new Dictionary<string, Func<clsUserInfoGridViewDto, string, bool>>
            {
                ["UserID"]   = (U, val) => clsValidationHelper.IsMatchingID(U.UserID, val),
                ["PersonID"] = (U, val) => clsValidationHelper.IsMatchingID(U.PersonID, val),
                ["UserName"] = (U, val) => clsValidationHelper.ContainsIgnoreCase(U.UserName, val),
                ["Name"]     = (U, val) => clsValidationHelper.ContainsIgnoreCase(U.FullName, val)
            };

            return userFilter;
        }

        public static List<clsUserInfoGridViewDto> ActiveAndInActiveUsersFilters(List<clsUserInfoGridViewDto> usersGridViewDto,
            Dictionary<string, Func<clsUserInfoGridViewDto, string, bool>> UserFilter, string filterSelected, string searchValue)
        {
            if (usersGridViewDto == null) return null;

            return usersGridViewDto.Where(p => UserFilter[filterSelected](p, searchValue)).ToList();
        }

        // >>

        public static Dictionary<string, Func<clsDeleteUserInfoGridViewDto, string, bool>> GetDeletedUserFilters()
        {
            Dictionary<string, Func<clsDeleteUserInfoGridViewDto, string, bool>> userFilter = null;

            userFilter = new Dictionary<string, Func<clsDeleteUserInfoGridViewDto, string, bool>>
            {
                ["UserID"] = (U, val) => clsValidationHelper.IsMatchingID(U.UserID, val),
                ["PersonID"] = (U, val) => clsValidationHelper.IsMatchingID(U.PersonID, val),
                ["UserName"] = (U, val) => clsValidationHelper.ContainsIgnoreCase(U.UserName, val),
                ["Name"] = (U, val) => clsValidationHelper.ContainsIgnoreCase(U.FullName, val)
            };

            return userFilter;
        }

        public static List<clsDeleteUserInfoGridViewDto> DeletedUsersFilters(List<clsDeleteUserInfoGridViewDto> deletedUsersGridViewDto,
            Dictionary<string, Func<clsDeleteUserInfoGridViewDto, string, bool>> UserFilter, string filterSelected, string searchValue)
        {
            if (deletedUsersGridViewDto == null) return null;

            return deletedUsersGridViewDto.Where(p => UserFilter[filterSelected](p, searchValue)).ToList();
        }
    }
}
