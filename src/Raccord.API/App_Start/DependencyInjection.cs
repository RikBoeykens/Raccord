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
using Raccord.Data.EntityFramework.Seeding;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
using Raccord.Data.EntityFramework.Repositories.Callsheets;
using Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.Application.Services.ShootingDays;
using Raccord.Application.Core.Services.Callsheets;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;
using Raccord.Application.Core.Services.Callsheets.CallsheetSceneCharacters;
using Raccord.Application.Services.Callsheets;
using Raccord.Application.Services.Callsheets.CallsheetScenes;
using Raccord.Application.Services.Callsheets.CallsheetSceneCharacters;
using Raccord.Data.EntityFramework.Repositories.Callsheets.CallTypes;
using Raccord.Data.EntityFramework.Repositories.Callsheets.Characters;
using Raccord.Application.Core.Services.Callsheets.Characters;
using Raccord.Application.Services.Callsheets.Characters;
using Raccord.Application.Core.Services.Callsheets.CharacterCalls;
using Raccord.Application.Services.Callsheets.CharacterCalls;
using Raccord.Application.Core.Services.Users;
using Raccord.Application.Services.Users;
using Raccord.Data.EntityFramework.Repositories.Users;
using Raccord.Application.Core.Services.Crew;
using Raccord.Application.Services.Crew;
using Raccord.Data.EntityFramework.Repositories.Shots.Slates;
using Raccord.Data.EntityFramework.Repositories.Shots.Takes;
using Raccord.Application.Core.Services.Shots.Slates;
using Raccord.Application.Services.Shots.Slates;
using Raccord.Application.Core.Services.Shots.Takes;
using Raccord.Application.Services.Shots.Takes;
using Raccord.Application.Core.Services.ImageSlates;
using Raccord.Application.Services.ImageSlates;
using Raccord.Data.EntityFramework.Repositories.ImageSlates;
using Raccord.Data.EntityFramework.Repositories.ShootingDays.Scenes;
using Raccord.Application.Core.Services.ShootingDays.Scenes;
using Raccord.Application.Services.ShootingDays.Scenes;
using Raccord.Application.Core.Services.Charts;
using Raccord.Application.Services.Charts;
using Raccord.Application.Core.Services.Charts.ChartBuilders;
using Raccord.Application.Services.Charts.ChartBuilders;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;
using Raccord.Application.Services.Users.Projects;
using Raccord.Application.Core.Services.Users.Project;
using Raccord.Data.EntityFramework.Repositories.Crew.Departments;
using Raccord.Application.Core.Services.Crew.Departments;
using Raccord.Application.Services.Crew.Departments;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewMembers;
using Raccord.Application.Services.Crew.CrewMembers;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Core.Services.ScriptUploads;
using Raccord.Application.Services.ScriptUploads;
using Raccord.Data.EntityFramework.Repositories.ScriptUploads;
using Raccord.Data.EntityFramework.Repositories.Scenes.Dialogues;
using Raccord.Data.EntityFramework.Repositories.Scenes.Actions;
using Raccord.Application.Core.Services.ScriptTexts;
using Raccord.Application.Services.ScriptTexts;
using Raccord.Application.Core.Services.Profile;
using Raccord.Application.Services.Profile;
using Raccord.Data.EntityFramework.Repositories.Comments;
using Raccord.Application.Core.Services.Comments;
using Raccord.Application.Services.Comments;
using Raccord.Data.EntityFramework.Repositories.Users.ProjectRoles;
using Raccord.Application.Core.Services.Users.ProjectRoles;
using Raccord.Application.Services.User.ProjectRoles;
using Raccord.Data.EntityFramework.Repositories.Breakdowns;
using Raccord.Application.Core.Services.Breakdowns;
using Raccord.Application.Services.Breakdowns;
using Raccord.Application.Services.Users.Project.Cast;
using Raccord.Application.Core.Services.Users.Project.Cast;
using Raccord.Data.EntityFramework.Repositories.Cast;
using Raccord.Application.Core.Services.Cast;
using Raccord.Application.Services.Cast;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Services.Crew.CrewUnits;
using Raccord.Data.EntityFramework.Repositories.Crew.CrewUnits.Members;
using Raccord.Application.Core.Services.Crew.CrewUnits.Members;
using Raccord.Application.Services.Crew.CrewUnits.Members;
using Raccord.Application.Core.Services.Calendar;
using Raccord.Application.Services.Calendar;
using Raccord.Application.Core.ExternalServices.Communication.Mail;
using Raccord.Application.ExternalServices.Communication.Mail;
using Raccord.Data.EntityFramework.Repositories.Users.Invitations;
using Raccord.Data.EntityFramework.Repositories.Users.Invitations.Projects;
using Raccord.Application.Core.Services.Users.Invitations;
using Raccord.Application.Services.Users.Invitations.Project;
using Raccord.Application.Core.Services.Users.Invitations.Project;
using Raccord.Application.Services.Users.Invitations;
using Raccord.Application.Core.ExternalServices.Location;
using Raccord.Application.ExternalServices.Location;
using Raccord.Application.Core.ExternalServices.Weather;
using Raccord.Application.ExternalServices.Weather;
using Raccord.Application.Services.Users.Invitations.Project.Cast;
using Raccord.Application.Core.Services.Users.Invitations.Project.Cast;

namespace Raccord.API
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            ConfigureInternalServices(services);
            ConfigureExternalService(services);
        }

        private static void ConfigureInternalServices(IServiceCollection services)
        {
            services.AddTransient<RaccordDBContextSeeding>();

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
            services.AddTransient<ILocationSearchEngineService, LocationSearchEngineService>();

            services.AddTransient<ILocationSetRepository, LocationSetRepository>();
            services.AddTransient<ILocationSetService, LocationSetService>();

            services.AddTransient<IShootingDayRepository, ShootingDayRepository>();
            services.AddTransient<IShootingDayService, ShootingDayService>();

            services.AddTransient<ICallsheetRepository, CallsheetRepository>();
            services.AddTransient<ICallsheetService, CallsheetService>();

            services.AddTransient<ICallsheetSceneRepository, CallsheetSceneRepository>();
            services.AddTransient<ICallsheetSceneService, CallsheetSceneService>();

            services.AddTransient<ICallsheetSceneCharacterRepository, CallsheetSceneCharacterRepository>();            
            services.AddTransient<ICallsheetSceneCharacterService, CallsheetSceneCharacterService>();

            services.AddTransient<ICallTypeRepository, CallTypeRepository>();
            services.AddTransient<ICallTypeDefinitionRepository, CallTypeDefinitionRepository>();

            services.AddTransient<ICallsheetCharacterRepository, CallsheetCharacterRepository>();
            services.AddTransient<ICallsheetCharacterService, CallsheetCharacterService>();

            services.AddTransient<ICharacterCallRepository, CharacterCallRepository>();
            services.AddTransient<ICharacterCallService, CharacterCallService>();

            services.AddTransient<ISearchEngineServiceWrapper, SearchEngineServiceWrapper>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IProjectUserRepository, ProjectUserRepository>();            
            services.AddTransient<IProjectUserService, ProjectUserService>();            

            services.AddTransient<ISlateRepository, SlateRepository>();
            services.AddTransient<ISlateService, SlateService>();
            services.AddTransient<ISlateSearchEngineService, SlateSearchEngineService>();

            services.AddTransient<IImageSlateRepository, ImageSlateRepository>();
            services.AddTransient<IImageSlateService, ImageSlateService>();

            services.AddTransient<ITakeRepository, TakeRepository>(); 
            services.AddTransient<ITakeService, TakeService>(); 

            services.AddTransient<IShootingDaySceneRepository, ShootingDaySceneRepository>();   
            services.AddTransient<IShootingDaySceneService, ShootingDaySceneService>();   

            services.AddTransient<IChartService, ChartService>();   
            services.AddTransient<IBurndownByPagelengthChartBuilder, BurndownByPagelengthChartBuilder>(); 
            services.AddTransient<IBurndownBySceneChartBuilder, BurndownBySceneChartBuilder>();
            services.AddTransient<ICompletedByPagelengthChartBuilder, CompletedByPagelengthChartBuilder>();   
            services.AddTransient<ICompletedBySceneChartBuilder, CompletedBySceneChartBuilder>();   
            services.AddTransient<IPageLengthByDayChartBuilder, PageLengthByDayChartBuilder>();
            services.AddTransient<ICumulativeTimingsByDayChartBuilder, CumulativeTimingsByDayChartBuilder>();
            services.AddTransient<ICumulativeSetupsByDayChartBuilder, CumulativeSetupsByDayChartBuilder>();
            services.AddTransient<ISetupsByDayChartBuilder, SetupsByDayChartBuilder>();
            services.AddTransient<IVfxSetupsChartBuilder, VfxSetupsChartBuilder>();

            services.AddTransient<ICrewDepartmentDefinitionRepository, CrewDepartmentDefinitionRepository>(); 
            services.AddTransient<ICrewDepartmentRepository, CrewDepartmentRepository>();  
            services.AddTransient<ICrewDepartmentService, CrewDepartmentService>(); 
             
            services.AddTransient<ICrewMemberRepository, CrewMemberRepository>();
            services.AddTransient<ICrewMemberService, CrewMemberService>();
            services.AddTransient<ICrewMemberSearchEngineService, CrewMemberSearchEngineService>();

            services.AddTransient<IScriptUploadRepository, ScriptUploadRepository>();
            services.AddTransient<IScriptUploadService, ScriptUploadService>();

            services.AddTransient<ISceneActionRepository, SceneActionRepository>();
            services.AddTransient<ISceneDialogueRepository, SceneDialogueRepository>();

            services.AddTransient<IScriptTextService, ScriptTextService>();

            services.AddTransient<IUserProfileService, UserProfileService>();

            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddTransient<IProjectRoleDefinitionRepository, ProjectRoleDefinitionRepository>();
            services.AddTransient<IProjectRoleService, ProjectRoleService>();
            services.AddTransient<IProjectPermissionService, ProjectPermissionService>();

            services.AddTransient<IBreakdownRepository, BreakdownRepository>();
            services.AddTransient<IBreakdownService, BreakdownService>();

            services.AddTransient<IProjectUserCastService, ProjectUserCastService>();
            services.AddTransient<IProjectUserInvitationCastService, ProjectUserInvitationCastService>();

            services.AddTransient<ICastMemberRepository, CastMemberRepository>();
            services.AddTransient<ICastMemberService, CastMemberService>();
            services.AddTransient<ICastMemberSearchEngineService, CastMemberSearchEngineService>();

            services.AddTransient<ICrewUnitRepository, CrewUnitRepository>();
            services.AddTransient<ICrewUnitService, CrewUnitService>();

            services.AddTransient<ICrewUnitMemberRepository, CrewUnitMemberRepository>();
            services.AddTransient<ICrewUnitInvitationMemberRepository, CrewUnitInvitationMemberRepository>();
            services.AddTransient<ICrewUnitMemberService, CrewUnitMemberService>();
            services.AddTransient<ICrewUnitInvitationMemberService, CrewUnitInvitationMemberService>();
            services.AddTransient<ICrewUnitMemberCrewMemberService, CrewUnitMemberCrewMemberService>();
            services.AddTransient<ICrewUnitInvitationMemberCrewMemberService, CrewUnitInvitationMemberCrewMemberService>();

            services.AddTransient<ICalendarService, CalendarService>();

            services.AddTransient<IUserInvitationRepository, UserInvitationRepository>();
            services.AddTransient<IUserInvitationService, UserInvitationService>();

            services.AddTransient<IProjectUserInvitationRepository, ProjectUserInvitationRepository>();
            services.AddTransient<IProjectUserInvitationService, ProjectUserInvitationService>();
        }

        private static void ConfigureExternalService(IServiceCollection services)
        {
            services.AddTransient<ISendMailService, SendMailService>();
            services.AddTransient<IGeocodingService, GeocodingService>();
            services.AddTransient<IWeatherService, WeatherService>();
        }
    }
}