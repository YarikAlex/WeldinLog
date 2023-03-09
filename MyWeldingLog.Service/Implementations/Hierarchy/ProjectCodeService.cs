using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Enums;
using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Responses;
using MyWeldingLog.Models.Responses.Interfaces;
using MyWeldingLog.Service.Interfaces.Hierarchy;

namespace MyWeldingLog.Service.Implementations.Hierarchy
{
    public class ProjectCodeService : IProjectCodeService
    {
        private readonly IProjectCodeRepository _projectCodeRepository;
        private readonly IHierarchyRepository _hierarchyRepository;

        public ProjectCodeService(IProjectCodeRepository projectCodeRepository, IHierarchyRepository hierarchyRepository)
        {
            _projectCodeRepository = projectCodeRepository;
            _hierarchyRepository = hierarchyRepository;
        }

        public async Task<IBaseResponse<bool>> CreateNewProjectCode(int hierarchyId, string projectCodeName)
        {
            try
            {
                var hierarchy = (await _hierarchyRepository.Select())
                    .FirstOrDefault(x => x.Id == hierarchyId);

                if (hierarchy == null)
                {
                    return new BaseResponse<bool>
                    {
                        Description = "Link hierarchy not found",
                        StatusCode = StatusCode.LinkNotFound
                    };
                }

                var projectCodes = (await _projectCodeRepository.Select())
                    .Select(x => x.Name)
                    .ToArray();

                if (projectCodes.Contains(projectCodeName))
                {
                    return new BaseResponse<bool>
                    {
                        Description = "Project code already exist",
                        StatusCode = StatusCode.ProjectCodeAlreadyExist
                    };
                }

                return new BaseResponse<bool>
                {
                    Data = await _projectCodeRepository.Insert(
                        new ProjectCode
                        {
                            HierarchyId = hierarchyId,
                            Name = projectCodeName
                        }),
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateNewProjectCode] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteProjectCode(int projectCodeId)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var projectCode = await _projectCodeRepository.Get(projectCodeId);
                
                if (projectCode == null)
                {
                    response.Description = "Project code not found";
                    response.StatusCode = StatusCode.ProjectCodeNotFound;
                    return response;
                }

                response.Data = await _projectCodeRepository.Delete(projectCode);
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteProjectCode] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<ProjectCode>>> GetProjectCodes()
        {
            try
            {
                var projectCodes = await _projectCodeRepository.Select();
                if (!projectCodes.Any())
                {
                    return new BaseResponse<IEnumerable<ProjectCode>>
                    {
                        Description = "Project codes not found",
                        StatusCode = StatusCode.ProjectCodesNotFound
                    };
                }
                
                return new BaseResponse<IEnumerable<ProjectCode>>
                {
                    Data = projectCodes.OrderBy(x => x.Name).ToArray(),
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<ProjectCode>>
                {
                    Description = $"[GetProjectCodes] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ProjectCode>> GetProjectCodeByName(string name)
        {
            try
            {
                var projectCodes = await _projectCodeRepository.Select();
                var projectCode = projectCodes.FirstOrDefault(x => x.Name == name);

                if (projectCode == null)
                {
                    return new BaseResponse<ProjectCode>
                    {
                        Description = "Project code not found",
                        StatusCode = StatusCode.ProjectCodeNotFound
                    };
                }
                
                return new BaseResponse<ProjectCode>
                {
                    Data = projectCode,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProjectCode>
                {
                    Description = $"[GetProjectCodeByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> RenameProjectCode(int id, string newName)
        {
            try
            {
                var projectCode = await _projectCodeRepository.Get(id);
                if (projectCode == null)
                {
                    return new BaseResponse<bool>
                    {
                        Description = "Project code not found",
                        StatusCode = StatusCode.ProjectCodeNotFound
                    };
                }

                projectCode.Name = newName;

                var response = await _projectCodeRepository.Update(projectCode);

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