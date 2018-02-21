using System;
using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Scenes
{
    // Dto to filter scenes
  public class SceneFilterRequestDto
  {
    private IEnumerable<long> _intExtIDs;
    private IEnumerable<long> _scriptLocationIDs;
    private IEnumerable<long> _dayNightIDs;
    private IEnumerable<long> _locationSetIDs;
    private IEnumerable<long> _locationIDs;
    private IEnumerable<long> _characterIDs;
    private IEnumerable<long> _breakdownItemIDs;
    private IEnumerable<long> _scheduleDayIDs;
    private IEnumerable<long> _scheduleSceneShootingDayIDs;
    private IEnumerable<long> _callsheetIDs;
    private IEnumerable<long> _castMemberIDs;
    private IEnumerable<long> _callsheetSceneShootingDayIDs;
    private IEnumerable<long> _shootingDayIDs;

    public long ProjectID { get; set; }

    public string SearchText { get; set; }

    public int? MinPageLength { get; set; }

    public int? MaxPageLength { get; set; }

    public IEnumerable<long> IntExtIDs
    {
      get
      {
        return _intExtIDs ?? (_intExtIDs = new List<long>());
      }
      set
      {
        _intExtIDs = value;
      }
    }
    
    public IEnumerable<long> ScriptLocationIDs
    {
      get
      {
        return _scriptLocationIDs ?? (_scriptLocationIDs = new List<long>());
      }
      set
      {
        _scriptLocationIDs = value;
      }
    }
    
    public IEnumerable<long> DayNightIDs
    {
      get
      {
        return _dayNightIDs ?? (_dayNightIDs = new List<long>());
      }
      set
      {
        _dayNightIDs = value;
      }
    }
    
    public IEnumerable<long> LocationSetIDs
    {
      get
      {
        return _locationSetIDs ?? (_locationSetIDs = new List<long>());
      }
      set
      {
        _locationSetIDs = value;
      }
    }
    
    public IEnumerable<long> LocationIDs
    {
      get
      {
        return _locationIDs ?? (_locationIDs = new List<long>());
      }
      set
      {
        _locationIDs = value;
      }
    }
    
    public IEnumerable<long> CharacterIDs
    {
      get
      {
        return _characterIDs ?? (_characterIDs = new List<long>());
      }
      set
      {
        _characterIDs = value;
      }
    }
    
    public IEnumerable<long> CastMemberIDs
    {
      get
      {
        return _castMemberIDs ?? (_castMemberIDs = new List<long>());
      }
      set
      {
        _castMemberIDs = value;
      }
    }
    
    public IEnumerable<long> BreakdownItemIDs
    {
      get
      {
        return _breakdownItemIDs ?? (_breakdownItemIDs = new List<long>());
      }
      set
      {
        _breakdownItemIDs = value;
      }
    }
    
    public IEnumerable<long> ScheduleDayIDs
    {
      get
      {
        return _scheduleDayIDs ?? (_scheduleDayIDs = new List<long>());
      }
      set
      {
        _scheduleDayIDs = value;
      }
    }
    
    public IEnumerable<long> ScheduleSceneShootingDayIDs
    {
      get
      {
        return _scheduleSceneShootingDayIDs ?? (_scheduleSceneShootingDayIDs = new List<long>());
      }
      set
      {
        _scheduleSceneShootingDayIDs = value;
      }
    }
    
    public IEnumerable<long> CallsheetIDs
    {
      get
      {
        return _callsheetIDs ?? (_callsheetIDs = new List<long>());
      }
      set
      {
        _callsheetIDs = value;
      }
    }
    
    public IEnumerable<long> CallsheetSceneShootingDayIDs
    {
      get
      {
        return _callsheetSceneShootingDayIDs ?? (_callsheetSceneShootingDayIDs = new List<long>());
      }
      set
      {
        _callsheetSceneShootingDayIDs = value;
      }
    }
    
    public IEnumerable<long> ShootingDayIDs
    {
      get
      {
        return _shootingDayIDs ?? (_shootingDayIDs = new List<long>());
      }
      set
      {
        _shootingDayIDs = value;
      }
    }

  }
}