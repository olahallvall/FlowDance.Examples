using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.Extensions.Logging;
using System;

namespace FlowDance.Examples.TripBookingSaga.CarService
{
    public class Car : ICar
    {
        public void BookCar(string passportNumber, Guid traceId)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            using (var compSpanRoot = new CompensationSpan(new HttpCompensatingAction("http://localhost:55057/Compensating.svc/Compensate"), traceId, loggerFactory))
            {
                var svr = new HotelService.HotelClient();
                svr.BookHotel(passportNumber, traceId);

                compSpanRoot.Complete();
            }
        }
    }
}
