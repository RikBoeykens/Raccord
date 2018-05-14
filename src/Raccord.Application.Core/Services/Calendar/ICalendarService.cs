using System;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Calendar
{
    // Interface for calendar functionality
    public interface ICalendarService
    {
        IEnumerable<CalendarItemDto> GetCalendarItems(string userID, DateTime start, DateTime end);
        IEnumerable<CalendarItemDto> GetCalendarItemScenes(string userID, long projectID, DateTime start, DateTime end);
    }
}