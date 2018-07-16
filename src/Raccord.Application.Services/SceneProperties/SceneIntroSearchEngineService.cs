using System;
using System.Linq;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;
using Raccord.Core.Enums;
using Raccord.Application.Services.SearchEngine;

namespace Raccord.Application.Services.SceneProperties
{
    // Service to search for int/ext
    public class SceneIntroSearchEngineService : ISceneIntroSearchEngineService
    {
        private readonly EntityType _type = EntityType.SceneIntro;
        private readonly ISceneIntroRepository _sceneIntroRepository;

        // Initialises a new SceneIntroSearchEngineService
        public SceneIntroSearchEngineService(ISceneIntroRepository sceneIntroRepository)
        {
            if(sceneIntroRepository == null)
                throw new ArgumentNullException(nameof(sceneIntroRepository));
            
            _sceneIntroRepository = sceneIntroRepository;
        }

        public new EntityType GetType()
        {
            return _type;
        }

        public SearchTypeResultDto GetResults(SearchRequestDto request)
        {
            var excludeIds = request.GetExcludeLongIDs(_type);
            var sceneIntroCount = _sceneIntroRepository.SearchCount(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);
            var sceneIntros = _sceneIntroRepository.Search(request.SearchText, request.ProjectID, request.UserID, request.IsAdminSearch, excludeIds);

            return new SearchTypeResultDto
            {
                Count = sceneIntroCount,
                Type = "Int/Ext",
                Results = sceneIntros.Select(i=> i.TranslateToSearchResult()),
            };
            
        }
    }
}