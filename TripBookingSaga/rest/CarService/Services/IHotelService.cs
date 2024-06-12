namespace CarService.Services
{
    public interface IHotelService
    {
        Task<bool> BookHotel(string passportNumber, int tripId, Guid traceId);
    }
}