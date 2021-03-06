using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Calendar;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
using Raccord.Data.EntityFramework.Repositories.Users;
using Raccord.Domain.Model.ShootingDays;
namespace Raccord.Application.Services.Calendar
{
  public class CalendarService : ICalendarService
  {
    private readonly IUserRepository _userRepository;
    private readonly IShootingDayRepository _shootingDayRepository;

    public CalendarService(
      IUserRepository userRepository,
      IShootingDayRepository shootingDayRepository
      ){
        _userRepository = userRepository;
        _shootingDayRepository = shootingDayRepository;
      }

    public IEnumerable<CalendarItemDto> GetCalendarItems(string userID, DateTime start, DateTime end)
    {
      var user = _userRepository.GetFull(userID);

      var shootingDays = new List<ShootingDay>();

      if(user.ProjectUsers.Any(pu => pu.CrewUnitMembers.Any()))
      {
        var crewUnitIDs = user.ProjectUsers.SelectMany(pu => pu.CrewUnitMembers.Select(cum => cum.CrewUnitID)).ToArray();
        shootingDays.AddRange(_shootingDayRepository.GetAllForCrewUnitCalendar(crewUnitIDs, start, end));
      }
      if(user.ProjectUsers.Any(pu=> pu.CastMemberID.HasValue))
      {
        var characterIDs = user.ProjectUsers.Where(pu => pu.CastMemberID.HasValue).SelectMany(pu => pu.CastMember.Characters.Select(c => c.ID)).ToArray();
        shootingDays.AddRange(_shootingDayRepository.GetAllForCharacterCalendar(characterIDs, start, end));
      }

      return shootingDays.Distinct().Select(sd => sd.TranslateToCalendarItem(true));
    }
    public IEnumerable<CalendarItemDto> GetCalendarItemsForProject(string userID, long projectID, DateTime start, DateTime end)
    {
      var user = _userRepository.GetFull(userID);

      var shootingDays = new List<ShootingDay>();

      var projectUsers = user.ProjectUsers.Where(pu => pu.ProjectID == projectID);

      if(projectUsers.Any(pu => pu.CrewUnitMembers.Any()))
      {
        var crewUnitIDs = user.ProjectUsers.SelectMany(pu => pu.CrewUnitMembers.Select(cum => cum.CrewUnitID)).ToArray();
        shootingDays.AddRange(_shootingDayRepository.GetAllForCrewUnitCalendar(crewUnitIDs, start, end));
      }
      if(user.ProjectUsers.Any(pu=> pu.CastMemberID.HasValue))
      {
        var characterIDs = user.ProjectUsers.Where(pu => pu.CastMemberID.HasValue).SelectMany(pu => pu.CastMember.Characters.Select(c => c.ID)).ToArray();
        shootingDays.AddRange(_shootingDayRepository.GetAllForCharacterCalendar(characterIDs, start, end));
      }

      return shootingDays.Distinct().Select(sd => sd.TranslateToCalendarItem(false));
    }

    public IEnumerable<CalendarItemDto> GetCalendarItemScenes(string userID, long projectID, DateTime start, DateTime end)
    {
      var user = _userRepository.GetFull(userID);

      var shootingDays = new List<ShootingDay>();

      var projectUsers = user.ProjectUsers.Where(pu => pu.ProjectID == projectID);

      if(projectUsers.Any(pu => pu.CrewUnitMembers.Any()))
      {
        var crewUnitIDs = projectUsers.SelectMany(pu => pu.CrewUnitMembers.Select(cum => cum.CrewUnitID)).ToArray();
        shootingDays.AddRange(_shootingDayRepository.GetAllForCrewUnitCalendarScenes(crewUnitIDs, start, end));
      }
      if(projectUsers.Any(pu=> pu.CastMemberID.HasValue))
      {
        var characterIDs = projectUsers.Where(pu => pu.CastMemberID.HasValue).SelectMany(pu => pu.CastMember.Characters.Select(c => c.ID)).ToArray();
        shootingDays.AddRange(_shootingDayRepository.GetAllForCharacterCalendarScenes(characterIDs, start, end));
      }

      return shootingDays.Distinct().SelectMany(sd => sd.TranslateToCalendarItemScenes());
    }
  }
}