using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Booking" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Booking.svc or Booking.svc.cs at the Solution Explorer and start debugging.
    public class Booking : IBooking
    {
        public void BookTrip(string passportNumber)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var traceId = Guid.NewGuid();

            using (var compSpanRoot = new CompensationSpan(new HttpCompensatingAction("http://localhost/TripBookingService/Compensation"), traceId, loggerFactory))
            {
                /* Perform transactional work here */
                compSpanRoot.Complete();
            }
        }
    }
}
