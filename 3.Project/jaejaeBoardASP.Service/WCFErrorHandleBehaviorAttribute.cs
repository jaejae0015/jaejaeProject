using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;

namespace jaejaeBoardASP
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WCFErrorHandleBehaviorAttribute : Attribute, IServiceBehavior, IErrorHandler
    {
        protected Type ServiceType { get; set; }

        void IServiceBehavior.AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            ServiceType = serviceDescription.ServiceType;

            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                dispatcher.ErrorHandlers.Add(this);
            }
        }

        void IServiceBehavior.Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {

        }

        /// <summary>
        /// 에러 처리...에러 로깅
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        bool IErrorHandler.HandleError(Exception error)
        {
            string serverName = System.Environment.MachineName;
            //string exInfo = Log.ExceptionDbLogger.GetLogText(error);
            //Log.ExceptionDbLogger.LogExceptionToDB(serverName, exInfo);

            return false; //에러를 감추지 않고 계속...
        }

        /// <summary>
        /// 클라이언트로 전달
        /// </summary>
        /// <param name="error"></param>
        /// <param name="version"></param>
        /// <param name="fault"></param>
        void IErrorHandler.ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            //WCF.ErrorHandlerHelper.PromoteException(error, version, ref fault);
        }
    }
}