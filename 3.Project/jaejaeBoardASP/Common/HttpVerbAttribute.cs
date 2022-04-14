using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jaejaeBoardASP.Common
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public abstract class HttpVerbAttribute : Attribute
    {
        public abstract string HttpVerb { get; }

    }
}