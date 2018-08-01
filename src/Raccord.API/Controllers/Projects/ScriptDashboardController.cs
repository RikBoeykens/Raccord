using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.API.ViewModels.Core;
using Raccord.API.Filters;
using Raccord.Core.Enums;
using Raccord.Application.Core.Services.Calendar;
using Raccord.API.ViewModels.Calendar;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.API.ViewModels.Dashboards;
using Raccord.API.ViewModels.Common.Paging;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.Application.Core.Common.Paging;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class ScriptDashboardController : AbstractProjectsController
    {
        private readonly ISceneService _sceneService;
        private readonly ICharacterService _characterService;
        private readonly IScriptLocationService _scriptLocationService;
        private readonly int _defaultScenePageSize = 10;
        private readonly int _defaultPageSize = 4;

        public ScriptDashboardController(
            ISceneService sceneService,
            ICharacterService characterService,
            IScriptLocationService scriptLocationService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            _sceneService = sceneService;
            _characterService = characterService;
            _scriptLocationService = scriptLocationService;
        }

        // GET: api/admin/dashboard
        [HttpGet]
        public ScriptDashboardViewModel Get(long authProjectId)
        {
            var scenes = GetScenes(authProjectId);
            var characters = GetCharacters(authProjectId);
            var locations = GetLocations(authProjectId);
            return new ScriptDashboardViewModel
            {
                Scenes = scenes,
                Characters = characters,
                ScriptLocations = locations
            };
        }

        private PagedDataViewModel<SceneSummaryViewModel> GetScenes(long authProjectId)
        {
            var paginatedScenes = _sceneService.Filter(new SceneFilterRequestDto
            {
                ProjectID = authProjectId
            },
            new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultScenePageSize
            });

            return paginatedScenes.Translate<SceneSummaryViewModel, SceneSummaryDto>(x => x.Translate());
        }

        private PagedDataViewModel<CharacterSummaryViewModel> GetCharacters(long authProjectId)
        {
            var paginatedCharacters = _characterService.GetPagedForProject(new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            }, authProjectId);

            return paginatedCharacters.Translate<CharacterSummaryViewModel, CharacterSummaryDto>(x => x.Translate());
        }

        private PagedDataViewModel<ScriptLocationSummaryViewModel> GetLocations(long authProjectId)
        {
            var paginatedLocations = _scriptLocationService.GetPagedForProject(new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            }, authProjectId);

            return paginatedLocations.Translate<ScriptLocationSummaryViewModel, ScriptLocationSummaryDto>(x=> x.Translate());
        }
    }
}
