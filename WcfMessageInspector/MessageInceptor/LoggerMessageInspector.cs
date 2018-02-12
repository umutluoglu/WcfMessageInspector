using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WcfMessageInspector.MessageInceptor
{
    public class LoggerMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();
            
            var soapRequest = string.Empty;
            XDocument doc;

            using (var ms = new MemoryStream())
            {
                var writer = XmlWriter.Create(ms);
                request.WriteMessage(writer);
                writer.Flush();
                ms.Position = 0;

                doc = XDocument.Load(ms);
                //get request body
                soapRequest = doc.ToString();
            }
            
            //To preserve request, we should re-assign message to request parameter
            request = buffer.CreateMessage();
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var buffer = reply.CreateBufferedCopy(Int32.MaxValue);
            reply = buffer.CreateMessage();

            var soapResponse = string.Empty;
            XDocument doc;

            using (var ms = new MemoryStream())
            {
                var writer = XmlWriter.Create(ms);
                reply.WriteMessage(writer);
                writer.Flush();
                ms.Position = 0;

                doc = XDocument.Load(ms);
                soapResponse = doc.ToString();
            }

            reply = buffer.CreateMessage();
        }
    }
}