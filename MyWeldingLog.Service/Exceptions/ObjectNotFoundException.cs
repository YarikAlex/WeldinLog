using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class ObjectNotFoundException : WeldingLogException
    {
        public int? ObjectId { get; set; }
        public string? ObjectName { get; set; }

        public ObjectNotFoundException(int? objectId = null, string? objectName = null)
        {
            ObjectId = objectId!.Value;
            ObjectName = objectName;

            Code = ErrorCodes.ObjectNotFound;
            Message = $"Object {(ObjectId.HasValue ? ObjectId.Value : ObjectName)} not found.";
        }
    }
}