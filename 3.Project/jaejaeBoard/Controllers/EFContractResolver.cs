using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json.Serialization;

namespace jaejaeBoard.Controllers
{
    public class EFContractResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            if (objectType.FullName.StartsWith("System.Data.Entity.DynamicProxies."))
            {
                var members = base.GetSerializableMembers(objectType);
                members.RemoveAll(memberInfo => memberInfo.Name == "_entityWrapper" || memberInfo.Module.ScopeName == "EntityProxyModule"); return members;
            }
            return base.GetSerializableMembers(objectType);
        }
    }
}