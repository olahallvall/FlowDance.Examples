using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.Extensions.Logging;
using System;

namespace FlowDance.Examples.TripBookingSaga.FlightService
{
    public class Flight : IFlight
    {
        public void BookFlight(string passportNumber, Guid traceId)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            try
            {
                using (var compSpanRoot = new CompensationSpan(new HttpCompensatingAction("http://localhost:55117/Compensating.svc/Compensate"), traceId, loggerFactory))
                {
                    throw new Exception("No flight available!");

                    compSpanRoot.Complete();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Flight>();
                logger.LogError(ex, "BookFlight");
            }
        }
    }
}
