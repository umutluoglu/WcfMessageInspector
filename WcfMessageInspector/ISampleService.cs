using System;
using System.ServiceModel;

namespace WcfMessageInspector
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        string GetData(int value);
    }
}
