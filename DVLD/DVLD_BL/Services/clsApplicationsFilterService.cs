using DVLD_Models;
using DVLD_Models.Application;
using DVLD_Shared.Global_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BL.Services
{
    public class clsApplicationsFilterService
    {
        public static Dictionary<string, Func<clsApplicationGridViewDto, string, bool>> GetApplicationFilters()
        {
            Dictionary<string, Func<clsApplicationGridViewDto, string, bool>> applicationFilter = null;

            applicationFilter = new Dictionary<string, Func<clsApplicationGridViewDto, string, bool>>
            {
                ["ApplicationID"] = (A, val) => clsValidationHelper.IsMatchingID(A.ID, val),
                ["PersonName"] = (A, val) => clsValidationHelper.ContainsIgnoreCase(A.PersonName, val),
                ["NationalNO"] = (A, val) => clsValidationHelper.ContainsIgnoreCase(A.NationalNo, val),
                ["ServiceName"] = (A, val) => clsValidationHelper.ContainsIgnoreCase(A.ServiceName, val),
                ["ApplicationStatus"] = (A, val) => clsValidationHelper.ContainsIgnoreCase(A.Status, val),
                ["ApplicationDate"] = (A, val) => clsValidationHelper.ContainsIgnoreCase(Convert.ToString(A.ApplicationDate), val)
            };

            return applicationFilter;
        }


        public static List<clsApplicationGridViewDto> ApplicationsFilters(List<clsApplicationGridViewDto> applicatioGridViewDto,
            Dictionary<string, Func<clsApplicationGridViewDto, string, bool>> applicationFilter, string filterSelected, string searchValue)
        {
            if (applicatioGridViewDto == null) return null;

            return applicatioGridViewDto.Where(a => applicationFilter[filterSelected](a, searchValue)).ToList();
        }

    }
}
