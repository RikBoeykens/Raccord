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
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.API.ViewModels.ShootingDays;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class CrewUnitDashboardController : AbstractProjectsController
    {
        private readonly ICrewUnitService _crewUnitService;
        private readonly IScheduleService _scheduleService;
        private readonly ICallsheetService _callsheetService;
        private readonly IShootingDayService _shootingDayService;
        private readonly int _defaultPageSize = 10;

        public CrewUnitDashboardController(
            ICrewUnitService crewUnitService,
            IScheduleService scheduleService,
            ICallsheetService callsheetService,
            IShootingDayService shootingDayService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            _crewUnitService = crewUnitService;
            _scheduleService = scheduleService;
            _callsheetService = callsheetService;
            _shootingDayService = shootingDayService;
        }

        // GET: api/admin/dashboard
        [HttpGet("{crewUnitId}")]
        public CrewUnitDashboardViewModel Get(long authProjectId, long crewUnitId)
        {
            var crewUnit = _crewUnitService.GetSummary(crewUnitId);
            var schedules = GetSchedules(authProjectId, crewUnitId);
            var callsheets = GetCallsheets(authProjectId, crewUnitId);
            var shootingDays = GetShootingDays(authProjectId, crewUnitId);
            return new CrewUnitDashboardViewModel
            {
                CrewUnit = crewUnit.Translate(),
                Schedules = schedules,
                Callsheets = callsheets,
                ShootingDays = shootingDays
            };
        }

        private PagedDataViewModel<ScheduleSummaryViewModel> GetSchedules(long authProjectId, long crewUnitId)
        {
            var paginatedSchedules = _scheduleService.GetSchedulesForCrewUnitPaged(crewUnitId, new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            });

            return paginatedSchedules.Translate<ScheduleSummaryViewModel, ScheduleSummaryDto>(x => x.Translate());
        }

        private PagedDataViewModel<CallsheetSummaryViewModel> GetCallsheets(long authProjectId, long crewUnitId)
        {
            var paginatedCallsheets = _callsheetService.GetForCrewUnit(crewUnitId, new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            });

            return paginatedCallsheets.Translate<CallsheetSummaryViewModel, CallsheetSummaryDto>(x=> x.Translate());
        }

        private PagedDataViewModel<ShootingDaySummaryViewModel> GetShootingDays(long authProjectId, long crewUnitId)
        {
            var paginatedShootingDays = _shootingDayService.GetCompletedForCrewUnitPaged(crewUnitId, new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            });

            return paginatedShootingDays.Translate<ShootingDaySummaryViewModel, ShootingDaySummaryDto>(x=> x.Translate());
        }
    }
}
