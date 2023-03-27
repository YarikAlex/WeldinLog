using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class ProjectCodeAlreadyExistException : WeldingLogException
    {
        public string ProjectCodeName { get; set; }

        public ProjectCodeAlreadyExistException(string projectCodeName)
        {
            ProjectCodeName = projectCodeName;

            Code = ErrorCodes.ProjectCodeAlreadyExist;
            Message = $"Project code { ProjectCodeName } already exist.";
            Details = new { ProjectCodeName };
        }
    }
}