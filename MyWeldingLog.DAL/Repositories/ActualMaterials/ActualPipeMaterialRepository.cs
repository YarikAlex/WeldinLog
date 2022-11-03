using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.ActualMaterials;
using MyWeldingLog.Models.ActualMaterials;

namespace MyWeldingLog.DAL.Repositories.ActualMaterials
{
    public class ActualPipeMaterialRepository : IActualPipeMaterialRepository
    {
        private readonly ApplicationDbContext _db;

        public ActualPipeMaterialRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<bool> Insert(ActualPipeMaterial entity)
        {
            await _db.ActualPipeMaterials.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ActualPipeMaterial[]> Select()
        {
            return await _db.ActualPipeMaterials.ToArrayAsync();
        }

        public async Task<bool> Delete(ActualPipeMaterial entity)
        {
            _db.ActualPipeMaterials.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}