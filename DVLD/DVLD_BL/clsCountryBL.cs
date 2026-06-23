using DVLD_DAL;
using DVLD_Models;
using System.Collections.Generic;
using System.Linq;

namespace DVLD_BL
{
    public class clsCountryBL
    {
        public static Dictionary<int, clsCountryInfo> LoadCountriesToDictionary()
        {
            Dictionary<int, clsCountryInfo> countriesCache = null;

            List<clsCountryInfo> countries = clsCountryDAL.GetAllCountries();
            
            if (countries != null)
                countriesCache = countries.ToDictionary(c => c.CountryID, c => c);

            return countriesCache;
        }
    }
}
