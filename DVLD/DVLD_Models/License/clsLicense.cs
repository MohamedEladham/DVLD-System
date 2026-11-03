using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Models.License
{
    public class clsLicense
    {
        public int LicenseID { set; get; }
        
        public int LicenseNumber { set; get; }
        
        public int ApplicationID { set; get; }
        
        public int PersonID { set; get; }
        
        public int LicenseClassID { set; get; }
        
        public DateTime IssueDate { set; get; }
        
        public DateTime Date { set; get; }
        
        public string IssueReasonID { set; get; }
        
        public bool IsActive { set; get; }
    }
}
