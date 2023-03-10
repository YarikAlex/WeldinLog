namespace MyWeldingLog.Models.Requests.ProjectCodes
{
    public class CreateNewProjectCodeRequest
    {
        public int HierarchyId { get; set; }

        public string ProjectCodeName { get; set; }
    }
}