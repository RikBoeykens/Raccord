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
using Raccord.Application.Core.Services.Scheduling;
using Raccord.Application.Core.Services.Callsheets;
using Raccord.API.ViewModels.Scheduling;
using Raccord.API.ViewModels.Callsheets;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class SchedulingDashboardController : AbstractProjectsController
    {
        private readonly IScheduleService _scheduleService;
        private readonly ICallsheetService _callsheetService;
        private readonly int _defaultPageSize = 4;

        public SchedulingDashboardController(
            IScheduleService scheduleService,
            ICallsheetService callsheetService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            _scheduleService = scheduleService;
            _callsheetService = callsheetService;
        }

        // GET: api/admin/dashboard
        [HttpGet]
        public ScheduleDashboardViewModel Get(long authProjectId)
        {
            var schedules = GetSchedules(authProjectId);
            var callsheets = GetCallsheets(authProjectId);
            return new ScheduleDashboardViewModel
            {
                Schedules = schedules,
                Callsheets = callsheets
            };
        }

        private PagedDataViewModel<ScheduleCrewUnitSummaryViewModel> GetSchedules(long authProjectId)
        {
            var paginatedSchedules = _scheduleService.GetSchedulesForProjectPaged(authProjectId, new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            });

            return paginatedSchedules.Translate<ScheduleCrewUnitSummaryViewModel, ScheduleCrewUnitSummaryDto>(x => x.Translate());
        }

        private PagedDataViewModel<CallsheetCrewUnitViewModel> GetCallsheets(long authProjectId)
        {
            var paginatedCallsheets = _callsheetService.GetForProject(authProjectId, new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            });

            return paginatedCallsheets.Translate<CallsheetCrewUnitViewModel, CallsheetCrewUnitDto>(x=> x.Translate());
        }
    }
}
