namespace MyWeldingLog.Models.Hierarchy
{
    public class Cluster
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Наименование участка
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Идентификатор объекта, в который входит участок
        /// </summary>
        public int ObjectId { get; set; }
        
        /// <summary>
        /// Идентификатор подобъекта, в который входит участок
        /// </summary>
        public int SubObjectId { get; set; }
    }
}