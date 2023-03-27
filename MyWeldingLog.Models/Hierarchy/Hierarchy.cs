namespace MyWeldingLog.Models.Hierarchy
{
    public class Hierarchy
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Id объекта строительства
        /// </summary>
        public int ObjectId { get; set; }
        
        /// <summary>
        /// ID подобъекта, который входит в состав объекта под ObjectId
        /// </summary>
        public int SubObjectId { get; set; }
    }
}