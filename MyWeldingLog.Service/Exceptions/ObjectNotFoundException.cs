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
        }
    }
}