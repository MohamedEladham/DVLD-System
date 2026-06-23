using DVLD_DAL;
using DVLD_Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DVLD_BL
{
    public class clsPersonBL
    {
        public static bool ContainsPersonID(int personID, string outValue)
        {
            if (int.TryParse(outValue, out int id))
                return personID == id;

            return false;
        }

        // >>

        private static int _CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now.Date < birthDate.AddYears(age))
                age--;

            return age;
        }
        
        private static string _GetCountryName(int? countryID, Dictionary<int, clsCountryInfo> countriesCache)
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

        public static List<clsPersonInfoGridViewDto> GetPersonsForGridView()
        {
            List<clsPersonInfoGridViewDto> personsGridViewDto = null;
            List<clsPersonInfo> personInfos = clsPersonDAL.GetAllPersonsInfo();

            if (personInfos != null && personInfos.Count > 0)
            {
                Dictionary<int, clsCountryInfo> countriesCache = clsCountryBL.LoadCountriesToDictionary();
                
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
    }
}
