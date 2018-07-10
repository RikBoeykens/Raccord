using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Projects;
using Raccord.Application.Core.Services.Projects;
using Raccord.Data.EntityFramework.Repositories.Projects;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Raccord.Data.EntityFramework.Repositories.Callsheets.CallTypes;
using Raccord.Domain.Model.Callsheets.CallTypes;
using Raccord.Data.EntityFramework.Repositories.Crew.Departments;
using Raccord.Domain.Model.Crew.Departments;
using Raccord.Data.EntityFramework.Repositories.Users;
using Raccord.Application.Services.Crew.CrewMembers;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Application.Core.Common.Paging;
using Raccord.Data.EntityFramework.Repositories.Users.Invitations.Projects;

namespace Raccord.Application.Services.Projects
{
    // Service used for project functionality
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectUserInvitationRepository _projectUserInvitationRepository;
        private readonly IBreakdownTypeDefinitionRepository _breakdownTypeDefinitionRepository;
        private readonly ICallTypeDefinitionRepository _callTypeDefinitionRepository;
        private readonly ICrewDepartmentDefinitionRepository _crewDepartmentDefinitionRepository;
        private readonly IUserRepository _userRepository;

        // Initialises a new ProjectService
        public ProjectService(
            IProjectRepository projectRepository,
            IProjectUserInvitationRepository projectUserInvitationRepository,
            IBreakdownTypeDefinitionRepository breakdownTypeDefinitionRepository,
            ICallTypeDefinitionRepository callTypeDefinitionRepository,
            ICrewDepartmentDefinitionRepository crewDepartmentDefinitionRepository,
            IUserRepository userRepository
            )
        {
            if(projectRepository == null)
                throw new ArgumentNullException(nameof(projectRepository));
            if(projectUserInvitationRepository == null)
                throw new ArgumentNullException(nameof(projectUserInvitationRepository));
            if(breakdownTypeDefinitionRepository == null)
                throw new ArgumentNullException(nameof(breakdownTypeDefinitionRepository));
            if(callTypeDefinitionRepository == null)
                throw new ArgumentNullException(nameof(callTypeDefinitionRepository));
            if(crewDepartmentDefinitionRepository == null)
                throw new ArgumentNullException(nameof(crewDepartmentDefinitionRepository));
            
            _projectRepository = projectRepository;
            _projectUserInvitationRepository = projectUserInvitationRepository;
            _breakdownTypeDefinitionRepository = breakdownTypeDefinitionRepository;
            _callTypeDefinitionRepository = callTypeDefinitionRepository;
            _crewDepartmentDefinitionRepository = crewDepartmentDefinitionRepository;
            _userRepository = userRepository;
        }

        // Gets all projects paged
        public PagedDataDto<AdminProjectSummaryDto> GetAdminPaged(PaginationRequestDto requestDto)
        {
            var projects = _projectRepository.GetAll();
            
            var projectDtos = projects.GetPaged<Project, AdminProjectSummaryDto>(requestDto, p => {
                var invitationCount = _projectUserInvitationRepository.GetCountForProject(p.ID);
                return p.TranslateAdminSummary(invitationCount);
            });

            return projectDtos;
        }

        public IEnumerable<UserProjectSummaryDto> GetAllForUser(string userId)
        {
            var projects = _projectRepository.GetAllForUser(userId);

            var user = _userRepository.GetFull(userId);

            var projectDtos = projects.Select(p => p.TranslateUserSummary(user));

            return projectDtos;
        }

        public PagedDataDto<UserProjectDto> GetAllForUserPaged(string userId, PaginationRequestDto paginationRequest)
        {
            var projects = _projectRepository.GetAllForUser(userId);

            var user = _userRepository.GetFull(userId);

            var projectDtos = projects.Select(p => p.TranslateUserSummary(user));

            return projects.GetPaged<Project, UserProjectDto>(paginationRequest, x => Utilities.TranslateUser(x, user));
        }

        public IEnumerable<UserProjectDto> GetFullForUser(string userId)
        {
            var projects = _projectRepository.GetAllForUser(userId);

            var user = _userRepository.GetFull(userId);

            var projectDtos = projects.Select(p => p.TranslateUser(user));

            return projectDtos;
        }

        // Gets a single project by id
        public FullProjectDto Get(long ID)
        {
            var project = _projectRepository.GetFull(ID);

            var projectDto = project.TranslateFull();

            return projectDto;
        }

        // Gets a single project by id
        public AdminFullProjectDto GetForAdmin(long ID)
        {
            var project = _projectRepository.GetFullAdmin(ID);

            var invitations = _projectUserInvitationRepository.GetAllForProject(ID);

            var projectDto = project.TranslateFullAdmin(invitations);

            return projectDto;
        }

        // Gets a summary of a single project
        public ProjectSummaryDto GetSummary(long ID)
        {
            var project = _projectRepository.GetSummary(ID);

            var projectDto = project.TranslateSummary();

            return projectDto;
        }

        // Adds a project
        public long Add(ProjectDto dto)
        {
            var project = new Project
            {
                Title = dto.Title,
            };

            var callTypeDefinitions = _callTypeDefinitionRepository.GetAll();
            foreach(var definition in callTypeDefinitions)
            {
                project.CallTypes.Add(new CallType
                {
                    ShortName = definition.ShortName,
                    Name = definition.Name,
                    Description = definition.Description,
                    SortingOrder = definition.SortingOrder,
                });
            }

            var departmentDefinitions = _crewDepartmentDefinitionRepository.GetAll();
            project.CrewUnits.Add(new CrewUnit
            {
                Name = "Main Unit",
                Description = string.Empty,
                CrewDepartments = departmentDefinitions.Select(definition => new CrewDepartment
                {
                    Name = definition.Name,
                    Description = definition.Description,
                    SortingOrder = definition.SortingOrder,
                }).ToList()
            });

            _projectRepository.Add(project);
            _projectRepository.Commit();

            return project.ID;
        }

        // Updates a project
        public long Update(ProjectDto dto)
        {
            var project = _projectRepository.GetSingle(dto.ID);

            project.Title = dto.Title;

            _projectRepository.Edit(project);
            _projectRepository.Commit();

            return project.ID;
        }

        // Deletes a project
        public void Delete(long ID)
        {
            var project = _projectRepository.GetSingle(ID);

            _projectRepository.Delete(project);

            _projectRepository.Commit();
        }
    }
}