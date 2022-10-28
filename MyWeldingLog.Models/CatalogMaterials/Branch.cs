namespace MyWeldingLog.Models.CatalogMaterials
{
    public class Branch
    {
        /// <summary>
        /// Идентификатор отвода по таблице BranchesCatalog.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Диаметр отвода.
        /// </summary>
        public ushort Diameter { get; set; }
        
        /// <summary>
        /// Толщина стенки.
        /// </summary>
        public byte Wall { get; set; }
        
        /// <summary>
        /// Угол поворота.
        /// </summary>
        public byte Angle { get; set; }
        
        /// <summary>
        /// Тип отвода.
        /// </summary>
        public string BranchType { get; set; }
        
        /// <summary>
        /// Марка стали.
        /// </summary>
        public string Steel { get; set; }
        
        /// <summary>
        /// Технические условия.
        /// </summary>
        public string TechnicalConditions { get; set; }
        
        /// <summary>
        /// Завод изготовитель.
        /// </summary>
        public string Factory { get; set; }
        
        /// <summary>
        /// Наличие изоляции.
        /// </summary>
        public bool IsIsolated { get; set; }
    }
}