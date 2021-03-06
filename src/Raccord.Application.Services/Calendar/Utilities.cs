using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Common.Routing;
using Raccord.Application.Core.Services.Calendar;
using Raccord.Application.Services.Scenes;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Callsheets;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.ShootingDays;
using System;

namespace Raccord.Application.Services.Calendar
{
  public static class Utilities
  {
    public static CalendarItemDto TranslateToCalendarItem(this ShootingDay shootingDay, bool addProjectTitle)
    {
      var entityType = GetShootingDayType(shootingDay);

      var label = $"{GetTypeName(entityType)} # {shootingDay.Number} - {shootingDay.CrewUnit.Name}";
      if(addProjectTitle)
      {
        label = $"{shootingDay.CrewUnit.Project.Title} - {label}";
      }
      return new CalendarItemDto
      {
        Label = label,
        Date = shootingDay.Date,
        RouteInfo = new RouteInfoDto
        {
          Type = entityType,
          RouteIDs = GetRouteIDs(shootingDay, entityType)
        }
      };
    }

    private static EntityType GetShootingDayType(ShootingDay shootingDay)
    {
      if (shootingDay.Completed){
        return EntityType.ShootingDay;
      } else if (shootingDay.CallsheetID.HasValue){
        return EntityType.Callsheet;
      } else
      {
        return EntityType.ScheduleDay;
      }
    }

    private static string GetTypeName(EntityType entityType)
    {
      if(entityType == EntityType.ShootingDay)
      {
        return "Day";
      }
      if(entityType == EntityType.Callsheet)
      {
        return "Callsheet";
      }
      return "Day";
    }

    private static IEnumerable<object> GetRouteIDs(ShootingDay shootingDay, EntityType entityType)
    {
      if(entityType == EntityType.ShootingDay)
      {
        return new List<object>{ shootingDay.CrewUnit.ProjectID, shootingDay.ID };
      }
      if(entityType == EntityType.Callsheet)
      {
        return new List<object>{ shootingDay.CrewUnit.ProjectID, shootingDay.CallsheetID.Value };
      }
      if(entityType == EntityType.ScheduleDay)
      {
        return new List<object>{ shootingDay.CrewUnit.ProjectID, shootingDay.CrewUnitID };
      }
      return new List<object>();
    }
    public static IEnumerable<CalendarItemDto> TranslateToCalendarItemScenes(this ShootingDay shootingDay)
    {
      var entityType = GetShootingDayType(shootingDay);

      if(entityType == EntityType.ShootingDay)
      {
        return GetScenesForShootingDay(shootingDay, shootingDay.CrewUnit.ProjectID);
      }

      if(entityType == EntityType.Callsheet)
      {
        return GetScenesForCallsheet(shootingDay.Callsheet, shootingDay.Date, shootingDay.CrewUnit.ProjectID);
      }

      if(entityType == EntityType.ScheduleDay)
      {
        return GetScenesForScheduleDay(shootingDay.ScheduleDay, shootingDay.CrewUnit.ProjectID);
      }
      return new List<CalendarItemDto>();
    }

    private static IEnumerable<CalendarItemDto> GetScenesForShootingDay(ShootingDay shootingDay, long projectID)
    {
      return shootingDay.ShootingDayScenes.Select(sds => new CalendarItemDto
      {
        Label = $"{sds.Scene.GetDisplaySummary()}",
        Date = shootingDay.Date,
        RouteInfo = new RouteInfoDto
        {
          Type = EntityType.Scene,
          RouteIDs = new List<object>{ projectID, sds.SceneID }
        }
      });
    }

    private static IEnumerable<CalendarItemDto> GetScenesForCallsheet(Callsheet callsheet, DateTime date, long projectID)
    {
      return callsheet.CallsheetScenes.Select(css => new CalendarItemDto
      {
        Label = $"{css.Scene.GetDisplaySummary()}",
        Date = date,
        RouteInfo = new RouteInfoDto
        {
          Type = EntityType.Scene,
          RouteIDs = new List<object>{ projectID, css.SceneID }
        }
      });
    }

    private static IEnumerable<CalendarItemDto> GetScenesForScheduleDay(ScheduleDay scheduleDay, long projectID)
    {
      return scheduleDay.ScheduleScenes.Select(ss => new CalendarItemDto
      {
        Label = $"{ss.Scene.GetDisplaySummary()}",
        Date = scheduleDay.Date,
        RouteInfo = new RouteInfoDto
        {
          Type = EntityType.Scene,
          RouteIDs = new List<object>{ projectID, ss.SceneID }
        }
      });
    }
  }
}