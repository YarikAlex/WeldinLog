using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class LinkAlreadyExistException : WeldingLogException
    {
        public string ObjectName { get; set; }

        public string SubObjectName { get; set; }
        public LinkAlreadyExistException(
            string objectName,
            string subObjectName)
        {
            ObjectName = objectName;
            SubObjectName = subObjectName;

            Code = ErrorCodes.LinkAlreadyExist;
            Message = $"SubObject {subObjectName} already linked with {objectName}.";
            Details = new { ObjectName, SubObjectName };
        }
    }
}