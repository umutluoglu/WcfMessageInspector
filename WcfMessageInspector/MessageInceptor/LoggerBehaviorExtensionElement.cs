using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace WcfMessageInspector.MessageInceptor
{
    public class LoggerBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new LoggerEndpointBehavior();
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(LoggerEndpointBehavior);
            }
        }
    }
}