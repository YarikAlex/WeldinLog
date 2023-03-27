namespace MyWeldingLog.Service.Exceptions.BaseException.Elements
{
    public class Result
    {
        public Error Error { get; set; }
        
        public static Result<object, TCode> WithError<TCode>(TCode code)
            where TCode : struct, Enum => new Result<object, TCode>()
        {
            Error = new Error<TCode>(code)
        };

        public static Result<object, TCode> WithError<TCode>(
            TCode code,
            string message)
            where TCode : struct, Enum => new Result<object, TCode>()
        {
            Error = new Error<TCode>(code, message)
        };
        
        public static Result<object, TCode> WithError<TCode>(
            TCode code,
            string message,
            object details)
            where TCode : struct, Enum
        {
            return new Result<object, TCode>()
            {
                Error = new Error<TCode>(code, message, details)
            };
        }
        
        public static Result WithError(string message) => new Result()
        {
            Error = new Error(message)
        };

        public static Result WithError(Error e) => new Result()
        {
            Error = e
        };

        public static Result WithError(Exception e) => new Result()
        {
            Error = new Error(e)
        };

        public static Result<TData> WithData<TData>(TData data) => new Result<TData>()
        {
            Data = data
        };

        public static Result Empty => new Result();
    }
    
    public class Result<TData> : Result
    {
        public TData Data { get; set; }
    }

    public class Result<TData, TCode> : Result<TData> where TCode : struct, Enum
    {
        public Error<TCode> Error { get; set; }

        public static Result<TData, TCode> WithError(TCode code) => new Result<TData, TCode>
        {
            Error = new Error<TCode>(code)
        };
    }
}