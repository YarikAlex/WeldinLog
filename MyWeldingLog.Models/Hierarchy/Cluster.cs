namespace MyWeldingLog.Models.Hierarchy
{
    public class Cluster
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Наименование участка
        /// </summary>
        public string Name { get; set; }
        
        public int HierarchyId { get; set; }
    }
}