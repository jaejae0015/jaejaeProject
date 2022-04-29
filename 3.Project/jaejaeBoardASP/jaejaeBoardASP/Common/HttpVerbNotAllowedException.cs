using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jaejaeBoardASP.Common
{
    public class HttpVerbNotAllowedException :Exception
    {
        public HttpVerbNotAllowedException() : base("The operation does not support the request HTTP verb.") { }
    }
}