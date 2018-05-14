using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Users;
using Raccord.Application.Core.Services.Users.Project;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;

namespace Raccord.Application.Services.Users.Projects
{
    // Service used for project user functionality
    public class ProjectUserService : IProjectUserService
    {
        private readonly IProjectUserRepository _projectUserRepository;

        // Initialises a new CallsheetSceneService
        public ProjectUserService(IProjectUserRepository projectUserRepository)
        {
            if(projectUserRepository == null)
                throw new ArgumentNullException(nameof(projectUserRepository));
            
            _projectUserRepository = projectUserRepository;
        }

        // Gets all callsheet scenes for a scene
        public IEnumerable<ProjectUserProjectDto> GetProjects(string userID)
        {
            var projectUsers = _projectUserRepository.GetAllForUser(userID);

            var dtos = projectUsers.Select(l => l.TranslateProject());

            return dtos;
        }

        // Gets all callsheet scenes for a day
        public IEnumerable<ProjectUserUserDto> GetUsers(long projectID)
        {
            var projectUsers = _projectUserRepository.GetAllForProject(projectID);

            var dtos = projectUsers.Select(l => l.TranslateUser());

            return dtos;
        }

        // Gets a single project user by id
        public FullProjectUserDto Get(long ID)
        {
            var projectUser = _projectUserRepository.GetFull(ID);

            var dto = projectUser.TranslateFull();

            return dto;
        }

        // Adds a callsheet scene
        public long Add(ProjectUserDto dto)
        {
            var projectUser = new ProjectUser
            {
                ProjectID = dto.ProjectID,
                UserID = dto.UserID,
                RoleID = dto.RoleID,
            };

            _projectUserRepository.Add(projectUser);
            _projectUserRepository.Commit();

            return projectUser.ID;
        }

        // Updates a callsheet scene
        public long Update(ProjectUserDto dto)
        {
            var projectUser = _projectUserRepository.GetSingle(dto.ID);

            projectUser.RoleID = dto.RoleID;

            _projectUserRepository.Edit(projectUser);
            _projectUserRepository.Commit();

            return projectUser.ID;
        }

        // Deletes a callsheet scene
        public void Delete(Int64 ID)
        {
            var projectUser = _projectUserRepository.GetSingle(ID);

            _projectUserRepository.Delete(projectUser);

            _projectUserRepository.Commit();
        }
    }
}