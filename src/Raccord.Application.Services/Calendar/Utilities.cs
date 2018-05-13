using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Common.Routing;
using Raccord.Application.Core.Services.Calendar;
using Raccord.Core.Enums;
using Raccord.Domain.Model.ShootingDays;

namespace Raccord.Application.Services.Calendar
{
  public static class Utilities
  {
    public static CalendarItemDto TranslateToCalendarItem(this ShootingDay shootingDay)
    {
      var entityType = GetShootingDayType(shootingDay);

      return new CalendarItemDto
      {
        Label = $"{shootingDay.CrewUnit.Project.Title} - {GetTypeName(entityType)} # {shootingDay.Number}",
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
        return "Shooting Day";
      }
      if(entityType == EntityType.Callsheet)
      {
        return "Callsheet";
      }
      return "Schedule Day";
    }

    private static IEnumerable<long> GetRouteIDs(ShootingDay shootingDay, EntityType entityType)
    {
      if(entityType == EntityType.ShootingDay)
      {
        return new List<long>{ shootingDay.CrewUnit.ProjectID, shootingDay.ID };
      }
      if(entityType == EntityType.Callsheet)
      {
        return new List<long>{ shootingDay.CrewUnit.ProjectID, shootingDay.CallsheetID.Value };
      }
      return new List<long>{ shootingDay.CrewUnit.ProjectID, shootingDay.CrewUnitID };
    }
  }
}