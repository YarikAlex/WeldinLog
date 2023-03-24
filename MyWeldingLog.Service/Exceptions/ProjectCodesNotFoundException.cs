using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class ProjectCodesNotFoundException : WeldingLogException
    {
        public ProjectCodesNotFoundException()
        {
            Code = ErrorCodes.ProjectCodesNotFound;
            Message = "Project codes not exist in database";
        }
    }
}