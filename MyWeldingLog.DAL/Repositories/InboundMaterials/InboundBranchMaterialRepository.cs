using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.InboundMaterials;
using MyWeldingLog.Models.InboundMaterials;

namespace MyWeldingLog.DAL.Repositories.InboundMaterials
{
    public class InboundBranchMaterialRepository : IInboundBranchMaterialRepository
    {
        private readonly ApplicationDbContext _db;

        public InboundBranchMaterialRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Insert(InboundBranchMaterial entity)
        {
            await _db.InboundBranchMaterials.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<InboundBranchMaterial[]> Select()
        {
            return await _db.InboundBranchMaterials.ToArrayAsync();
        }

        public async Task<bool> Delete(InboundBranchMaterial entity)
        {
            _db.InboundBranchMaterials.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}