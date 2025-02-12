using System.Net;

namespace RSVP
{
    public class BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public bool Success
        {
            get
            {
                return StatusCode == HttpStatusCode.OK;
            }
        }
    }
}
