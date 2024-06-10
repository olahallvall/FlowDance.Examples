namespace CarService.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoggerFactory _iloggerFactory;

        public HotelService(IHttpClientFactory httpClientFactory, ILoggerFactory iloggerFactory)
        {
            _httpClientFactory = httpClientFactory;
            _iloggerFactory = iloggerFactory;
        }

        public void BookHotel(string passportNumber, Guid traceId)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://localhost:55121/");

            return;
        }
    }
}
