namespace BookingService.Services
{
    public interface ICarService
    {
        Task<bool> BookCar(string passportNumber, int TripId, Guid traceId);
    }
}