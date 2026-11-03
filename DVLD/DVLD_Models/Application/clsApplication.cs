using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Models.Application
{
    public class clsApplication
    {
        public int ApplicationID { set; get; }
        public int PersonID { set; get; }
        public int ServiceID { set; get; }
        public int ApplicationStatusID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public decimal ApplicationPaidFees { set; get; } 
    }
}
