namespace PizzaBookingAppClient.Exceptions
{
    public class ConnectException : AppException
    {
        public ConnectException() : base() { }
        public ConnectException(string? message = "Failed to connect to server") : base(message) { }
    }
}
