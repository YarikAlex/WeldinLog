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
        /// Подъобект, к которому относится шифр проекта.
        /// </summary>
        public int SubObjectId { get; set; }
        
        /// <summary>
        /// Объект, к которому относится шифр проекта.
        /// </summary>
        public int ObjectId { get; set; }
    }
}