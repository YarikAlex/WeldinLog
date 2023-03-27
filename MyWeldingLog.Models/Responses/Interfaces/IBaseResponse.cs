using MyWeldingLog.Models.Enums;

namespace MyWeldingLog.Models.Responses.Interfaces
{
    public interface IBaseResponse<T>
    {
        T Data { get; }
        ErrorCodes ErrorCodes { get; }
    }
}