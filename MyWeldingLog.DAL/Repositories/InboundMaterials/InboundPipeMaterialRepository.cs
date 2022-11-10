using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.InboundMaterials;
using MyWeldingLog.Models.ActualMaterials;

namespace MyWeldingLog.DAL.Repositories.InboundMaterials
{
    public class InboundPipeMaterialRepository : IInboundPipeMaterialRepository
    {
        private readonly ApplicationDbContext _db;

        public InboundPipeMaterialRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<bool> Insert(InboundPipeMaterial entity)
        {
            await _db.InboundPipeMaterials.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<InboundPipeMaterial[]> Select()
        {
            return await _db.InboundPipeMaterials.ToArrayAsync();
        }

        public async Task<bool> Delete(InboundPipeMaterial entity)
        {
            _db.InboundPipeMaterials.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}