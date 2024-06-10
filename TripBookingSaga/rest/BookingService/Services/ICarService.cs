namespace BookingService.Services
{
    public interface ICarService
    {
        void BookCar(string passportNumber, int TripId, Guid traceId);
    }
}