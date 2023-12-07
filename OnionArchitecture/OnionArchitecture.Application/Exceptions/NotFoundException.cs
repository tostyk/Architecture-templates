namespace OnionArchitecture.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string notFoundObjectName)
            : base($"{notFoundObjectName} not found") { }
    }
}
