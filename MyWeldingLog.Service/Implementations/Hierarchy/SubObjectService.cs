using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Enums;
using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Responses;
using MyWeldingLog.Models.Responses.Interfaces;
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

        public async Task<IBaseResponse<bool>> CreateNewSubObject(
            string name,
            CancellationToken token)
        {
            try
            {
                var objects = (await _subObjectRepository.Select(token))
                    .Select(s => s.Name)
                    .ToArray();

                if (objects.Contains(name))
                {
                    return new BaseResponse<bool>
                    {
                        Description = "SubObject already exist",
                        StatusCode = StatusCode.SubObjectAlreadyExist
                    };
                }
                var newSubObject = new SubObject { Name = name };
                var result = await _subObjectRepository.Insert(newSubObject, token);

                return new BaseResponse<bool>
                {
                    Data = result,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateNewSubObject] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<SubObject>> GetSubObjectByName(
            string name,
            CancellationToken token)
        {
            try
            {
                var subObjects = await _subObjectRepository.Select(token);
                var subObject = subObjects.FirstOrDefault(x => x.Name == name);
                
                if (subObject == null)
                {
                    return new BaseResponse<SubObject>
                    {
                        Description = "SubObject not found",
                        StatusCode = StatusCode.SubObjectNotFound
                    };
                }

                return new BaseResponse<SubObject>
                {
                    Data = subObject,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<SubObject>()
                {
                    Description = $"[GetSubObjectByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<SubObject>>> GetSubObjects(
            CancellationToken token)
        {
            try
            {
                var subObjects = await _subObjectRepository.Select(token);
                
                if (!subObjects.Any())
                {
                    return new BaseResponse<IEnumerable<SubObject>>
                    {
                        Description = "Sub object not found",
                        StatusCode = StatusCode.SubObjectNotFound
                    };
                }
                
                return new BaseResponse<IEnumerable<SubObject>>
                {
                    Data = subObjects.OrderBy(x => x.Name).ToArray(),
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<SubObject>>
                {
                    Description = $"[GetSubObjects] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteSubObject(
            int id,
            CancellationToken token)
        {
            try
            {
                var deletingObject = await _subObjectRepository.Get(id, token);
                
                if (deletingObject == null)
                {
                    return new BaseResponse<bool>
                    {
                        Description = "SubObject not found",
                        StatusCode = StatusCode.SubObjectNotFound
                    };
                }
                
                var result = await _subObjectRepository.Delete(deletingObject, token);
                return new BaseResponse<bool>
                {
                    Data = result,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteSubObject] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> RenameSubObject(
            int id,
            string newName,
            CancellationToken token)
        {
            try
            {
                var subObject = await _subObjectRepository.Get(id, token);
                if (subObject == null)
                {
                    return new BaseResponse<bool>
                    {
                        Description = "Project code not found",
                        StatusCode = StatusCode.ProjectCodeNotFound
                    };
                }

                subObject.Name = newName;

                var response = await _subObjectRepository.Update(subObject, token);

                return new BaseResponse<bool>
                {
                    Data = response.Entity.Name == newName,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Description = $"[RenameProjectCode] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}