namespace MyWeldingLog.Models.Requests.Hierarchy
{
    public class DisconnectSubObjectFromObjectRequest
    {
        public string? ObjectName { get; set; }

        public string SubObjectName { get; set; }
    }
}