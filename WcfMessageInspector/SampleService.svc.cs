using System;
using WcfMessageInspector.MessageInceptor;

namespace WcfMessageInspector
{
    [LoggerServiceBehavior]
    public class SampleService : ISampleService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}
