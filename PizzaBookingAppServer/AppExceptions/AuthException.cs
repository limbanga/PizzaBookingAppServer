namespace PizzaBookingAppServer.AppExceptions
{
    public class AuthException : AppException
    {

        public AuthException()
            : base("Username or password is incorrect")
        { }

        public AuthException(string? message) : base(message)
        {

        }
    }
}
