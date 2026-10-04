using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Models.Role
{
    public class clsRole
    {
        public int RoleID { set; get; }
        public string RoleName { set; get; }
        public string Description { set; get; } 
        public bool IsDeleted { set; get; }
        public DateTime? DeletedAt { set; get; }
    }
}
