using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Calendar;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Crew.Departments;
using Raccord.Application.Core.Services.Calendar;
using Raccord.Application.Core.Services.Crew.Departments;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class CalendarController : AbstractApiAuthController
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(
            ICalendarService calendarService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (calendarService == null)
                throw new ArgumentNullException(nameof(calendarService));

            _calendarService = calendarService;
        }

        // GET: api/calendar/user
        [HttpGet("user")]
        public IEnumerable<CalendarItemViewModel> GetAllForUser([FromQuery]DateTime start, [FromQuery]DateTime end)
        {
            var dtos = _calendarService.GetCalendarItems(GetUserId(), start, end);

            return dtos.Select(p => p.Translate());
        }
    }
}
