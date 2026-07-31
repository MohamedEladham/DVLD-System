using DVLD_DAL;
using DVLD_Models;
using DVLD_Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class clsUserBL
    {
        public static List<clsUser> GetAllUsersInfo()
        {
            return clsUserDAL.GetAllUsersInfo();
        }

        public static List<clsUserInfoGridViewDto> GetUsersForGridView()
        {
            return clsUserDAL.GetUsersForGridView();
        }
    }
}
