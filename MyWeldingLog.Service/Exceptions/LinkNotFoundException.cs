using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class LinkNotFoundException : WeldingLogException
    {
        public string ObjectName { get; set; }

        public string SubObjectName { get; set; }

        public int ObjectId { get; set; }

        public int SubObjectId { get; set; }

        public LinkNotFoundException(string objectName, string subObjectName)
        {
            ObjectName = objectName;
            SubObjectName = subObjectName;

            Code = ErrorCodes.LinkNotFound;
            Message = $"SubObject { SubObjectName } not linked with { ObjectName }";
            Details = new { ObjectName, SubObjectName };
        }

        public LinkNotFoundException(int objectId, int subObjectId)
        {
            ObjectId = objectId;
            SubObjectId = subObjectId;
            
            Code = ErrorCodes.LinkNotFound;
            Message = $"SubObject { SubObjectId } not linked with { ObjectId }";
            Details = new { ObjectId, SubObjectId };
        }
    }
}