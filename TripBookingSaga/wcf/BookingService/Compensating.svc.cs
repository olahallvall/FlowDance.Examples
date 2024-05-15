using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Compensating" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Compensating.svc or Compensating.svc.cs at the Solution Explorer and start debugging.
    public class Compensating : ICompensating
    {
        public void Compensate(string postData)
        {
            
        }
    }
}
