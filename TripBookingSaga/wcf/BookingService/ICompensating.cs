using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace BookingService
{    
    [ServiceContract]
    public interface ICompensating
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "compensate", Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        void Compensate();
    }
}
