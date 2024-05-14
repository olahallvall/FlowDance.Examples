using FlowDance.Client;
using FlowDance.Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlowDance.Examples.TripBookingSaga.BookingApp
{
    internal class Program
    {
        private static ILoggerFactory _loggerFactory;
        static void Main(string[] args)
        {
            _loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var traceId = Guid.NewGuid();

            using (var compSpanRoot = new CompensationSpan(new HttpCompensatingAction("http://localhost/TripBookingService/Compensation"), traceId, _loggerFactory))
            {
                /* Perform transactional work here */
                compSpanRoot.Complete();
            }

        }
    }
}
