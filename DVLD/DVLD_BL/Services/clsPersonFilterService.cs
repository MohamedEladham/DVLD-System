using System;
using DVLD_Models;
using System.Linq;
using DVLD_Shared.Global_Classes;
using System.Collections.Generic;
using DVLD_Models.Person;

namespace DVLD_BL.Services
{
    public class clsPersonFilterService
    {
        public static Dictionary<string, Func<clsActivePersonsInfoGridViewDto, string, bool>> GetPersonFilters()
        {
            Dictionary<string, Func<clsActivePersonsInfoGridViewDto, string, bool>> personFilter = null;

            personFilter = new Dictionary<string, Func<clsActivePersonsInfoGridViewDto, string, bool>>
            {
                ["PersonID"] = (p, val) => clsValidationHelper.IsMatchingID(p.PersonID, val),
                ["NationalNO"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.NationalNO, val),
                ["FirstName"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.FirstName, val),
                ["SecondName"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.SecondName, val),
                ["ThirdName"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.ThirdName, val),
                ["LastName"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.LastName, val),
                ["Gender"] = (p, val) => val.Length == 1 && p.Gender.ToString().Equals(val, StringComparison.OrdinalIgnoreCase),
                ["Email"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.Email, val),
                ["Phone"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.Phone, val)
            };

            return personFilter;
        }


        public static List<clsActivePersonsInfoGridViewDto> FilterPersons(List<clsActivePersonsInfoGridViewDto> personsGridViewDto,
            Dictionary<string, Func<clsActivePersonsInfoGridViewDto, string, bool>> personFilter, string filterSelected, string searchValue)
        {
            if (personsGridViewDto == null) return null;

            return personsGridViewDto.Where(p => personFilter[filterSelected](p, searchValue)).ToList(); 
        }

        
        // >>

        public static Dictionary<string, Func<clsDeletedPersonInfoGridViewDto, string, bool>> GetDeletedPersonFilters()
        {
            Dictionary<string, Func<clsDeletedPersonInfoGridViewDto, string, bool>> personFilter = null;

            personFilter = new Dictionary<string, Func<clsDeletedPersonInfoGridViewDto, string, bool>>
            {
                ["PersonID"] = (p, val) => clsValidationHelper.IsMatchingID(p.PersonID, val),
                ["NationalNO"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.NationalNO, val),
                ["FirstName"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.FirstName, val),
                ["SecondName"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.SecondName, val),
                ["ThirdName"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.ThirdName, val),
                ["LastName"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.LastName, val),
                ["Gender"] = (p, val) => val.Length == 1 && p.Gender.ToString().Equals(val, StringComparison.OrdinalIgnoreCase),
                ["Email"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.Email, val),
                ["Phone"] = (p, val) => clsValidationHelper.ContainsIgnoreCase(p.Phone, val)
            };

            return personFilter;
        }

        public static List<clsDeletedPersonInfoGridViewDto> FilterDeletedPersons(List<clsDeletedPersonInfoGridViewDto> personsGridViewDto, 
            Dictionary<string, Func<clsDeletedPersonInfoGridViewDto, string, bool>> personFilter, string filterSelected, string searchValue)
        {
            if (personsGridViewDto == null) return null;

            return personsGridViewDto.Where(p => personFilter[filterSelected](p, searchValue)).ToList(); 
        }
    }
}
