using System;
using DVLD_DAL;
using DVLD_Models;
using DVLD_Shared;
using System.Linq;
using DVLD_Models.Person;
using System.Collections.Generic;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;
using DVLD_BL.Validations;
using DVLD_Models.Role;
using System.Reflection.Emit;

namespace DVLD_BL
{
    public class clsPersonBL
    {
        public static (clsOperationResult, DateTime?) GetPersonDateOfBirth(int personID) 
        {
            if (personID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.PersonIDMustBeGreaterThanZeroMessage
                }, null);

            try
            {
                DateTime? personDateOfBirth = clsPersonDAL.GetPersonDateOfBirth(personID);

                if (personDateOfBirth != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, personDateOfBirth);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonDateOfBirthNotFoundMessage
                    }, null);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        private static clsPersonBasicInfo _MapOriginalToPersonBasicInfo(clsPerson originalPersonInfo) 
        {
            return new clsPersonBasicInfo
            {
                PersonID = originalPersonInfo.PersonID,
                PersonName = originalPersonInfo.FirstName + " " +
                originalPersonInfo.SecondName + " " +
                originalPersonInfo.ThirdName + " " +
                originalPersonInfo.LastName,
                Age = (short)_CalculateAge(originalPersonInfo.DateOfBirth)
            };
        }

        public static (clsOperationResult, clsPersonBasicInfo) GetPersonBasicInfoByID(int personID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewPersons))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                }, null);


            if (personID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.InvalidPersonIDMessage
                }, null);

            try
            {
                clsPerson originalPersonInfo = clsPersonDAL.GetPersonBasicInfoByID(personID);

                if (originalPersonInfo != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, _MapOriginalToPersonBasicInfo(originalPersonInfo));
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonNotFoundMessage
                    }, null);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        public static (clsOperationResult, clsPerson) GetPersonByID(int personID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewPersons))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                }, null);


            if (personID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.InvalidPersonIDMessage
                }, null);

            try
            {
                clsPerson person = clsPersonDAL.GetPersonByID(personID);

                if (person != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, person);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonNotFoundMessage
                    }, null);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        public static (clsOperationResult, clsPerson) GetActivePersonByID(int personID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewPersons))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                }, null);

            if (personID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.InvalidPersonIDMessage
                }, null);

            try
            {
                clsPerson person = clsPersonDAL.GetActivePersonByID(personID);

                if (person != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, person);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonNotFoundMessage
                    }, null);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        public static (clsOperationResult, clsPerson) GetActivePersonByNationalNO(string nationalNo)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewPersons))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                clsPerson person = clsPersonDAL.GetActivePersonByNationalNO(nationalNo);

                if (person != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, person);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonNotFoundByNationalNOMessage
                    }, null);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        // >>

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

        public static (clsOperationResult, List<clsActivePersonsInfoGridViewDto>) GetAllActivePersonsForGridView(Dictionary<int, clsCountry> countriesCache)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewPersons))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                List<clsActivePersonsInfoGridViewDto> activePersonsGridViewDto = null;

                List<clsPerson> activePersons = clsPersonDAL.GetAllActivePersonsInfo();

                if (activePersons != null && activePersons.Count > 0)
                {
                    activePersonsGridViewDto = activePersons.Select(P => new clsActivePersonsInfoGridViewDto
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

                    return (new clsOperationResult {Status = enOperationStatus.Success}, activePersonsGridViewDto);
                }
                else
                    return (new clsOperationResult { Status = enOperationStatus.Success }, null);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        public static (clsOperationResult, List<clsDeletedPersonInfoGridViewDto>) GetAllDeletedPersonsForGridView(Dictionary<int, clsCountry> countriesCache)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewPersons))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                List<clsDeletedPersonInfoGridViewDto> deletedPersonsGridViewDto = null;

                List<clsPerson> deletedPersons = clsPersonDAL.GetAllDeletedPersonsInfo();

                if (deletedPersons != null && deletedPersons.Count > 0)
                {
                    deletedPersonsGridViewDto = deletedPersons.Select(P => new clsDeletedPersonInfoGridViewDto
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
                        IsDeleted = P.IsDeleted,
                        DeletedAt = P.DeletedAt
                    
                    }).ToList();

                    return (new clsOperationResult { Status = enOperationStatus.Success }, deletedPersonsGridViewDto);
                }
                else
                    return (new clsOperationResult {Status = enOperationStatus.Success}, null);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        
        // >>
        public static clsOperationResult AddNewPerson(clsPerson person)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.AddPerson))
                return new clsOperationResult{
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage,
                    PropertyName = string.Empty};

            if (person == null) 
                return new clsOperationResult { Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.PersonInfoRequiredMessage,
                    PropertyName = string.Empty
                };


            clsOperationResult validateFullNameResult = clsPersonValidations.ValidateFullName(
                person.FirstName, person.SecondName, person.ThirdName, person.LastName);

            if (validateFullNameResult.Status == enOperationStatus.Failed)
                return validateFullNameResult;


            clsOperationResult validateNationalNumberResult = 
                clsPersonValidations.ValidateNationalNumberAndCheckIsExists(person.NationalNO);

            if (validateNationalNumberResult.Status == enOperationStatus.Failed ||
                validateNationalNumberResult.Status == enOperationStatus.Exception)
                return validateNationalNumberResult;


            clsOperationResult validateEmailResult =
                clsPersonValidations.ValidateEmailAndCheckIsExists(person.Email);

            if (validateEmailResult.Status == enOperationStatus.Failed ||
                validateEmailResult.Status == enOperationStatus.Exception)
                return validateEmailResult;


            clsOperationResult validateAgeResult =
               clsPersonValidations.ValidateAgeResult(person.DateOfBirth); 

            if (validateAgeResult.Status == enOperationStatus.Failed)
                return validateAgeResult;


            clsOperationResult validatePhoneResult =
                clsPersonValidations.ValidatePhoneAndCheckIsExists(person.Phone);

            if (validatePhoneResult.Status == enOperationStatus.Failed ||
                validatePhoneResult.Status == enOperationStatus.Exception)
                return validatePhoneResult;

            clsOperationResult validateAddressResult =
                clsPersonValidations.ValidateAddressResult(person.Address);

            if (validateAddressResult.Status == enOperationStatus.Failed)
                return validateAddressResult;

            try
            {
                bool isAdded = clsPersonDAL.AddNewPersonAndGetNewID(person, out int newID);

                if (isAdded)
                    return new clsOperationResult { Status = enOperationStatus.Success,
                        Message = clsPersonValidationMessages.PersonAddedSuccessfullyMessage, CreatedID = newID };
                else
                    return new clsOperationResult{ Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonAddFailedMessage,
                        PropertyName = string.Empty
                    };
            }
            catch (Exception)
            {
                return new clsOperationResult { Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage,
                    PropertyName = string.Empty
                };
            }
        }

        public static clsOperationResult UpdatePersonInfo(clsPerson person)
        {
            if(!clsCurrentUser.HasPermission(enPermissions.UpdatePerson))
                return new clsOperationResult{ Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage,
                    PropertyName = string.Empty };

            if (person == null)
                return new clsOperationResult { Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.PersonInfoRequiredMessage,
                    PropertyName = string.Empty };


            clsOperationResult validateFullNameResult = clsPersonValidations.ValidateFullName(
                person.FirstName, person.SecondName, person.ThirdName, person.LastName);

            if (validateFullNameResult.Status == enOperationStatus.Failed)
                return validateFullNameResult;


            clsOperationResult validateEmailResult =
                clsPersonValidations.ValidateEmailAndCheckIsExists(person.Email, person.PersonID);

            if (validateEmailResult.Status == enOperationStatus.Failed ||
                validateEmailResult.Status == enOperationStatus.Exception)
                return validateEmailResult;


            clsOperationResult validateAgeResult =
               clsPersonValidations.ValidateAgeResult(person.DateOfBirth);

            if (validateAgeResult.Status == enOperationStatus.Failed)
                return validateAgeResult;


            clsOperationResult validatePhoneResult =
                clsPersonValidations.ValidatePhoneAndCheckIsExists(person.Phone, person.PersonID);

            if (validatePhoneResult.Status == enOperationStatus.Failed ||
                validatePhoneResult.Status == enOperationStatus.Exception)
                return validatePhoneResult;

            clsOperationResult validateAddressResult =
                clsPersonValidations.ValidateAddressResult(person.Address);

            if (validateAddressResult.Status == enOperationStatus.Failed)
                return validateAddressResult;

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

        public static clsOperationResult SoftDeletePerson(int personID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.DeletePerson))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                };

            if (personID <= 0)
                return new clsOperationResult {Status = enOperationStatus.Failed, 
                    Message = clsPersonValidationMessages.InvalidPersonIDMessage};

            try
            {
                bool isDelete = clsPersonDAL.SoftDeletePerson(personID);

                if(isDelete)
                    return new clsOperationResult {Status = enOperationStatus.Success, 
                        Message = clsPersonValidationMessages.PersonDeletedSuccessfullyMessage};
                else
                    return new clsOperationResult {Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonDeletedFailedMessage};
            }
            catch (Exception)
            {
                return new clsOperationResult {Status = enOperationStatus.Exception, 
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage};
            }
        }

        public static clsOperationResult RestoreDeletedPerson(int personID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.RestorePerson))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                };

            if (personID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.InvalidPersonIDMessage
                };

            try
            {
                bool isRestore = clsPersonDAL.RestoreDeletedPerson(personID);

                if (isRestore)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsPersonValidationMessages.PersonRestoredSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PersonRestoredFailedMessage
                    };
            }
            catch (Exception)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                };
            }
        }
    }
}
