namespace BookingService.Services
{
    public class CarService : ICarService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoggerFactory _iloggerFactory;

        public CarService(IHttpClientFactory httpClientFactory, ILoggerFactory iloggerFactory)
        {
            _httpClientFactory = httpClientFactory;
            _iloggerFactory = iloggerFactory;
        }
        public void BookCar(string passportNumber, int TripId, Guid traceId) 
        {
            var httpClient = _httpClientFactory.CreateClient();

           
        }
    }
}
