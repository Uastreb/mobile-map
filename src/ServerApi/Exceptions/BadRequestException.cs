using ServerApi.Exceptions.Base;

namespace ServerApi.Exceptions
{
    public class BadRequestException : ApiException
    {
        public new string Message { get; set; }
        public int? Code { get; set; }
    }
}
