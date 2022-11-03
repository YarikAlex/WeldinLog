using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.ActualMaterials;
using MyWeldingLog.Models.ActualMaterials;

namespace MyWeldingLog.DAL.Repositories.ActualMaterials
{
    public class ActualBranchMaterialRepository : IActualBranchMaterialRepository
    {
        private readonly ApplicationDbContext _db;

        public ActualBranchMaterialRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Insert(ActualBranchMaterial entity)
        {
            await _db.ActualBranchMaterials.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ActualBranchMaterial[]> Select()
        {
            return await _db.ActualBranchMaterials.ToArrayAsync();
        }

        public async Task<bool> Delete(ActualBranchMaterial entity)
        {
            _db.ActualBranchMaterials.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}