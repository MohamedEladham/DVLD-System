using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Helpers
{
    public class clsStringHelpers
    {
        public static bool ContainsIgnoreCase(string source, string value)
        {
            return !string.IsNullOrEmpty(source) && source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
