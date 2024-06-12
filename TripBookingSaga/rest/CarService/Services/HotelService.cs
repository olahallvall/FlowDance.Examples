using Newtonsoft.Json;
using System.Text;

namespace CarService.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoggerFactory _loggerFactory;

        public HotelService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory)
        {
            _httpClientFactory = httpClientFactory;
            _loggerFactory = loggerFactory;
        }

        public async Task<bool> BookHotel(string passportNumber, int tripId, Guid traceId)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5075/api/hotel/bookhotel");
            httpRequest.Headers.Add("x-correlation-id", traceId.ToString());
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(new Hotel() { PassportNumber = passportNumber, TripId = tripId }), Encoding.UTF8, $"application/json");

            var response = await httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
