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
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.API.ViewModels.Locations.Locations;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class LocationDashboardController : AbstractProjectsController
    {
        private readonly ILocationService _locationService;
        private readonly IScriptLocationService _scriptLocationService;
        private readonly int _defaultPageSize = 4;

        public LocationDashboardController(
            ILocationService locationService,
            IScriptLocationService scriptLocationService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            _locationService = locationService;
            _scriptLocationService = scriptLocationService;
        }

        // GET: api/admin/dashboard
        [HttpGet]
        public LocationDashboardViewModel Get(long authProjectId)
        {
            var locations = GetLocations(authProjectId);
            var scriptLocations = GetScriptLocations(authProjectId);
            return new LocationDashboardViewModel
            {
                Locations = locations,
                ScriptLocations = scriptLocations
            };
        }

        private PagedDataViewModel<LocationSummaryViewModel> GetLocations(long authProjectId)
        {
            var paginatedLocations = _locationService.GetPagedForProject(new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            }, authProjectId);

            return paginatedLocations.Translate<LocationSummaryViewModel, LocationSummaryDto>(x => x.Translate());
        }

        private PagedDataViewModel<ScriptLocationSummaryViewModel> GetScriptLocations(long authProjectId)
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
