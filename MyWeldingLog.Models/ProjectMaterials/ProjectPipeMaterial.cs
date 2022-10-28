namespace MyWeldingLog.Models.ProjectMaterials
{
    public class ProjectPipeMaterial
    {
        //TODO: Сделать XML описание
        /// <summary>
        /// Идентификатор отвода по таблице ProjectPipeMaterials.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Идентификатор отвода по таблице PipesCatalog.
        /// </summary>
        public int PipeId { get; set; }
        
        /// <summary>
        /// Идентификатор шифра проекта по таблице ProjectCodes
        /// </summary>
        public int ProjectCodeId { get; set; }
        
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