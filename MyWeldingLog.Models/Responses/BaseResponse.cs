using MyWeldingLog.Models.Enums;
using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Models.Responses
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }
        public ErrorCodes ErrorCodes { get; set;}
        public string Description { get; set; }
    }
}