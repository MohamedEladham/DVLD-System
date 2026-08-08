using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BL.Validations
{
    public class clsValidationResult
    {
        public int ID { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
