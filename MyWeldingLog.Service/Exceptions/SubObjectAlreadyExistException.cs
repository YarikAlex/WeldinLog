using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class SubObjectAlreadyExistException : WeldingLogException
    {
        public string SubObjectName { get; set; }

        public SubObjectAlreadyExistException(string name)
        {
            SubObjectName = name;
            Code = ErrorCodes.SubObjectAlreadyExist;
            Message = $"Subobject {name} already exist";
        }
    }
}