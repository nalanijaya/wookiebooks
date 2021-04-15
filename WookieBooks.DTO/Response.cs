using System.Collections.Generic;

namespace WookieBooks.DTO
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }
        public string MessageCode { get; set; }
        public T ResultData { get; set; }
        public List<ErrorInfo> ErrorList { get; set; }
    }

    public class ErrorInfo
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
