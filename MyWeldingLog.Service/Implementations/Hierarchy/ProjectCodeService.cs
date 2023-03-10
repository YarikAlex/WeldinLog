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

        public async Task<IBaseResponse<bool>> CreateNewProjectCode(
            int hierarchyId,
            string projectCodeName,
            CancellationToken token)
        {
            try
            {
                var hierarchy = (await _hierarchyRepository.Select(token))
                    .FirstOrDefault(x => x.Id == hierarchyId);

                if (hierarchy == null)
                {
                    return new BaseResponse<bool>
                    {
                        Description = "Link hierarchy not found",
                        StatusCode = StatusCode.LinkNotFound
                    };
                }

                var projectCodes = (await _projectCodeRepository.Select(token))
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
                        }, token),
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

        public async Task<IBaseResponse<bool>> DeleteProjectCode(
            int projectCodeId,
            CancellationToken token)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var projectCode = await _projectCodeRepository.Get(projectCodeId, token);
                
                if (projectCode == null)
                {
                    return new BaseResponse<bool>
                    {
                        Description = "Project code not found",
                        StatusCode = StatusCode.ProjectCodeNotFound
                    };
                }

                var result = await _projectCodeRepository.Delete(projectCode, token);
                
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
                    Description = $"[DeleteProjectCode] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<ProjectCode>>> GetProjectCodes(CancellationToken token)
        {
            try
            {
                var projectCodes = await _projectCodeRepository.Select(token);
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

        public async Task<IBaseResponse<ProjectCode>> GetProjectCodeByName(
            string name,
            CancellationToken token)
        {
            try
            {
                var projectCodes = await _projectCodeRepository.Select(token);
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

        public async Task<IBaseResponse<bool>> RenameProjectCode(
            int id,
            string newName,
            CancellationToken token)
        {
            try
            {
                var projectCode = await _projectCodeRepository.Get(id, token);
                if (projectCode == null)
                {
                    return new BaseResponse<bool>
                    {
                        Description = "Project code not found",
                        StatusCode = StatusCode.ProjectCodeNotFound
                    };
                }

                projectCode.Name = newName;

                var response = await _projectCodeRepository.Update(projectCode, token);

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