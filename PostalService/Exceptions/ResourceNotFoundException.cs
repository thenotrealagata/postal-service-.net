namespace PostalService.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string? message) : base($"{message} not found!")
        {
        }
    }
}
