using System;

namespace BookingApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hit enter to run make a booking");
            var name = Console.ReadLine();

            var passportNumber = "34-12435488";
            var svr = new BookingService.BookingClient();
            svr.BookTrip(passportNumber);
        }
    }
}
