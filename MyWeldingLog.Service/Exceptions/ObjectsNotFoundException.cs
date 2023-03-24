using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class ObjectsNotFoundException : WeldingLogException
    {
        public ObjectsNotFoundException()
        {
            Code = ErrorCodes.ObjectsNotFound;
            Message = "Objects not exist in database.";
        }
    }
}