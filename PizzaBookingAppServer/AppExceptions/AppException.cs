namespace PizzaBookingAppServer.AppExceptions
{
    public abstract class AppException : Exception
    {
        public AppException(string? message) : base(message)
        {

        }
    }
}
