﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FlowDance.Examples.TripBookingSaga.HotelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Hotel" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Hotel.svc or Hotel.svc.cs at the Solution Explorer and start debugging.
    public class Hotel : IHotel
    {
        public void BookHotel(string passportNumber)
        {
            throw new NotImplementedException();
        }
    }
}