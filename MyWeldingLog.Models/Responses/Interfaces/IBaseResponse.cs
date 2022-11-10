using MyWeldingLog.Models.Enums;

namespace MyWeldingLog.Models.Responses.Interfaces
{
    public interface IBaseResponse<T>
    {
        T Data { get; }
        StatusCode StatusCode { get; }
    }
}