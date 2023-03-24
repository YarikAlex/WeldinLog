namespace MyWeldingLog.Models.Hierarchy
{
    public class Job
    {
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор участка на котором производится работа
        /// </summary>
        public int ClusterId { get; set; }
        
        /// <summary>
        /// Идентификатор шифра рабочей документации
        /// </summary>
        public int ProjectCodeId { get; set; }
        
        /// <summary>
        /// Идентификатор вида работ
        /// </summary>
        public int JobTypeId { get; set; }
        
        /// <summary>
        /// Идентифитктор примняемого материала
        /// </summary>
        public int ProjectMaterialId { get; set; }
        
        /// <summary>
        /// Количество используемого материала в данной работе
        /// </summary>
        public double Quantity { get; set; }
    }
}