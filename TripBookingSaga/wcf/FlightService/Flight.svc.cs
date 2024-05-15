using System;

namespace FlowDance.Examples.TripBookingSaga.FlightService
{
    public class Flight : IFlight
    {
        public void BookFlight(string passportNumber, Guid traceId)
        {
            throw new Exception("No flight available!");
        }
    }
}
