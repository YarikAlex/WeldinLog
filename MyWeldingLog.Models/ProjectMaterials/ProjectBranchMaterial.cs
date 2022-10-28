namespace MyWeldingLog.Models.ProjectMaterials
{
    public class ProjectBranchMaterial
    {
        /// <summary>
        /// Идентификатор отвода по таблице ProjectBranchMaterials.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Идентификатор отвода по таблице BranchesCatalog.
        /// </summary>
        public int BranchId { get; set; }
        
        /// <summary>
        /// Идентификатор шифра проекта по таблице ProjectCodes
        /// </summary>
        public int ProjectCodeId { get; set; }
        
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