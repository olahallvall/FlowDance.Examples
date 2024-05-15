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
    public class Booking : IBooking
    {
        public void BookTrip(string passportNumber)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var traceId = Guid.NewGuid();

            using (var compSpanRoot = new CompensationSpan(new HttpCompensatingAction("http://localhost:49983/Compensating.svc/Compensate"), traceId, loggerFactory))
            {
                /* Perform transactional work here */
                compSpanRoot.Complete();
            }
        }
    }
}
