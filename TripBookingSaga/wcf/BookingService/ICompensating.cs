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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompensating" in both code and config file together.
    [ServiceContract]
    public interface ICompensating
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "compensate")]
        void Compensate(string postData);
    }
}
