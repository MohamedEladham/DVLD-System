using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Global_Enums
{
    public class clsEnumHelpers
    {
        public enum enAddUpdateMode
        { 
            AddNewInfo = 1,
            UpdateInfo = 2
        };

        public enum enPersonStatus
        {
            Active = 1,
            NotActive = 2
        }

        public enum enApplicationStatuses
        {
            All = -1,
            New = 1,
            Cancelled = 2,
            Completed = 3
        } 

        public enum enServices
        {
            FirstTimeLicenseIssuance = 1,
            RenewTest = 2,
            RenewDrivingLicense = 3,
            ReplacementLostLicense = 4,
            ReplaceDamagedLicense = 5,
            ReleaseDrivingLicenseHold = 6,
            InternationalLicense = 8
        }
    }
}
