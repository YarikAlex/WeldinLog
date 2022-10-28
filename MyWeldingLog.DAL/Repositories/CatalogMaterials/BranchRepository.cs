using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.CatalogMaterials;
using MyWeldingLog.Models.CatalogMaterials;

namespace MyWeldingLog.DAL.Repositories.CatalogMaterials
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext _db;

        public BranchRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Insert(Branch entity)
        {
            await _db.BranchesCatalog.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Branch[]> Select()
        {
            return await _db.BranchesCatalog.ToArrayAsync();
        }

        public Task<bool> Delete(Branch entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Branch entity)
        {
            throw new NotImplementedException();
        }
    }
}