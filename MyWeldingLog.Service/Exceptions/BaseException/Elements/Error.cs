using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace MyWeldingLog.Service.Exceptions.BaseException.Elements
{
    public class Error
    {
        private static readonly JsonSerializer SnackCaseSerializer = new JsonSerializer()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public string Message { get; set; }
        public object Details { get; set; }

        public Error() { }

        public Error(string message) => Message = message;

        public Error(string message, object details)
        {
            Message = message;
            Details = details;
        }

        public Error(Exception exception)
        {
            Message = exception.Message;
            Details = new
            {
                StackTrace = exception.StackTrace,
                Type = exception.GetType().ToString()
            };
        }

        public T? TryGetDetails<T>() where T : class
        {
            try
            {
                return Details is JObject details ? details.ToObject<T>(Error.SnackCaseSerializer) : default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }

    public class Error<TCode> : Error where TCode : struct, Enum
    {
        public TCode Code { get; set; }

        public string CodeDescription { get; set; }

        public Error() { }
        
        public Error(TCode code)
        {
            Code = code;
            CodeDescription = code.ToString();
        }
        
        public Error(TCode code, string message)
            : this(code)
        {
            Message = message;
        }
        
        public Error(TCode code, string message, object details)
            : this(code, message)
        {
            Details = details;
        }
    }
}