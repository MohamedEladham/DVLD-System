using DVLD_Helpers;
using DVLD_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class clsPersonFilterService
    {
        public static List<clsPersonInfoGridViewDto> FilterPersonToGridView(List<clsPersonInfoGridViewDto> personsGridViewDto,
            Dictionary<string, Func<clsPersonInfoGridViewDto, string, bool>> personFilter, string filterSelected, string searchValue)
        {
            return personsGridViewDto.Where(p => personFilter[filterSelected](p, searchValue)).ToList(); ;
        }

        public static Dictionary<string, Func<clsPersonInfoGridViewDto, string, bool>> GetPersonFilters()
        {
            Dictionary<string, Func<clsPersonInfoGridViewDto, string, bool>> personFilter = null;

            personFilter = new Dictionary<string, Func<clsPersonInfoGridViewDto, string, bool>>
            {
                ["PersonID"] = (p, val) => clsPersonBL.ContainsPersonID(p.PersonID, val),
                ["NationalNO"] = (p, val) => clsStringHelpers.ContainsIgnoreCase(p.NationalNO, val),
                ["FirstName"] = (p, val) => clsStringHelpers.ContainsIgnoreCase(p.FirstName, val),
                ["SecondName"] = (p, val) => clsStringHelpers.ContainsIgnoreCase(p.SecondName, val),
                ["ThirdName"] = (p, val) => clsStringHelpers.ContainsIgnoreCase(p.ThirdName, val),
                ["LastName"] = (p, val) => clsStringHelpers.ContainsIgnoreCase(p.LastName, val),
                ["Gender"] = (p, val) => val.Length == 1 && p.Gender.ToString().Equals(val, StringComparison.OrdinalIgnoreCase),
                ["Email"] = (p, val) => clsStringHelpers.ContainsIgnoreCase(p.Email, val),
                ["Phone"] = (p, val) => clsStringHelpers.ContainsIgnoreCase(p.Phone, val)
            };

            return personFilter;
        }
    }
}
