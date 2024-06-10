namespace CarService.Services
{
    public interface IHotelService
    {
        void BookHotel(string passportNumber, Guid traceId);
    }
}