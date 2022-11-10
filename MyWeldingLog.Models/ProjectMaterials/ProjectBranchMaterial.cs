namespace MyWeldingLog.Models.ProjectMaterials
{
    public class ProjectBranchMaterial
    {
        /// <summary>
        /// Идентификатор отвода по таблице ProjectBranchMaterials.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор шифра проекта по таблице ProjectCodes
        /// </summary>
        public int ProjectCodeId { get; set; }

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
        /// Класс прочности.
        /// </summary>
        public string Strength { get; set; }

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
        ///Количество материала по проекту
        /// </summary>
        public double Quantity { get; set; }
        
        /// <summary>
        /// Метка об удалении материала
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}