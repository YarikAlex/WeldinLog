namespace MyWeldingLog.Models.ActualMaterials
{
    public class ActualBranchMaterial
    {
        public int Id { get; set; }
        
        public int? ProjectCodeId { get; set; }

        public int  ObjectId { get; set; }
        
        public int? ProjectBranchId { get; set; }
        
        public DateTimeOffset Date { get; set; }
        
        public ushort Diameter { get; set; }
        
        public byte Wall { get; set; }

        public byte Angle { get; set; }
        
        public string BranchType { get; set; }
        
        public string Strength { get; set; }
        
        public string TechnicalCondition { get; set; }
        
        public string Factory { get; set; }
        
        public bool IsIsolated { get; set; }
        
        public double Quantity { get; set; }

        public string Certificate { get; set; }
        
        public string FactoryNumber { get; set; }
    }
}