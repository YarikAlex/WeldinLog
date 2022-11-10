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

        public async Task<IBaseResponse<bool>> CreateNewSubObject(string name)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var objects = (await _subObjectRepository.Select())
                    .Select(s => s.Name)
                    .ToArray();

                if (objects.Contains(name))
                {
                    response.Description = "SubObject already exist";
                    response.StatusCode = StatusCode.SubObjectAlreadyExist;
                    return response;
                }
                var newSubObject = new SubObject { Name = name };
                response.Data = await _subObjectRepository.Insert(newSubObject);
                
                return response;
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

        public async Task<IBaseResponse<SubObject>> GetSubObjectByName(string name)
        {
            var response = new BaseResponse<SubObject>();
            try
            {
                var subObjects = await _subObjectRepository.Select();
                subObjects = subObjects.Where(x => x.Name == name).ToArray();
                if (subObjects.Length == 0)
                {
                    response.Description = "SubObject not found";
                    response.StatusCode = StatusCode.SubObjectNotFound;
                    return response;
                }
                response.Data = subObjects.First();
                return response;
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

        public Task<IBaseResponse<SubObject[]>> GetSubObjects()
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<bool>> DeleteSubObject(int id)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var deletingObject = await _subObjectRepository.Get(id);
                
                if (deletingObject == null)
                {
                    response.Description = "SubObject not found";
                    response.StatusCode = StatusCode.SubObjectNotFound;
                    return response;
                }
                
                response.Data = await _subObjectRepository.Delete(deletingObject);
                return response;
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
    }
}