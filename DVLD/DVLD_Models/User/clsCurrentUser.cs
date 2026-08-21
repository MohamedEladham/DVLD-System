using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Models.User
{
    public static class clsCurrentUser
    {
        public static int UserID { set; get; }
        public static string UserName { set; get; }
        public static List<int> Permissions { get; set; }
    }
}
