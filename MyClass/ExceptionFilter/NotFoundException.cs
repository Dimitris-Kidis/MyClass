using System.Net;

namespace MyClass.ExceptionFilter
{ 
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}
