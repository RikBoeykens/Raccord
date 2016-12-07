using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Projects;
using Raccord.Application.Core.Services.Projects;
using Raccord.Data.EntityFramework.Repositories.Projects;

namespace Raccord.Application.Services.Projects
{
    // Service used for project functionality
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        // Initialises a new ProjectService
        public ProjectService(IProjectRepository projectRepository)
        {
            if(projectRepository == null)
                throw new ArgumentNullException(nameof(projectRepository));
            
            _projectRepository = projectRepository;
        }

        // Gets all projects
        public IEnumerable<ProjectSummaryDto> GetAll()
        {
            var projects = _projectRepository.GetAll();

            var projectDtos = projects.Select(p => p.TranslateSummary());

            return projectDtos;
        }

        // Gets a single project by id
        public ProjectDto Get(Int64 ID)
        {
            var project = _projectRepository.GetSingle(ID);

            var projectDto = project.Translate();

            return projectDto;
        }

        // Gets a summary of a single project
        public ProjectSummaryDto GetSummary(Int64 ID)
        {
            var project = _projectRepository.GetSingle(ID);

            var projectDto = project.TranslateSummary();

            return projectDto;
        }

        // Adds a project
        public long Add(ProjectSummaryDto dto)
        {
            var project = new Project
            {
                Title = dto.Title,
            };

            _projectRepository.Add(project);
            _projectRepository.Commit();

            return project.ID;
        }

        // Updates a project
        public long Update(ProjectSummaryDto dto)
        {
            var project = _projectRepository.GetSingle(dto.ID);

            project.Title = dto.Title;

            _projectRepository.Edit(project);
            _projectRepository.Commit();

            return project.ID;
        }

        // Deletes a project
        public void Delete(Int64 ID)
        {
            var project = _projectRepository.GetSingle(ID);

            _projectRepository.Delete(project);

            _projectRepository.Commit();
        }
    }
}