using DVLD_DAL;
using DVLD_Models;
using DVLD_Shared;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using System.Collections.Generic;
using System.Linq;

namespace DVLD_BL
{
    public class clsCountryBL
    {
        public static Dictionary<int, clsCountry> LoadCountriesToDictionary()
        {
            Dictionary<int, clsCountry> countriesCache = null;

            List<clsCountry> countries = clsCountryDAL.GetAllCountries();
            
            if (countries != null)
                countriesCache = countries.ToDictionary(c => c.CountryID, c => c);

            return countriesCache;
        }

        public static (clsOperationResult, List<clsCountry>) GetAllCountries()
        {
            try
            {
                List<clsCountry> countries = clsCountryDAL.GetAllCountries();

                if(countries != null && countries.Count > 0)
                    return (new clsOperationResult{Status = clsOperationResult.enOperationStatus.Success}, countries);
                else
                    return (new clsOperationResult{Status = clsOperationResult.enOperationStatus.Failed,
                        Message = clsCountryValidationMessages.FailedToRetrieveCountriesMessage}, null);
            }
            catch
            {
                return (new clsOperationResult { Status = clsOperationResult.enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage}, null);
            }
        }
    }
}
