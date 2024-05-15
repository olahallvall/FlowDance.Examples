using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBooking" in both code and config file together.
    [ServiceContract]
    public interface IBooking
    {
        [OperationContract]
        void BookTrip(string passportNumber);
    }
}
