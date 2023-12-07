namespace OnionArchitecture.Presentation.Middleware
{
    public class ErrorMessage
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ErrorMessage() { }
        public ErrorMessage(int statusCode, string message)
        {  
            StatusCode = statusCode; 
            Message = message; 
        }
    }
}
