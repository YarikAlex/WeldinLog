using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class ObjectAlreadyExistException : WeldingLogException
    {
        public ObjectAlreadyExistException(string objectName)
        {
            ObjectName = objectName;
        }

        public string ObjectName { get; set; }
    }
}