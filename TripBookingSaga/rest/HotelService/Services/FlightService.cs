using Newtonsoft.Json;
using System.Text;

namespace HotelService.Services
{
    public class FlightService : IFlightService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoggerFactory _loggerFactory;

        public FlightService(IHttpClientFactory httpClientFactory, ILoggerFactory iloggerFactory)
        {
            _httpClientFactory = httpClientFactory;
            _loggerFactory = iloggerFactory;
        }

        public async Task<bool> BookFlight(string passportNumber, int tripId, Guid traceId)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5113/api/flight/bookflight");
            httpRequest.Headers.Add("x-correlation-id", traceId.ToString());
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(new Flight() { PassportNumber = passportNumber, TripId = tripId }), Encoding.UTF8, $"application/json");

            var response = await httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
