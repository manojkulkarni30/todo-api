namespace TodoApi.Models
{
    public class ErrorResponse
    {
        public string Title { get; set; }
        public int StatusCode { get; set; }
        public required string Message { get; set; }
    }
}