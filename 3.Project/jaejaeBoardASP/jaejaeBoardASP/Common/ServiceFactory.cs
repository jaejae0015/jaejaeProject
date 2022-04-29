using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Configuration;
using System.ServiceModel.Description;

namespace jaejaeBoardASP.Common
{
    public class ServiceFactory
    {
        /// <summary>
        /// 서비스 채널 생성
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpointAddress"></param>
        /// <returns></returns>
        public static T CreateServiceChannel<T>(string endpointAddress)
        {
            var binding = new BasicHttpBinding("BasicEIRB");
            var endpoint = new EndpointAddress(endpointAddress);

            ChannelFactory<T> channelFactory = new ChannelFactory<T>(binding, endpoint);

            return channelFactory.CreateChannel();
        }

        public void Dispose()
        {

        }
    }
}