using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Operations_Result
{
    public class clsOperationResult
    {
        public enum enOperationStatus
        {
            Success,
            Failed,
            Exception
        }

        public enOperationStatus Status { get; set; }

        public string Message { get; set; }

        public int CreatedID { get; set; }
    }
}
