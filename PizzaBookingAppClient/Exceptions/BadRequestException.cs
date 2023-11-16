namespace PizzaBookingAppClient.Exceptions
{
    public class BadRequestException : AppException
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string? message) : base(message)
        {
        }
    }
}
