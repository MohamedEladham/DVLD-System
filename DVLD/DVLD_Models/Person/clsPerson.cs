using System;

namespace DVLD_Models
{
    public class clsPerson
    {
        public int PersonID { set; get; }
        public string NationalNO { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public char Gender { set; get; }
        public DateTime DateOfBirth { set; get; }
        public int? NationalityCountryID { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public string ImageName { set; get; }

        // Soft Delete Fields
        public bool IsDeleted { set; get; }
        public DateTime? DeletedAt { set; get; }
    }
}
