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
    public class SchedulesController : AbstractProjectsController
    {
        private readonly IScheduleService _scheduleService;
        private readonly int _defaultPageSize = 4;

        public SchedulesController(
            IScheduleService scheduleService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            _scheduleService = scheduleService;
        }

        // GET: api/schedules
        [HttpGet]
        public PagedDataViewModel<ScheduleSummaryViewModel> Get(long authProjectId)
        {
            var paginatedSchedules = _scheduleService.GetSchedulesPaged(authProjectId, new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            });

            return paginatedSchedules.Translate<ScheduleSummaryViewModel, ScheduleSummaryDto>(x => x.Translate());
        }
    }
}
