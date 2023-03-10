namespace MyWeldingLog.Models.Requests.ProjectCodes
{
    public class CreateNewProjectCodeRequest
    {
        public int ObjectId { get; set; }

        public int SubObjectId { get; set; }

        public string ProjectCodeName { get; set; }
    }
}