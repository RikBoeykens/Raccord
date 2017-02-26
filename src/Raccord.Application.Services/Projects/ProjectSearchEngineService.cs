using System;
using System.Linq;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Projects;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Projects
{
    // Service to search for projects
    public class ProjectSearchEngineService : IProjectSearchEngineService
    {
        private readonly IProjectRepository _projectRepository;

        // Initialises a new ProjectSearchEngineService
        public ProjectSearchEngineService(IProjectRepository projectRepository)
        {
            if(projectRepository == null)
                throw new ArgumentNullException(nameof(projectRepository));
            
            _projectRepository = projectRepository;
        }

        public new EntityType GetType()
        {
            return EntityType.Project;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var projectCount = _projectRepository.SearchCount(request.SearchText);
            var projects = _projectRepository.Search(request.SearchText);

            return new SearchTypeResultDto
            {
                Count = projectCount,
                Type = "Projects",
                Results = projects.Select(p=> p.TranslateToSearchResult()),
            };
            
        }
    }
}