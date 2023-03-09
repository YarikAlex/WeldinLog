namespace MyWeldingLog.Models.Hierarchy
{
    public class ProjectCode
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Шифр проекта.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Привязка к объекту и подобъекту
        /// </summary>
        public int HierarchyId { get; set; }
    }
}