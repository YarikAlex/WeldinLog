using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class ProjectCodeNotFoundException : WeldingLogException
    {
        public string ProjectCodeName { get; set; }

        public int ProjectCodeId { get; set; }

        public ProjectCodeNotFoundException(string projectCodeName = "", int projectCodeId = default)
        {
            ProjectCodeName = projectCodeName;
            ProjectCodeId = projectCodeId;

            Code = ErrorCodes.ProjectCodeNotFound;
            Message = $"Project code {(ProjectCodeName == string.Empty ? ProjectCodeId : ProjectCodeName)} not found.";
            Details = new { ProjectCodeName,  ProjectCodeId };
        }
        
        
    }
}