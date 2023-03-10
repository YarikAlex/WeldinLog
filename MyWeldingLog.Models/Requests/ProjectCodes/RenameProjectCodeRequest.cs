namespace MyWeldingLog.Models.Requests.ProjectCodes
{
    public class RenameProjectCodeRequest
    {
        public int ProjectCodeId { get; set; }

        public string NewProjectCodeName { get; set; }
    }
}