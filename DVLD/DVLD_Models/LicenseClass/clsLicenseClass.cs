using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Models.LicenseClass
{
    public class clsLicenseClass
    {
        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public short MinimumAllowedAge { set; get; }
        public decimal LicenseFees { set; get; }
        public short DefaultValidityLength { set; get; }
        public bool IsActive { set; get; }
    }
}
