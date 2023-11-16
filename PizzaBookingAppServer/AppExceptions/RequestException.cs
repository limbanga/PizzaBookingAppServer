namespace PizzaBookingAppServer.AppExceptions
{
    public class RequestException : AppException
    {
        public RequestException() { }

        public RequestException(string? message) : base(message)
        {
        }
    }
}
