using System.Net;

namespace DS.ClientControllSystem.Core
{
    public class JsonReturn
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public object Error { get; set; }
        public object Data { get; set; }

        public JsonReturn()
        {
            Data = null;
            Error = null;
            StatusCode = 0;
            Success = false;
        }

        public JsonReturn(object data, object error, int statusCode, bool success)
        {
            Data = Data;
            Error = Error;
            StatusCode = statusCode;
            Success = Success;
        }
    }
}
