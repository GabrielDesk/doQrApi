namespace doQrApi.Objects.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? ErrorId { get; set; }
        public int Total { get; set; }
        public string? Env { get; set; }
        public string? Message { get; set; }
    }
} 
