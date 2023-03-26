using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.Helpers
{
    static public class GuidHelper
    {
        static public string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
