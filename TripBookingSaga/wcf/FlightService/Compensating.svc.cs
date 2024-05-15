using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.Extensions.Logging;
using System;

namespace FlightService
{
    public class Compensating : ICompensating
    {
        public void Compensate(string postData)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var traceId = Guid.NewGuid();

            using (var compSpanRoot = new CompensationSpan(new HttpCompensatingAction("http://localhost:55117/Compensating.svc/Compensate"), traceId, loggerFactory))
            {
                /* Perform transactional work here */
                compSpanRoot.Complete();
            }
        }
    }
}
