using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jaejaeBoardASP.Common
{
    public class RequireAuthenticationAttribute : Attribute
    {
        public readonly bool RequireAuthentication = false;

        public RequireAuthenticationAttribute(bool value)
        {
            RequireAuthentication = value;
        }
    }
}