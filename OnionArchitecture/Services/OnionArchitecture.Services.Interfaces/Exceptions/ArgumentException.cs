namespace OnionArchitecture.Services.Interfaces.Exceptions
{
    public class ArgumentException : Exception
    {
        public ArgumentException() { }
        public ArgumentException(string message) : base(message) { }
    }
}
