using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Enums;
using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Responses;
using MyWeldingLog.Models.Responses.Interfaces;
using MyWeldingLog.Service.Exceptions;
using MyWeldingLog.Service.Interfaces.Hierarchy;

namespace MyWeldingLog.Service.Implementations.Hierarchy
{
    public class SubObjectService : ISubObjectService
    {
        private readonly ISubObjectRepository _subObjectRepository;

        public SubObjectService(ISubObjectRepository subObjectRepository)
        {
            _subObjectRepository = subObjectRepository;
        }

        public async Task<bool> CreateNewSubObject(
            string name,
            CancellationToken token)
        {
            var objects = (await _subObjectRepository.Select(token))
                .Select(s => s.Name)
                .ToArray();

            if (objects.Contains(name))
            {
                throw new SubObjectAlreadyExistException(name);
            }
            var newSubObject = new SubObject { Name = name };
            var result = await _subObjectRepository.Insert(newSubObject, token);

            return result;
        }

        public async Task<SubObject> GetSubObjectByName(
            string name,
            CancellationToken token)
        {
            var subObjects = await _subObjectRepository.Select(token);
            var subObject = subObjects.FirstOrDefault(x => x.Name == name);
            
            if (subObject == null)
            {
                throw new SubObjectNotFoundException(subObjectName: name);
            }

            return subObject;
        }

        public async Task<IEnumerable<SubObject>> GetSubObjects(
            CancellationToken token)
        {
            var subObjects = await _subObjectRepository.Select(token);
            
            if (!subObjects.Any())
            {
                throw new SubObjectsNotFoundException();
            }

            return subObjects;
        }

        public async Task<bool> DeleteSubObject(
            int id,
            CancellationToken token)
        {
            var deletingObject = await _subObjectRepository.Get(id, token);
                
            if (deletingObject == null)
            {
                throw new SubObjectNotFoundException(id);
            }
            
            var result = await _subObjectRepository.Delete(deletingObject, token);
            return result;
        }

        public async Task<bool> RenameSubObject(
            int id,
            string newName,
            CancellationToken token)
        {
            var subObject = await _subObjectRepository.Get(id, token);
            if (subObject == null)
            {
                throw new SubObjectNotFoundException(id);
            }

            subObject.Name = newName;
            var response = await _subObjectRepository.Update(subObject, token);

            return response.Entity.Name == newName;
        }
    }
}