
namespace HotelService.Services
{
    public interface IFlightService
    {
        Task<bool> BookFlight(string passportNumber, int tripId, Guid traceId);
    }
}