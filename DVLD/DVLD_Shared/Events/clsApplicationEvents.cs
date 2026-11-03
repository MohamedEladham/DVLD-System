using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Events
{
    public static class clsApplicationEvents
    {
        public static event Action<int> ApplicationCreated;

        public static void RaiseApplicationCreated(int applicationID)
        {
            ApplicationCreated?.Invoke(applicationID);
        }




    }
}
