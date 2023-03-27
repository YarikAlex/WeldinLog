using MyWeldingLog.Models.Enums;

namespace MyWeldingLog.Models.ProjectMaterials
{
    public class ProjectMaterial
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
        /// Тип материала
        /// </summary>
        public MaterialTypes MaterialType { get; set; }

        /// <summary>
        /// Диаметр трубы.
        /// </summary>
        public ushort FirstDiameter { get; set; }

        /// <summary>
        /// Толщина стенки.
        /// </summary>
        public byte FirstWall { get; set; }

        /// <summary>
        /// Второй диаметр (для тройников и переходов)
        /// </summary>
        public ushort? SecondDiameter { get; set; }

        /// <summary>
        /// Толщина стенки второго диаметра (для тройников и переходов)
        /// </summary>
        public byte? SecondWall { get; set; }

        /// <summary>
        /// Угол поворота.
        /// </summary>
        public byte? Angle { get; set; }

        /// <summary>
        /// Тип отвода.
        /// </summary>
        public string BranchType { get; set; }

        /// <summary>
        /// Класс прочности.
        /// </summary>
        public string Strength { get; set; }

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
        /// Тип изоляции
        /// </summary>
        public string IsolationType { get; set; }

        /// <summary>
        /// Количество материала по проекту
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Количество материалв использванного в работах
        /// </summary>
        public double Used { get; set; }

        /// <summary>
        /// Метка об удалении материала
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}