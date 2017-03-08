using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Projects;
using Raccord.Application.Core.Services.Projects;
using Raccord.Data.EntityFramework.Repositories.Projects;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;

namespace Raccord.Application.Services.Projects
{
    // Service used for project functionality
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IBreakdownTypeDefinitionRepository _breakdownTypeDefinitionRepository;

        // Initialises a new ProjectService
        public ProjectService(
            IProjectRepository projectRepository,
            IBreakdownTypeDefinitionRepository breakdownTypeDefinitionRepository
            )
        {
            if(projectRepository == null)
                throw new ArgumentNullException(nameof(projectRepository));
            if(breakdownTypeDefinitionRepository == null)
                throw new ArgumentNullException(nameof(breakdownTypeDefinitionRepository));
            
            _projectRepository = projectRepository;
            _breakdownTypeDefinitionRepository = breakdownTypeDefinitionRepository;
        }

        // Gets all projects
        public IEnumerable<ProjectSummaryDto> GetAll()
        {
            var projects = _projectRepository.GetAll();

            var projectDtos = projects.Select(p => p.TranslateSummary());

            return projectDtos;
        }

        // Gets a single project by id
        public FullProjectDto Get(long ID)
        {
            var project = _projectRepository.GetFull(ID);

            var projectDto = project.TranslateFull();

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
            var breakdownTypeDefinitions = _breakdownTypeDefinitionRepository.GetAll();

            var project = new Project
            {
                Title = dto.Title,
                BreakdownTypes = breakdownTypeDefinitions.Select(bt=> new BreakdownType
                {
                    Name = bt.Name,
                    Description = bt.Description,
                }).ToList()
            };

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