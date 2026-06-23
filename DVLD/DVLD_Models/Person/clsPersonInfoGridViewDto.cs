
namespace DVLD_Models
{
    public class clsPersonInfoGridViewDto
    {
        public int PersonID { set; get; }
        public string NationalNO { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public char Gender { set; get; }
        public int Age { set; get; }
        public string CountryName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }

        // Soft Delete Fields
        public bool IsDeleted { set; get; }
    }
}
