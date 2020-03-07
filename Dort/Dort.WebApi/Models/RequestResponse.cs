namespace Dort.WebApi.Models
{
    public class RequestResponse
    {
        public int Status { get; set; } = 500;
        public object Content { get; set; }
    }
}
