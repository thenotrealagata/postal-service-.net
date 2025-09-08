namespace PostalService.Exceptions
{
    public class SaveFailedException : Exception
    {
        public SaveFailedException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
