namespace BookingApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var passportNumber = "34-12435488";
            var svr = new BookingService.BookingClient();
            svr.BookTrip(passportNumber);
        }
    }
}
