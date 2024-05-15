using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.Extensions.Logging;
using System;

namespace FlowDance.Examples.TripBookingSaga.HotelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Hotel" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Hotel.svc or Hotel.svc.cs at the Solution Explorer and start debugging.
    public class Hotel : IHotel
    {
        public void BookHotel(string passportNumber)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var traceId = Guid.NewGuid();

            using (var compSpanRoot = new CompensationSpan(new HttpCompensatingAction("http://localhost:55121/Compensating.svc/Compensate"), traceId, loggerFactory))
            {
                /* Perform transactional work here */
                compSpanRoot.Complete();
            }
        }
    }
}
