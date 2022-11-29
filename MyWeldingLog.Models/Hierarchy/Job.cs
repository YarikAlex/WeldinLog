namespace MyWeldingLog.Models.Hierarchy
{
    public class Job
    {
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
        /// Количество испоьзуемого материала в данной работе
        /// </summary>
        public double Quantity { get; set; }
    }
}