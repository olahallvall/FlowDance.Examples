using Microsoft.Extensions.Logging;
using System.Reflection;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Text;
using System;

namespace CarService
{
    public class Compensating : ICompensating
    {
        public void Compensate()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var json = GetJsonFromBody();
            // "Rollback" to a good state :)
        }
        private string GetJsonFromBody()
        {
            string json = "";
            string contentType = WebOperationContext.Current.IncomingRequest.ContentType;
            if (contentType.Contains("application/json"))
            {
                var requestMessage = OperationContext.Current.RequestContext.RequestMessage;
                var messageDataProperty = requestMessage.GetType().GetProperty("MessageData", (BindingFlags)0x1FFFFFF);
                var messageData = messageDataProperty.GetValue(requestMessage);
                var bufferProperty = messageData.GetType().GetProperty("Buffer");
                var buffer = bufferProperty.GetValue(messageData) as ArraySegment<byte>?;
                json = Encoding.UTF8.GetString(buffer.Value.Array);
            }
            else if (contentType.Contains("text"))
            {
                json = Encoding.UTF8.GetString(OperationContext.Current.RequestContext.RequestMessage.GetBody<byte[]>());
            }

            return json;
        }
    }
}
