using System.Net;

namespace api_number_at_letters.Models
{
    public class ApiResponse
    {
        public HttpStatusCode ?StatusCode { get; set; }

        public bool? IsSuccess { get; set; } = true;

        public Object? Result { get; set; } = null;

        public IEnumerable<Object> ?Errors { get; set; }

    }
}
