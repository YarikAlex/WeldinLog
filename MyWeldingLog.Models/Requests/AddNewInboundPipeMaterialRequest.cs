namespace MyWeldingLog.Models.Requests
{
    public class AddNewInboundPipeMaterialRequest
    {
        public int ObjectId { get; set; }

        public ushort Diameter { get; set; }
        
        public byte Wall { get; set; }
        
        public string Steel { get; set; }
        
        public string TechnicalCondition { get; set; }
        
        public string Factory { get; set; }
        
        public bool IsIsolated { get; set; }
        
        public double Quantity { get; set; }

        public string Certificate { get; set; }
        
        public string FactoryNumber { get; set; }
    }
}