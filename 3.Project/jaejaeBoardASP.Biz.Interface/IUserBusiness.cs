using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ServiceModel;

namespace jaejaeBoardASP.Biz.Interface
{
    public interface IUserBusiness : IDisposable
    {
        new void Dispose();
        [OperationContract]
        DataTable GETUSERLIST_PROC(string pStrSearchText);

    }
}
