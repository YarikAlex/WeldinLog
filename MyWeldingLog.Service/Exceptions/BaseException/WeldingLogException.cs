using MyWeldingLog.Models.Enums;

namespace MyWeldingLog.Service.Exceptions.BaseException
{
    public class WeldingLogException : Exception
    {
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
        public object Details { get; set; }

        public WeldingLogException()
        {
            
        }

        public WeldingLogException(ErrorCodes code, string message, object details)
        {
            Code = code;
            Message = message;
            Details = details;
        }
    }
}