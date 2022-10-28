namespace MyWeldingLog.Models.CatalogMaterials
{
    public class Pipe
    {
        /// <summary>
        /// Идентификатор трубы по таблице pipes_catalog.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Диаметр трубы.
        /// </summary>
        public ushort Diameter { get; set; }
        
        /// <summary>
        /// Толщина стенки.
        /// </summary>
        public byte Wall { get; set; }
        
        /// <summary>
        /// Марка стали.
        /// </summary>
        public string Steel { get; set; }
        
        /// <summary>
        /// Технические условия.
        /// </summary>
        public string TechnicalCondition { get; set; }
        
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