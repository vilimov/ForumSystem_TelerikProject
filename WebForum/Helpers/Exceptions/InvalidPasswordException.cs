namespace WebForum.Helpers.Exceptions
{
    public class InvalidPasswordException : ApplicationException
    {
        public InvalidPasswordException(string message)
            : base(message) 
        {
        }
    }
}
