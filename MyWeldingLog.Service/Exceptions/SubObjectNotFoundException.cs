using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class SubObjectNotFoundException : WeldingLogException
    {
        public int? SubObjectId { get; set; }

        public string? SubObjectName { get; set; }

        public SubObjectNotFoundException(int? subObjectId = null, string? subObjectName = null)
        {
            SubObjectId = subObjectId;
            SubObjectName = subObjectName;

            Code = ErrorCodes.SubObjectNotFound;
            Message = $"SubObject {(SubObjectId.HasValue ? SubObjectId.Value : SubObjectName)} not found.";
            Details = new { SubObjectId, SubObjectName };
        }
    }
}