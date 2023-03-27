namespace MyWeldingLog.Models.Requests.SubObjects
{
    public class RenameSubObjectRequest
    {
        public int SubObjectId { get; set; }

        public string NewSubObjectName { get; set; }
    }
}