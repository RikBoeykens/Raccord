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

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class CalendarController : AbstractProjectsController
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(
            ICalendarService calendarService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if(calendarService == null)
                throw new ArgumentNullException(nameof(calendarService));

            _calendarService = calendarService;
        }

        // GET: api/calendar
        [HttpGet]
        public IEnumerable<CalendarItemViewModel> GetAllForUser(long authProjectId, [FromQuery]DateTime start, [FromQuery]DateTime end)
        {
            var dtos = _calendarService.GetCalendarItemScenes(GetUserId(), authProjectId, start, end);

            return dtos.Select(p => p.Translate());
        }
    }
}
