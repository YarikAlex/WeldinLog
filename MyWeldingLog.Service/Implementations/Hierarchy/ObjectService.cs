using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Enums;
using MyWeldingLog.Models.Requests.Objects;
using MyWeldingLog.Models.Responses;
using MyWeldingLog.Models.Responses.Interfaces;
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

        public async Task<IBaseResponse<bool>> CreateNewObject(CreateNewObjectRequest request)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var objects = (await _objectRepository.Select())
                    .Select(o => o.Name)
                    .ToArray();

                if (objects.Contains(request.ObjectName))
                {
                    response.Description = "Object already exist";
                    response.StatusCode = StatusCode.ObjectAlreadyExist;
                    return response;
                }
                var newObject = new Object { Name = request.ObjectName };
                response.Data = await _objectRepository.Insert(newObject);
                
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateNewObject] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Object[]>> GetObjects()
        {
            var response = new BaseResponse<Object[]>();
            try
            {
                var objects = (await _objectRepository.Select())
                    .OrderBy(o => o.Name)
                    .ToArray();
                
                if (objects.Length == 0)
                {
                    response.Description = "Objects not found";
                    response.StatusCode = StatusCode.ObjectsNotFound;
                    return response;
                }

                response.Data = objects;
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Object[]>()
                {
                    Description = $"[GetObjects] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteObject(DeleteObjectRequest request)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var deletingObject = await _objectRepository.Get(request.ObjectId);
                
                if (deletingObject == null)
                {
                    response.Description = "Object not found";
                    response.StatusCode = StatusCode.ObjectNotFound;
                    return response;
                }
                
                response.Data = await _objectRepository.Delete(deletingObject);
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteObject] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> RenameObject(RenameObjectRequest request)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var obj = await _objectRepository.Get(request.ObjectId);
                if (obj == null)
                {
                    response.Description = "Object not found";
                    response.StatusCode = StatusCode.ObjectNotFound;
                    return response;
                }

                obj.Name = request.NewObjectName;
                var result = await _objectRepository.Update(obj);
                
                response.Data = result.Entity.Name == request.NewObjectName;
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[RenameObject] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}