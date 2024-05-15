﻿using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.Extensions.Logging;
using System;

namespace FlowDance.Examples.TripBookingSaga.CarService
{
    public class Car : ICar
    {
        public void BookCar(string passportNumber)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var traceId = Guid.NewGuid();

            using (var compSpanRoot = new CompensationSpan(new HttpCompensatingAction("http://localhost:55057/Compensating.svc/Compensate"), traceId, loggerFactory))
            {
                /* Perform transactional work here */
                compSpanRoot.Complete();
            }
        }
    }
}
