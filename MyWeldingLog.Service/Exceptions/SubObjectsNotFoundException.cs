using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class SubObjectsNotFoundException : WeldingLogException
    {
        public SubObjectsNotFoundException()
        {
            Code = ErrorCodes.SubObjectsNotFound;
            Message = "SubObjects not exist in database.";
        }
    }
}