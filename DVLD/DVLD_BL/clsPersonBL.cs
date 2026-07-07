using System;
using DVLD_DAL;
using DVLD_Models;
using DVLD_Shared;
using System.Linq;
using DVLD_Shared.Validation_Messages;
using DVLD_Shared.Operations_Result;
using System.Collections.Generic;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_BL.Validations;

namespace DVLD_BL
{
    public class clsPersonBL
    {
        private static int _CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now.Date < birthDate.AddYears(age))
                age--;

            return age;
        }

        private static string _GetCountryName(int? countryID, Dictionary<int, clsCountry> countriesCache)
        {
            if (countriesCache == null)
                return "N/A";

            return (countryID.HasValue && countriesCache.ContainsKey(countryID.Value)) ? countriesCache[countryID.Value].CountryName : "N/A";
        }

        private static string _GetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return "N/A";

            return email;
        }

        private static string _GetAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                return "N/A";

            return address;
        }

        public static List<clsPersonInfoGridViewDto> GetPersonsForGridView(List<clsPerson> personInfos,
            Dictionary<int, clsCountry> countriesCache)
        {
            List<clsPersonInfoGridViewDto> personsGridViewDto = null;

            if (personInfos != null && personInfos.Count > 0)
            {
                personsGridViewDto = personInfos.Select(P => new clsPersonInfoGridViewDto
                {
                    PersonID = P.PersonID,
                    NationalNO = P.NationalNO,
                    FirstName = P.FirstName,
                    SecondName = P.SecondName,
                    ThirdName = P.ThirdName,
                    LastName = P.LastName,
                    Gender = P.Gender,
                    Age = _CalculateAge(P.DateOfBirth),
                    CountryName = _GetCountryName(P.NationalityCountryID, countriesCache),
                    Email = _GetEmail(P.Email),
                    Phone = P.Phone,
                    Address = _GetAddress(P.Address),
                    IsDeleted = P.IsDeleted

                }).ToList();
            }

            return personsGridViewDto;
        }
       
        public static (clsOperationResult, clsPerson) GetPersonByID(int personID)
        {
            if (personID <= 0)
                return (new clsOperationResult { Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.InvalidPersonIDMessage }, null);

            try
            {
                clsPerson person = clsPersonDAL.GetPersonByID(personID);

                if(person != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, person);
                else
                    return (new clsOperationResult { Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonNotFoundMessage } , null);
            }
            catch (Exception)
            {
                return (new clsOperationResult { Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage } , null);
            }
        }

        public static List<clsPerson> GetAllPersonsInfo()
        {
            return clsPersonDAL.GetAllPersonsInfo();
        }

        public static clsOperationResult AddNewPerson(clsPerson person)
        {
            if (person == null) 
                return new clsOperationResult { Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.PersonInfoRequiredMessage };

            try
            {
                bool isAdded = clsPersonDAL.AddNewPersonAndGetNewID(person, out int newID);

                if (isAdded)
                    return new clsOperationResult { Status = enOperationStatus.Success,
                        Message = clsPersonValidationMessages.PersonAddedSuccessfullyMessage, CreatedID = newID };
                else
                    return new clsOperationResult{ Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonAddFailedMessage};
            }
            catch (Exception)
            {
                return new clsOperationResult { Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage };
            }
        }

        public static clsOperationResult UpdatePersonInfo(clsPerson person)
        {
            if (person == null)
                return new clsOperationResult { Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.PersonInfoRequiredMessage };

            try
            {
                bool isUpdated = clsPersonDAL.UpdatePersonInfo(person);

                if (isUpdated)
                    return new clsOperationResult{ Status = enOperationStatus.Success,
                        Message = clsPersonValidationMessages.PersonUpdatedSuccessfullyMessage };
                else
                    return new clsOperationResult { Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonUpdatedFailedMessage };
            }
            catch (Exception)
            {
                return new clsOperationResult { Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage };
            }
        }
    }
}
