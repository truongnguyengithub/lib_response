using Newtonsoft.Json;

namespace OMC.Libs
{
    public class ApiResponse
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("code")]
        public dynamic Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public static ApiResponse<T> Create<T>(T data, bool error = false, dynamic code = null, string message = null)
        {
            ApiResponse<T> responseModel = new ApiResponse<T>
            {
                Error = error,
                Code = code,
                Message = message,
                Data = data
            };
            return responseModel;
        }

        public static ApiResponse Create(bool error = false, dynamic code = null, string message = null) => new ApiResponse()
        {
            Error = error,
            Code = code,
            Message = message
        };
    }

    public class ApiResponse<T> : ApiResponse
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
