using MyWeldingLog.DAL.Interfaces.CatalogMaterials;
using MyWeldingLog.Models.CatalogMaterials;

namespace MyWeldingLog.DAL.Repositories.CatalogMaterials
{
    public class PipeRepository : IPipeRepository
    {
        public Task Insert(Pipe entity)
        {
            throw new NotImplementedException();
        }

        public Task<Pipe[]> Select()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Pipe entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Pipe entity)
        {
            throw new NotImplementedException();
        }
    }
}