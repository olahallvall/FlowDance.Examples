using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FlowDance.Examples.TripBookingSaga.HotelService
{
    [ServiceContract]
    public interface IHotel
    {
        [OperationContract]
        void BookHotel(string passportNumber, Guid traceId);
    }
}
