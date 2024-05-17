using Microsoft.Extensions.Logging;

namespace HotelService
{
    public class Compensating : ICompensating
    {
        public void Compensate(string postData)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            // "Rollback" to a good state :)
        }
    }
}
