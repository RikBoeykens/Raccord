using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Core.Enums;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Locations.Locations;

namespace Raccord.Application.Services.SearchEngine
{
    // Service to search for multiple things
    public class SearchEngineServiceWrapper : ISearchEngineServiceWrapper
    {
        private IProjectSearchEngineService _projectSearchEngineService;
        private ISceneSearchEngineService _sceneSearchEngineService;
        private IIntExtSearchEngineService _intExtSearchEngineService;
        private IScriptLocationSearchEngineService _scriptLocationSearchEngineService;
        private IDayNightSearchEngineService _dayNightSearchEngineService;
        private IImageSearchEngineService _imageSearchEngineService;
        private ICharacterSearchEngineService _characterSearchEngineService;
        private IBreakdownItemSearchEngineService _breakdownItemSearchEngineService;
        private ILocationSearchEngineService _locationSearchEngineService;

        public SearchEngineServiceWrapper(
            IProjectSearchEngineService projectSearchEngineService,
            ISceneSearchEngineService sceneSearchEngineService,
            IIntExtSearchEngineService intExtSearchEngineService,
            IScriptLocationSearchEngineService scriptLocationSearchEngineService,
            IDayNightSearchEngineService dayNightSearchEngineService,
            IImageSearchEngineService imageSearchEngineService,
            ICharacterSearchEngineService characterSearchEngineService,
            IBreakdownItemSearchEngineService breakdownItemSearchEngineService,
            ILocationSearchEngineService locationSearchEngineService
        )
        {
            if(projectSearchEngineService==null)
                throw new ArgumentNullException(nameof(projectSearchEngineService));
            if(sceneSearchEngineService==null)
                throw new ArgumentNullException(nameof(sceneSearchEngineService));
            if(intExtSearchEngineService==null)
                throw new ArgumentNullException(nameof(intExtSearchEngineService));
            if(scriptLocationSearchEngineService==null)
                throw new ArgumentNullException(nameof(scriptLocationSearchEngineService));
            if(dayNightSearchEngineService==null)
                throw new ArgumentNullException(nameof(dayNightSearchEngineService));
            if(imageSearchEngineService==null)
                throw new ArgumentNullException(nameof(imageSearchEngineService));
            if(characterSearchEngineService==null)
                throw new ArgumentNullException(nameof(characterSearchEngineService));
            if(breakdownItemSearchEngineService==null)
                throw new ArgumentNullException(nameof(breakdownItemSearchEngineService));
            if(locationSearchEngineService==null)
                throw new ArgumentNullException(nameof(locationSearchEngineService));

            _projectSearchEngineService = projectSearchEngineService;
            _sceneSearchEngineService = sceneSearchEngineService;
            _intExtSearchEngineService = intExtSearchEngineService;
            _scriptLocationSearchEngineService = scriptLocationSearchEngineService;
            _dayNightSearchEngineService = dayNightSearchEngineService;
            _imageSearchEngineService = imageSearchEngineService;
            _characterSearchEngineService = characterSearchEngineService;
            _breakdownItemSearchEngineService = breakdownItemSearchEngineService;
            _locationSearchEngineService = locationSearchEngineService;
        }
        public IEnumerable<SearchTypeResultDto> GetResults(SearchRequestDto request)
        {
            var services = GetSearchEngineServices(request.IncludeTypes, request.ExcludeTypes);
            var results = new List<SearchTypeResultDto>();

            foreach(var service in services)
            {
                results.Add(service.GetResults(request));
            }

            return results;
        }

        private IEnumerable<ITypeSearchEngineService> GetSearchEngineServices(IEnumerable<EntityType> includeTypes, IEnumerable<EntityType> excludeTypes)
        {
            var services = new List<ITypeSearchEngineService>
            {
                _projectSearchEngineService,
                _sceneSearchEngineService,
                _intExtSearchEngineService,
                _scriptLocationSearchEngineService,
                _dayNightSearchEngineService,
                _imageSearchEngineService,
                _characterSearchEngineService,
                _breakdownItemSearchEngineService,
                _locationSearchEngineService
            };

            if(includeTypes.Any())
            {
                services = services.Where(s=> includeTypes.Any(i=> i==s.GetType())).ToList();
            }

            if(excludeTypes.Any())
            {
                services = services.Where(s=> !excludeTypes.Any(i=> i==s.GetType())).ToList();
            }

            return services;
        }
    }
}