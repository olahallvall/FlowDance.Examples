using System;
using System.ServiceModel;

namespace FlowDance.Examples.TripBookingSaga.FlightService
{
    [ServiceContract]
    public interface IFlight
    {
        [OperationContract]
        void BookFlight(string passportNumber, Guid traceId);
    }
}
