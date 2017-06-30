using Microsoft.Extensions.DependencyInjection;
using Raccord.Data.EntityFramework.Repositories.Projects;
using Raccord.Data.EntityFramework.Repositories.Scenes;
using Raccord.Data.EntityFramework.Repositories.ScriptLocations;
using Raccord.Data.EntityFramework.Repositories.SceneProperties;
using Raccord.Data.EntityFramework.Repositories.Images;
using Raccord.Data.EntityFramework.Repositories.ImageScenes;
using Raccord.Data.EntityFramework.Repositories.ImageScriptLocations;
using Raccord.Data.EntityFramework.Repositories.Characters;
using Raccord.Data.EntityFramework.Repositories.ImageCharacters;
using Raccord.Data.EntityFramework.Repositories.CharacterScenes;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItems;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItemScenes;
using Raccord.Data.EntityFramework.Repositories.ImageBreakdownItems;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDays;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleScenes;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDayNotes;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleCharacters;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Application.Core.Services.ImageScenes;
using Raccord.Application.Core.Services.ImageLocations;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.ImageCharacters;
using Raccord.Application.Core.Services.CharacterScenes;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes;
using Raccord.Application.Core.Services.ImageBreakdownItems;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;
using Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes;
using Raccord.Application.Services.Projects;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Services.ScriptLocations;
using Raccord.Application.Services.SceneProperties;
using Raccord.Application.Services.Images;
using Raccord.Application.Services.SearchEngine;
using Raccord.Application.Services.ImageScenes;
using Raccord.Application.Services.ImageLocations;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.ImageCharacters;
using Raccord.Application.Services.CharacterScenes;
using Raccord.Application.Services.Breakdowns.BreakdownTypes;
using Raccord.Application.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Services.Breakdowns.BreakdownItemScenes;
using Raccord.Application.Services.ImageBreakdownItems;
using Raccord.Application.Services.Scheduling.ScheduleDays;
using Raccord.Application.Services.Scheduling.ScheduleScenes;
using Raccord.Application.Services.Scheduling.ScheduleDayNotes;
using Raccord.Application.Core.Services.Scheduling.ScheduleCharacters;
using Raccord.Application.Services.Scheduling.ScheduleCharacters;
using Raccord.Data.EntityFramework.Repositories.Locations.Locations;
using Raccord.Data.EntityFramework.Repositories.Locations.LocationSets;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Application.Services.Locations.Locations;

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
            
            services.AddTransient<IScriptLocationRepository, ScriptLocationRepository>();
            services.AddTransient<IScriptLocationService, ScriptLocationService>();
            services.AddTransient<IScriptLocationSearchEngineService, ScriptLocationSearchEngineService>();
            
            services.AddTransient<IDayNightRepository, DayNightRepository>();
            services.AddTransient<IDayNightService, DayNightService>();
            services.AddTransient<IDayNightSearchEngineService, DayNightSearchEngineService>();
            
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IImageSearchEngineService, ImageSearchEngineService>();

            services.AddTransient<IImageSceneRepository, ImageSceneRepository>();
            services.AddTransient<IImageSceneService, ImageSceneService>();

            services.AddTransient<IImageScriptLocationRepository, ImageScriptLocationRepository>();
            services.AddTransient<IImageScriptLocationService, ImageScriptLocationService>();

            services.AddTransient<IImageBreakdownItemRepository, ImageBreakdownItemRepository>();
            services.AddTransient<IImageBreakdownItemService, ImageBreakdownItemService>();

            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<ICharacterService, CharacterService>();
            services.AddTransient<ICharacterSearchEngineService, CharacterSearchEngineService>();            

            services.AddTransient<IImageCharacterRepository, ImageCharacterRepository>();
            services.AddTransient<IImageCharacterService, ImageCharacterService>();

            services.AddTransient<ICharacterSceneRepository, CharacterSceneRepository>();
            services.AddTransient<ICharacterSceneService, CharacterSceneService>();
            
            services.AddTransient<IBreakdownTypeDefinitionRepository, BreakdownTypeDefinitionRepository>();
            services.AddTransient<IBreakdownTypeRepository, BreakdownTypeRepository>();
            services.AddTransient<IBreakdownTypeService, BreakdownTypeService>();

            services.AddTransient<IBreakdownItemRepository, BreakdownItemRepository>();
            services.AddTransient<IBreakdownItemService, BreakdownItemService>();
            services.AddTransient<IBreakdownItemSearchEngineService, BreakdownItemSearchEngineService>(); 

            services.AddTransient<IBreakdownItemSceneRepository, BreakdownItemSceneRepository>();
            services.AddTransient<IBreakdownItemSceneService, BreakdownItemSceneService>();
            
            services.AddTransient<IScheduleDayRepository, ScheduleDayRepository>();
            services.AddTransient<IScheduleDayService, ScheduleDayService>();

            services.AddTransient<IScheduleSceneRepository, ScheduleSceneRepository>();
            services.AddTransient<IScheduleSceneService, ScheduleSceneService>();

            services.AddTransient<IScheduleDayNoteRepository, ScheduleDayNoteRepository>();
            services.AddTransient<IScheduleDayNoteService, ScheduleDayNoteService>();

            services.AddTransient<IScheduleCharacterRepository, ScheduleCharacterRepository>();
            services.AddTransient<IScheduleCharacterService, ScheduleCharacterService>();

            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<ILocationService, LocationService>();

            services.AddTransient<ILocationSetRepository, LocationSetRepository>();
            services.AddTransient<ILocationSetService, LocationSetService>();

            services.AddTransient<ISearchEngineServiceWrapper, SearchEngineServiceWrapper>();
        }
    }
}