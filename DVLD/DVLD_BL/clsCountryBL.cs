using DVLD_DAL;
using DVLD_Models;
using DVLD_Shared;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_BL
{
    public class clsCountryBL
    {
        public static (clsOperationResult, Dictionary<int, clsCountry>) GetAllCountriesToDictionary()
        {
            Dictionary<int, clsCountry> countriesCache = null;

            try
            {
                List<clsCountry> countries = clsCountryDAL.GetAllCountries();

                if (countries != null) countriesCache = countries.ToDictionary(c => c.CountryID, c => c);

                if (countriesCache != null)
                    return (new clsOperationResult{ Status = enOperationStatus.Success, }, countriesCache);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsCountryValidationMessages.FailedToRetrieveCountriesMessage
                    }, null);
            }
            catch(Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        
        public static (clsOperationResult, string) GetCountryNameByCountryID(int countryID)
        {
            if (countryID <= 0)
                return (new clsOperationResult { Status = clsOperationResult.enOperationStatus.Failed, 
                    Message = clsCountryValidationMessages.InvalidCountryIdMessage }, string.Empty);

            try
            {
                string countryName = clsCountryDAL.GetCountryNameByCountryID(countryID);

                if(!string.IsNullOrEmpty(countryName))
                    return (new clsOperationResult{ Status = clsOperationResult.enOperationStatus.Success }, countryName);
                else
                    return (new clsOperationResult{ Status = clsOperationResult.enOperationStatus.Failed,
                        Message = clsCountryValidationMessages.FailedToRetrieveCountriesMessage
                    }, string.Empty);
            }
            catch(Exception)
            {
                return (new clsOperationResult { Status = clsOperationResult.enOperationStatus.Exception, 
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage }, string.Empty);
            }
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
