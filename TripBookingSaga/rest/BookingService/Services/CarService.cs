using Newtonsoft.Json;
using System.Text;

namespace BookingService.Services
{
    public class CarService : ICarService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoggerFactory _loggerFactory;

        public CarService(IHttpClientFactory httpClientFactory, ILoggerFactory iloggerFactory)
        {
            _httpClientFactory = httpClientFactory;
            _loggerFactory = iloggerFactory;
        }
        public async Task<bool> BookCar(string passportNumber, int tripId, Guid traceId) 
        {
            var httpClient = _httpClientFactory.CreateClient();

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5043/api/car/bookcar");
            httpRequest.Headers.Add("x-correlation-id", traceId.ToString());
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(new Car() { PassportNumber = passportNumber, TripId = tripId }), Encoding.UTF8, $"application/json");

            var response = await httpClient.SendAsync(httpRequest);
            if(response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
