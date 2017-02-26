using System;
using System.Linq;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.Scenes;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Scenes
{
    // Service to search for scenes
    public class SceneSearchEngineService : ISceneSearchEngineService
    {
        private readonly ISceneRepository _sceneRepository;

        // Initialises a new SceneSearchEngineService
        public SceneSearchEngineService(ISceneRepository sceneRepository)
        {
            if(sceneRepository == null)
                throw new ArgumentNullException(nameof(sceneRepository));
            
            _sceneRepository = sceneRepository;
        }

        public new EntityType GetType()
        {
            return EntityType.Scene;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var sceneCount = _sceneRepository.SearchCount(request.SearchText, request.ProjectID);
            var scenes = _sceneRepository.Search(request.SearchText, request.ProjectID);

            return new SearchTypeResultDto
            {
                Count = sceneCount,
                Type = "Scene",
                Results = scenes.Select(i=> i.TranslateToSearchResult()),
            };
            
        }
    }
}