using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Models.Application
{
    public class clsApplicationGridViewDto
    {
        public int ID { set; get; }
        public string PersonName { set; get; }
        public string NationalNo { set; get; }
        public string ServiceName { set; get; }
        public string Status { set; get; }
        public DateTime ApplicationDate { set; get; } 
        public decimal PaidFees { set; get; }
    }
}
