namespace MyWeldingLog.Models.ProjectMaterials
{
    public class ProjectPipeMaterial
    {
        /// <summary>
        /// Идентификатор отвода по таблице ProjectPipeMaterials.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор шифра проекта по таблице ProjectCodes
        /// </summary>
        public int ProjectCodeId { get; set; }

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
        public string TechnicalConditions { get; set; }

        /// <summary>
        /// Завод изготовитель.
        /// </summary>
        public string Factory { get; set; }

        /// <summary>
        /// Наличие изоляции.
        /// </summary>
        public bool IsIsolated { get; set; }

        /// <summary>
        /// Количество материала по проекту
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Метка об удалении материала
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}