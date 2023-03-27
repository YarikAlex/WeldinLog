using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Enums;
using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Responses;
using MyWeldingLog.Models.Responses.Interfaces;
using MyWeldingLog.Service.Exceptions;
using MyWeldingLog.Service.Interfaces.Hierarchy;

namespace MyWeldingLog.Service.Implementations.Hierarchy
{
    public class ProjectCodeService : IProjectCodeService
    {
        private readonly IProjectCodeRepository _projectCodeRepository;
        private readonly IHierarchyService _hierarchyService;

        public ProjectCodeService(
            IProjectCodeRepository projectCodeRepository,
            IHierarchyService hierarchyService)
        {
            _projectCodeRepository = projectCodeRepository;
            _hierarchyService = hierarchyService;
        }

        public async Task<bool> CreateNewProjectCode(
            ///TODO: изменить контракты на objectName и subObjectName
            int objectId,
            int subObjectId,
            string projectCodeName,
            CancellationToken token)
        {
            var hierarchyId = await _hierarchyService.GetHierarchyId(objectId, subObjectId, token);

           var projectCodes = (await _projectCodeRepository.Select(token))
                .Select(x => x.Name)
                .ToArray();

            if (projectCodes.Contains(projectCodeName))
            {
                throw new ProjectCodeAlreadyExistException(projectCodeName);
            }

            return await _projectCodeRepository.Insert(
                new ProjectCode
                {
                    HierarchyId = hierarchyId,
                    Name = projectCodeName
                }, token);
        }

        public async Task<bool> DeleteProjectCode(
            int projectCodeId,
            CancellationToken token)
        {
            var projectCode = await _projectCodeRepository.GetById(projectCodeId, token);
            
            if (projectCode == null)
            {
                throw new ProjectCodeNotFoundException(projectCodeId: projectCodeId);
            }

            return await _projectCodeRepository.Delete(projectCode, token);
            }

        public async Task<IEnumerable<ProjectCode>> GetProjectCodes(CancellationToken token)
        {
            var projectCodes = (await _projectCodeRepository.Select(token)).ToArray();
            if (!projectCodes.Any())
            {
                throw new ProjectCodesNotFoundException();
            }

            return projectCodes.OrderBy(x => x.Name);
        }

        public async Task<ProjectCode> GetProjectCodeByName(
            string name,
            CancellationToken token)
        {
            var projectCodes = await _projectCodeRepository.Select(token);
            var projectCode = projectCodes.FirstOrDefault(x => x.Name == name);

            if (projectCode == null)
            {
                throw new ProjectCodeNotFoundException(projectCodeName: name);
            }

            return projectCode;
        }

        public async Task<bool> RenameProjectCode(
            int id,
            string newName,
            CancellationToken token)
        {
            var projectCode = await _projectCodeRepository.GetById(id, token);
            if (projectCode == null)
            {
                throw new ProjectCodeNotFoundException(projectCodeId: id);
            }

            projectCode.Name = newName;
            var response = await _projectCodeRepository.Update(projectCode, token);

            return response.Name == newName;
            }
    }
}