using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FlowDance.Examples.TripBookingSaga.HotelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotel" in both code and config file together.
    [ServiceContract]
    public interface IHotel
    {
        [OperationContract]
        void BookHotel(string passportNumber);
    }
}
