namespace MyWeldingLog.Models.Requests
{
    public class CreateNewProjectPipeRequest
    {
        public int ProjectCodeId { get; set; }
        
        public ushort Diameter { get; set; }
        
        public byte Wall { get; set; }
        
        public string Steel { get; set; }
        
        public string TechnicalConditions { get; set; }
        
        public string Factory { get; set; }
        
        public bool IsIsolated { get; set; }
        
        public double Quantity { get; set; }
    }
}