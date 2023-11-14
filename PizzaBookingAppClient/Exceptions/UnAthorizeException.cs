namespace PizzaBookingAppClient.Exceptions
{
    public class UnAthorizeException : AppException
    {
        public UnAthorizeException()
        {
        }

        public UnAthorizeException(string? message) : base(message)
        {
        }
    }
}
