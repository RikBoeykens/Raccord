using Microsoft.Extensions.DependencyInjection;
using Raccord.Data.EntityFramework.Repositories.Projects;
using Raccord.Data.EntityFramework.Repositories.Scenes;
using Raccord.Data.EntityFramework.Repositories.Locations;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;
using Raccord.Data.EntityFramework.Repositories.Images;
using Raccord.Data.EntityFramework.Repositories.ImageScenes;
using Raccord.Data.EntityFramework.Repositories.ImageLocations;
using Raccord.Data.EntityFramework.Repositories.Characters;
using Raccord.Data.EntityFramework.Repositories.ImageCharacters;
using Raccord.Data.EntityFramework.Repositories.CharacterScenes;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Locations;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Application.Core.Services.ImageScenes;
using Raccord.Application.Core.Services.ImageLocations;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.ImageCharacters;
using Raccord.Application.Core.Services.CharacterScenes;
using Raccord.Application.Services.Projects;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Services.Locations;
using Raccord.Application.Services.SceneProperties;
using Raccord.Application.Services.Images;
using Raccord.Application.Services.SearchEngine;
using Raccord.Application.Services.ImageScenes;
using Raccord.Application.Services.ImageLocations;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.ImageCharacters;
using Raccord.Application.Services.CharacterScenes;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes;

namespace Raccord.API
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IProjectSearchEngineService, ProjectSearchEngineService>();

            services.AddTransient<ISceneRepository, SceneRepository>();
            services.AddTransient<ISceneService, SceneService>();
            services.AddTransient<ISceneSearchEngineService, SceneSearchEngineService>();
            
            services.AddTransient<IIntExtRepository, IntExtRepository>();
            services.AddTransient<IIntExtService, IntExtService>();
            services.AddTransient<IIntExtSearchEngineService, IntExtSearchEngineService>();
            
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ILocationSearchEngineService, LocationSearchEngineService>();
            
            services.AddTransient<IDayNightRepository, DayNightRepository>();
            services.AddTransient<IDayNightService, DayNightService>();
            services.AddTransient<IDayNightSearchEngineService, DayNightSearchEngineService>();
            
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IImageSearchEngineService, ImageSearchEngineService>();

            services.AddTransient<IImageSceneRepository, ImageSceneRepository>();
            services.AddTransient<IImageSceneService, ImageSceneService>();

            services.AddTransient<IImageLocationRepository, ImageLocationRepository>();
            services.AddTransient<IImageLocationService, ImageLocationService>();

            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<ICharacterService, CharacterService>();
            services.AddTransient<ICharacterSearchEngineService, CharacterSearchEngineService>();            

            services.AddTransient<IImageCharacterRepository, ImageCharacterRepository>();
            services.AddTransient<IImageCharacterService, ImageCharacterService>();

            services.AddTransient<ICharacterSceneRepository, CharacterSceneRepository>();
            services.AddTransient<ICharacterSceneService, CharacterSceneService>();
            
            services.AddTransient<IBreakdownTypeDefinitionRepository, BreakdownTypeDefinitionRepository>();
            services.AddTransient<IBreakdownTypeRepository, BreakdownTypeRepository>();

            services.AddTransient<ISearchEngineServiceWrapper, SearchEngineServiceWrapper>();
        }
    }
}