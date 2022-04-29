using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Reflection;

namespace jaejaeBoardASP.Common
{
    public class OnMethodInvokeArgs : CancelEventArgs
    {
        protected internal OnMethodInvokeArgs(MethodInfo method)
        {
            Method = method;
        }

        public MethodInfo Method { get; private set; }

    }
}