using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Service.Exceptions;
using MyWeldingLog.Service.Exceptions.ExceptionHandler;
using MyWeldingLog.Service.Interfaces.Hierarchy;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.Service.Implementations.Hierarchy
{
    public class ObjectService : IObjectService
    {
        private readonly IObjectRepository _objectRepository;
        
        public ObjectService(IObjectRepository objectRepository)
        {
            _objectRepository = objectRepository;
        }

        public async Task<bool> CreateNewObject(
            string objectName,
            CancellationToken token)
        {
            var objects = (await _objectRepository.Select(token))
                    .Select(o => o.Name)
                    .ToArray();

            if (objects.Contains(objectName))
            {
                throw new ObjectAlreadyExistException(objectName);
            }
            var newObject = new Object { Name = objectName };
            var response = await _objectRepository.Insert(newObject, token);
            
            return response;
        }

        public async Task<IEnumerable<Object>> GetObjects(CancellationToken token)
        {
            var objects = await _objectRepository.Select(token);
                
            if (!objects.Any())
            {
                throw new ObjectsNotFoundException();
            }

            var response = objects
                .OrderBy(o => o.Name)
                .ToArray();
            return response;
        }

        public async Task<bool> DeleteObject(
            int objectId,
            CancellationToken token)
        {
            var deletingObject = await _objectRepository.Get(objectId, token);
                
            if (deletingObject == null)
            {
                throw new ObjectNotFoundException(objectId: objectId);
            }
            
            var response = await _objectRepository.Delete(deletingObject, token);
            return response;
        }

        public async Task<Object> GetObjectByName(
            string? objectName,
            CancellationToken token)
        {
            var objects = await _objectRepository.Select(token);
            var obj = objects.FirstOrDefault(x => x.Name == objectName);

            if (obj == null)
            {
                throw new ObjectNotFoundException(objectName: objectName);
            }

            return obj;
        }

        public async Task<bool> RenameObject(
            int objectId,
            string newObjectName,
            CancellationToken token)
        {
            var obj = await _objectRepository.Get(objectId, token);
            if (obj == null)
            {
                throw new ObjectNotFoundException(objectId);
            }

            obj.Name = newObjectName;
            var result = await _objectRepository.Update(obj, token);
            
            var response = result.Entity.Name == newObjectName;
            return response;
        }
    }
}