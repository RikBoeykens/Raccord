using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Example;
using Raccord.Application.Core.Common.Location;
using Raccord.Application.Core.Common.Sorting;
using Raccord.Application.Core.Services.Breakdowns;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
using Raccord.Application.Core.Services.Callsheets;
using Raccord.Application.Core.Services.Callsheets.CallsheetSceneCharacters;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;
using Raccord.Application.Core.Services.Callsheets.CharacterCalls;
using Raccord.Application.Core.Services.Callsheets.Characters;
using Raccord.Application.Core.Services.Cast;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.CharacterScenes;
using Raccord.Application.Core.Services.Comments;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Core.Services.Crew.Departments;
using Raccord.Application.Core.Services.Locations.Locations;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Projects;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Scheduling.ScheduleCharacters;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.ScriptTexts;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.Application.Core.Services.Users;
using Raccord.Application.Core.Services.Users.Project;
using Raccord.Core.Enums;

namespace Raccord.API.Controllers.Admin
{
  public class ExampleController : AbstractAdminController
  {
    private readonly IProjectService _projectService;
    private readonly ISceneIntroService _sceneIntroService;
    private readonly ITimeOfDayService _timeOfDayService;
    private readonly IScriptLocationService _scriptLocationService;
    private readonly ICharacterService _characterService;
    private readonly ISceneService _sceneService;
    private readonly IScriptTextService _scriptTextService;
    private readonly ICharacterSceneService _characterSceneService;
    private readonly ICrewUnitService _crewUnitService;
    private readonly ILocationService _locationService;
    private readonly ILocationSetService _locationSetService;
    private readonly IScheduleDayService _scheduleDayService;
    private readonly IScheduleSceneService _scheduleSceneService;
    private readonly IScheduleCharacterService _scheduleCharacterService;
    private readonly ICallsheetService _callsheetService;
    private readonly ICallsheetSceneService _callsheetSceneService;
    private readonly ICallsheetSceneCharacterService _callsheetSceneCharacterService;
    private readonly ICallsheetCharacterService _callsheetCharacterService;
    private readonly ICharacterCallService _characterCallService;
    private readonly IUserService _userService;
    private readonly IProjectUserService _projectUserService;
    private readonly ICommentService _commentService;
    private readonly ICastMemberService _castMemberService;
    private readonly ICrewDepartmentService _crewDepartmentService;
    private readonly ICrewMemberService _crewMemberService;
    private readonly IBreakdownService _breakdownService;
    private readonly IBreakdownTypeService _breakdownTypeService;
    private readonly IBreakdownItemService _breakdownItemService;
    private readonly IBreakdownItemSceneService _breakdownItemSceneService;
    private static Random _rnd = new Random();
    public ExampleController(
      IProjectService projectService,
      ISceneIntroService sceneIntroService,
      ITimeOfDayService timeOfDayService,
      IScriptLocationService scriptLocationService,
      ICharacterService characterService,
      ISceneService sceneService,
      IScriptTextService scriptTextService,
      ICharacterSceneService characterSceneService,
      ICrewUnitService crewUnitService,
      ILocationService locationService,
      ILocationSetService locationSetService,
      IScheduleDayService scheduleDayService,
      IScheduleSceneService scheduleSceneService,
      IScheduleCharacterService scheduleCharacterService,
      ICallsheetService callsheetService,
      ICallsheetSceneService callsheetSceneService,
      ICallsheetSceneCharacterService callsheetSceneCharacterService,
      ICallsheetCharacterService callsheetCharacterService,
      ICharacterCallService characterCallService,
      IUserService userService,
      IProjectUserService projectUserService,
      ICommentService commentService,
      ICastMemberService castMemberService,
      ICrewDepartmentService crewDepartmentService,
      ICrewMemberService crewMemberService,
      IBreakdownService breakdownService,
      IBreakdownTypeService breakdownTypeService,
      IBreakdownItemService breakdownItemService,
      IBreakdownItemSceneService breakdownItemSceneService
      ): base()
    {
      _projectService = projectService;
      _sceneIntroService = sceneIntroService;
      _timeOfDayService = timeOfDayService;
      _characterService = characterService;
      _scriptLocationService = scriptLocationService;
      _sceneService = sceneService;
      _scriptTextService = scriptTextService;
      _characterSceneService = characterSceneService;
      _crewUnitService = crewUnitService;
      _locationService = locationService;
      _locationSetService = locationSetService;
      _scheduleDayService = scheduleDayService;
      _scheduleSceneService = scheduleSceneService;
      _scheduleCharacterService = scheduleCharacterService;
      _callsheetService = callsheetService;
      _callsheetSceneService = callsheetSceneService;
      _callsheetSceneCharacterService = callsheetSceneCharacterService;
      _callsheetCharacterService = callsheetCharacterService;
      _characterCallService = characterCallService;
      _userService = userService;
      _projectUserService = projectUserService;
      _commentService = commentService;
      _castMemberService = castMemberService;
      _crewDepartmentService = crewDepartmentService;
      _crewMemberService = crewMemberService;
      _breakdownService = breakdownService;
      _breakdownTypeService = breakdownTypeService;
      _breakdownItemService = breakdownItemService;
      _breakdownItemSceneService = breakdownItemSceneService;
    }

    // POST api/example
    [HttpPost]
    public async Task<JsonResult> Post([FromBody]CreateExampleViewModel vm)
    {
      var response = new JsonResponse();

      try
      {
        var projectId = CreateProject(vm.ProjectName);
        
        var sceneIntroIds = CreateSceneIntros(projectId);
        var timeOfDayIds = CreateTimesOfDay(projectId);
        var scriptLocationIds = CreateScriptLocations(projectId);

        var characterIds = CreateCharacters(projectId);

        var sceneIds = CreateScenes(projectId, sceneIntroIds, timeOfDayIds, characterIds, scriptLocationIds);

        var characterSceneIds = LinkScenesToCharacters(sceneIds, characterIds);

        var crewUnitIds = CreateUnits(projectId);

        var userIds = await CreateUsers(projectId);

        CreateCast(projectId, characterIds);
        CreateCrew(projectId, crewUnitIds);

        var locationIds = CreateLocations(projectId);

        var locationSetIds = CreateLocationSets(locationIds, scriptLocationIds);

        var scheduleDayIds = CreateScheduleDays(projectId, crewUnitIds);

        var scheduleSceneIds = CreateScheduleScenes(scheduleDayIds, sceneIds, locationSetIds, characterSceneIds);

        _scheduleDayService.PublishDays(crewUnitIds.mainUnitId);
        _scheduleDayService.PublishDays(crewUnitIds.secondUnitId);

        var callsheetIds = CreateCallsheets(projectId, crewUnitIds, scheduleDayIds);

        var breakdownId = CreateBreakdown(projectId, userIds.jamesSmithId);

        var breakdownItemIds = CreateBreakdownItems(breakdownId);

        LinkBreakdownItemScenes(breakdownItemIds, sceneIds);

        CreateComments(userIds, characterIds, callsheetIds, scriptLocationIds, locationIds, breakdownItemIds, sceneIds);

        response = new JsonResponse
        {
          ok = true,
          data = projectId,
        };
      }
      catch (Exception ex)
      {
        response = new JsonResponse
        {
          ok = false,
          message = ex.Message,
        };
      }

      return new JsonResult(response);
    }

    private long CreateProject(string projectName)
    {
      return _projectService.Add(new ProjectDto
      {
        Title = projectName
      });
    }

#region script
    private (long intId, long extId, long intExtId) CreateSceneIntros(long projectId)
    {
      var intId = _sceneIntroService.Add(new SceneIntroDto
      {
        Name = "INT",
        ProjectID = projectId
      });
      var extId = _sceneIntroService.Add(new SceneIntroDto
      {
        Name = "EXT",
        ProjectID = projectId
      });
      var intExtId = _sceneIntroService.Add(new SceneIntroDto
      {
        Name = "INT/EXT",
        ProjectID = projectId
      });
      return (intId, extId, intExtId);
    }

    private (long dayId, long nightId) CreateTimesOfDay(long projectId)
    {
      var dayId = _timeOfDayService.Add(new TimeOfDayDto
      {
        Name = "DAY",
        ProjectID = projectId
      });
      var nightId = _timeOfDayService.Add(new TimeOfDayDto
      {
        Name = "NIGHT",
        ProjectID = projectId
      });
      return (dayId, nightId);
    }

    private (
      long houseId,
      long houseLivingRoomId,
      long houseKitchenId,
      long bobsCarStreetId,
      long highwayId,
      long forestId
    ) CreateScriptLocations(long projectId){
      var houseId = _scriptLocationService.Add(new ScriptLocationDto
      {
        Name = "HOUSE",
        ProjectID = projectId
      });
      var houseLivingRoomId = _scriptLocationService.Add(new ScriptLocationDto
      {
        Name = "HOUSE LIVING ROOM",
        ProjectID = projectId
      });
      var houseKitchenId = _scriptLocationService.Add(new ScriptLocationDto
      {
        Name = "HOUSE KITCHEN",
        ProjectID = projectId
      });
      var bobsCarStreetId = _scriptLocationService.Add(new ScriptLocationDto
      {
        Name = "BOB'S CAR / STREET",
        ProjectID = projectId
      });
      var highWayId = _scriptLocationService.Add(new ScriptLocationDto
      {
        Name = "HIGHWAY",
        ProjectID = projectId
      });
      var forestId = _scriptLocationService.Add(new ScriptLocationDto
      {
        Name = "FOREST",
        ProjectID = projectId
      });
      return (houseId, houseLivingRoomId, houseKitchenId, bobsCarStreetId, highWayId, forestId);
    }

    private (long aliceId, long bobId, long charlieId) CreateCharacters(long projectId)
    {
      var aliceId = _characterService.Add(new CharacterDto
      {
        Number = 1,
        Name = "Alice",
        ProjectID = projectId
      });
      var bobId = _characterService.Add(new CharacterDto
      {
        Number = 2,
        Name = "Bob",
        ProjectID = projectId
      });
      var charlieId = _characterService.Add(new CharacterDto
      {
        Number = 3,
        Name = "Charlie",
        ProjectID = projectId
      });
      return (aliceId, bobId, charlieId);
    }

    private (
      long scene1Id,
      long scene2Id,
      long scene3Id,
      long scene4Id,
      long scene5Id,
      long scene5AId,
      long scene6Id
    ) CreateScenes(
      long projectId,
      (long intId, long extId, long intExtId) sceneIntroIds,
      (long dayId, long nightId) timeofDayIds,
      (long aliceId, long bobId, long charlieId) characterIds,
      (long houseId,
        long houseLivingRoomId,
        long houseKitchenId,
        long bobsCarStreetId,
        long highwayId,
        long forestId
      ) scriptLocationIds
    ) {
      // 1 EXT. HOUSE DAY - Establishing shot of Alice's house (1/8)
      var scene1Id = _sceneService.Add(new SceneDto
      {
        Number = "1",
        SceneIntro = new SceneIntroDto{ ID = sceneIntroIds.extId},
        ScriptLocation = new ScriptLocationDto{ ID = scriptLocationIds.houseId},
        TimeOfDay = new TimeOfDayDto{ ID = timeofDayIds.dayId},
        Summary = "Establishing shot of Alice's house",
        PageLength = 1,
        ProjectID = projectId
      });
      AddScene1Text(scene1Id);

      // 2 INT. HOUSE - LIVING ROOM DAY - Alice is getting ready to go (3/8)
      var scene2Id = _sceneService.Add(new SceneDto
      {
        Number = "2",
        SceneIntro = new SceneIntroDto{ ID = sceneIntroIds.intId},
        ScriptLocation = new ScriptLocationDto{ ID = scriptLocationIds.houseLivingRoomId},
        TimeOfDay = new TimeOfDayDto{ ID = timeofDayIds.dayId},
        Summary = "Alice is getting ready to go",
        PageLength = 3,
        ProjectID = projectId
      });
      AddScene2Text(scene2Id);

      // 3 INT. HOUSE - KITCHEN DAY - Alice picks up her phone from the kitchen (3/8)
      var scene3Id = _sceneService.Add(new SceneDto
      {
        Number = "3",
        SceneIntro = new SceneIntroDto{ ID = sceneIntroIds.intId},
        ScriptLocation = new ScriptLocationDto{ ID = scriptLocationIds.houseKitchenId},
        TimeOfDay = new TimeOfDayDto{ ID = timeofDayIds.dayId},
        Summary = "Alice picks up her phone from the kitchen",
        PageLength = 4,
        ProjectID = projectId
      });
      AddScene3Text(scene3Id, characterIds.aliceId);

      // 4 EXT. HOUSE DAY - Bob is waiting for Alice outside (5/8)
      var scene4Id = _sceneService.Add(new SceneDto
      {
        Number = "4",
        SceneIntro = new SceneIntroDto{ ID = sceneIntroIds.extId},
        ScriptLocation = new ScriptLocationDto{ ID = scriptLocationIds.houseId},
        TimeOfDay = new TimeOfDayDto{ ID = timeofDayIds.dayId},
        Summary = "Bob is waiting for Alice outside",
        PageLength = 5,
        ProjectID = projectId
      });
      AddScene4Text(scene4Id, characterIds.aliceId, characterIds.bobId);

      // 5 INT/EXT. BOB'S CAR/STREET - Alice and Bob talk about where they're going (1 1/8)
      var scene5Id = _sceneService.Add(new SceneDto
      {
        Number = "5",
        SceneIntro = new SceneIntroDto{ ID = sceneIntroIds.intExtId},
        ScriptLocation = new ScriptLocationDto{ ID = scriptLocationIds.bobsCarStreetId},
        TimeOfDay = new TimeOfDayDto{ ID = timeofDayIds.dayId},
        Summary = "Alice and Bob talk about where they're going",
        PageLength = 9,
        ProjectID = projectId
      });
      AddScene5Text(scene5Id, characterIds.aliceId, characterIds.bobId);

      // 5A EXT. HIGHWAY DAY - The car drives by on the highway (1/8)
      var scene5AId = _sceneService.Add(new SceneDto
      {
        Number = "5A",
        SceneIntro = new SceneIntroDto{ ID = sceneIntroIds.extId},
        ScriptLocation = new ScriptLocationDto{ ID = scriptLocationIds.highwayId},
        TimeOfDay = new TimeOfDayDto{ ID = timeofDayIds.dayId},
        Summary = "The car drives by on the highway",
        PageLength = 1,
        ProjectID = projectId
      });
      AddScene5AText(scene5AId);

      // 6 EXT. FOREST NIGHT - Alice and Bob arrive to meet Charlie (6/8)
      var scene6Id = _sceneService.Add(new SceneDto
      {
        Number = "6",
        SceneIntro = new SceneIntroDto{ ID = sceneIntroIds.extId},
        ScriptLocation = new ScriptLocationDto{ ID = scriptLocationIds.forestId},
        TimeOfDay = new TimeOfDayDto{ ID = timeofDayIds.nightId},
        Summary = "Alice and Bob arrive to meet Charlie",
        PageLength = 6,
        ProjectID = projectId
      });
      AddScene6Text(scene6Id, characterIds.aliceId, characterIds.bobId, characterIds.charlieId);

      _sceneService.Sort(new SortOrderDto
      {
        ParentID = projectId,
        SortIDs = new long[]{scene1Id, scene2Id, scene3Id, scene4Id, scene5Id, scene5AId, scene6Id}
      });
      return (scene1Id, scene2Id, scene3Id, scene4Id, scene5Id, scene5AId, scene6Id);
    }

#region scripttext
    private void AddScene1Text(long scene1Id)
    {
      var sceneActions = new List<SceneActionDto>();
      var sceneDialogues = new List<SceneDialogueDto>();
      var order = 1;
      sceneActions.Add(new SceneActionDto
      {
        Text = "A house in a quiet neighbourhood.",
        Order = order
      });
      _scriptTextService.AddScriptTexts(scene1Id, sceneActions, sceneDialogues);
    }

    private void AddScene2Text(long scene2Id)
    {
      var sceneActions = new List<SceneActionDto>();
      var sceneDialogues = new List<SceneDialogueDto>();
      var order = 1;
      sceneActions.Add(new SceneActionDto
      {
        Text = "ALICE gathers all her things to go out. She puts her coat on, picks up her keys and puts them in her bag. We hear her phone ringing in the kitchen.",
        Order = order
      });
      order++;
      _scriptTextService.AddScriptTexts(scene2Id, sceneActions, sceneDialogues);
    }

    private void AddScene3Text(long scene3Id, long aliceId)
    {
      var sceneActions = new List<SceneActionDto>();
      var sceneDialogues = new List<SceneDialogueDto>();
      var order = 1;
      sceneActions.Add(new SceneActionDto
      {
        Text = "Alice enters the kitchen. Dirty dishes are still in the sink. She looks at the phone, sighs, and picks up the call",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto{ ID = aliceId },
        Text = "I'm almost there, be out in a minute",
        Order = order
      });
      order++;
      _scriptTextService.AddScriptTexts(scene3Id, sceneActions, sceneDialogues);
    }

    private void AddScene4Text(long scene4Id, long aliceId, long bobId)
    {
      var sceneActions = new List<SceneActionDto>();
      var sceneDialogues = new List<SceneDialogueDto>();
      var order = 1;
      sceneActions.Add(new SceneActionDto
      {
        Text = "Alice exits her front door. BOB is standing at his car. He puts away his phone.",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto{ ID = bobId},
        Text = "What took you so long?",
        Order = order
      });
      order++;
      sceneActions.Add(new SceneActionDto
      {
        Text = "Alice walks towards the car.",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto{ ID = aliceId },
        Text = "I'm here, aren't I. Let's go.",
        Order = order
      });
      order++;
      sceneActions.Add(new SceneActionDto
      {
        Text = "They get in the car.",
        Order = order
      });
      _scriptTextService.AddScriptTexts(scene4Id, sceneActions, sceneDialogues);
    }

    private void AddScene5Text(long scene5Id, long aliceId, long bobId)
    {
      var sceneActions = new List<SceneActionDto>();
      var sceneDialogues = new List<SceneDialogueDto>();
      var order = 1;
      sceneActions.Add(new SceneActionDto
      {
        Text = "Bob is driving the car.",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto{ ID = bobId},
        Text = "Charlie contacted me. Must be something important.",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto{ ID = aliceId},
        Text = "Charlie contacted you?",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto{ ID = bobId},
        Text = "As I said, must be something important.",
        Order = order
      });
      order++;
      sceneActions.Add(new SceneActionDto
      {
        Text = "Silence. Alice looks out the car window.",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto{ ID = aliceId},
        Text = "We haven't seen Charlie since...",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto{ ID = bobId},
        Text = "I know. And I'm not looking forward to opening up those old wounds.",
        Order = order
      });
      order++;
      sceneActions.Add(new SceneActionDto
      {
        Text = "They sit in silence again. Alice starts fiddling with her phone.",
        Order = order
      });
      order++;

      _scriptTextService.AddScriptTexts(scene5Id, sceneActions, sceneDialogues);
    }

    private void AddScene5AText(long scene5AId)
    {
      var sceneActions = new List<SceneActionDto>();
      var sceneDialogues = new List<SceneDialogueDto>();
      var order = 1;
      sceneActions.Add(new SceneActionDto
      {
        Text = "The car drives by on the highway.",
        Order = order
      });    
      order++;

      _scriptTextService.AddScriptTexts(scene5AId, sceneActions, sceneDialogues);  
    }

    private void AddScene6Text(long scene6Id, long aliceId, long bobId, long charlieId)
    {
      var sceneActions = new List<SceneActionDto>();
      var sceneDialogues = new List<SceneDialogueDto>();
      var order = 1;
      sceneActions.Add(new SceneActionDto
      {
        Text = "The car arrives at a clearing in a forest. CHARLIE is waiting for them, standing at his car. Charlie's not happy to see the two of them. Alice and Bob get out of the car.",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto { ID = aliceId },
        Text = "Now what was important to drag us all the way into the middle of nowhere?",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto { ID = charlieId },
        Text = "You think this is the middle of nowhere? How long has it been since you've been out of the city? I thought you used to love the outdoors.",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto { ID = aliceId },
        Text = "I guess people change as they get older.",
        Order = order
      });
      order++;
      sceneActions.Add(new SceneActionDto
      {
        Text = "Bob is starting to get annoyed.",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto { ID = bobId },
        Text = "Time to cut the banter, guys. I don't want to stay here longer than necessary.",
        Order = order
      });
      order++;
      sceneDialogues.Add(new SceneDialogueDto
      {
        Character = new CharacterDto { ID = charlieId },
        Text = "In that case, follow me.",
        Order = order
      });
      order++;

      _scriptTextService.AddScriptTexts(scene6Id, sceneActions, sceneDialogues);        
    }
#endregion
    private (
      long scene2_AliceId,
      long scene3_AliceId,
      long scene4_AliceId,
      long scene4_BobId,
      long scene5_AliceId,
      long scene5_BobId,
      long scene5A_AliceId,
      long scene5A_BobId,
      long scene6_AliceId,
      long scene6_BobId,
      long scene6_CharlieId
      ) LinkScenesToCharacters(
      (long scene1Id,
      long scene2Id,
      long scene3Id,
      long scene4Id,
      long scene5Id,
      long scene5AId,
      long scene6Id) sceneIds,
      (long aliceId, long bobId, long charlieId) characterIds
    )
    {
      var scene2_AliceId = _characterSceneService.AddLink(characterIds.aliceId, sceneIds.scene2Id);
      var scene3_AliceId = _characterSceneService.AddLink(characterIds.aliceId, sceneIds.scene3Id);
      var scene4_AliceId = _characterSceneService.AddLink(characterIds.aliceId, sceneIds.scene4Id);
      var scene4_BobId = _characterSceneService.AddLink(characterIds.bobId, sceneIds.scene4Id);
      var scene5_AliceId = _characterSceneService.AddLink(characterIds.aliceId, sceneIds.scene5Id);
      var scene5_BobId = _characterSceneService.AddLink(characterIds.bobId, sceneIds.scene5Id);
      var scene5A_AliceId = _characterSceneService.AddLink(characterIds.aliceId, sceneIds.scene5AId);
      var scene5A_BobId = _characterSceneService.AddLink(characterIds.bobId, sceneIds.scene5AId);
      var scene6_AliceId = _characterSceneService.AddLink(characterIds.aliceId, sceneIds.scene6Id);
      var scene6_BobId = _characterSceneService.AddLink(characterIds.bobId, sceneIds.scene6Id);
      var scene6_CharlieId = _characterSceneService.AddLink(characterIds.charlieId, sceneIds.scene6Id);
      return (scene2_AliceId, scene3_AliceId, scene4_AliceId, scene4_BobId, scene5_AliceId, scene5_BobId,
        scene5A_AliceId, scene5A_BobId, scene6_AliceId, scene6_BobId, scene6_CharlieId);
    }
#endregion
    
#region users
    private (long mainUnitId, long secondUnitId) CreateUnits(long projectId)
    {
      var allUnits = _crewUnitService.GetAllForParent(projectId);
      var mainUnitId = allUnits.FirstOrDefault().ID;

      var secondUnitId = _crewUnitService.Add(new CrewUnitDto
      {
        Name = "2nd Unit",
        ProjectID = projectId
      });

      return (mainUnitId, secondUnitId);
    }

    private async Task<(
      string jamesSmithId, long jamesSmithProjectId,
      string johnJonesId, long johnJonesProjectId,
      string robertBrownId, long robertBrownProjectId,
      string michaelMillerId, long michaelMillerProjectId,
      string wiliamMooreId, long wiliamMooreProjectId,
      string emmaJohnsonId, long emmaJohnsonProjectId,
      string oliviaWilliamsId, long oliviaWilliamsProjectId,
      string miaDavisId, long miaDavisProjectId,
      string lindaWilsonId, long lindaWilsonProjectId,
      string susanTaylorId, long susanTaylorProjectId
      )> CreateUsers(long projectId)
    {
      var jamesSmithId = await _userService.Add(GetCreateUser("James", "Smith", projectId));
      var jamesSmithProjectId = _projectUserService.Add(GetProjectUserDto(jamesSmithId, projectId));

      var johnJonesId = await _userService.Add(GetCreateUser("John", "Jones", projectId));
      var johnJonesProjectId = _projectUserService.Add(GetProjectUserDto(johnJonesId, projectId));

      var robertBrownId = await _userService.Add(GetCreateUser("Robert", "Brown", projectId));
      var robertBrownProjectId = _projectUserService.Add(GetProjectUserDto(robertBrownId, projectId));

      var michaelMillerId = await _userService.Add(GetCreateUser("Michael", "Miller", projectId));
      var michaelMillerProjectId = _projectUserService.Add(GetProjectUserDto(michaelMillerId, projectId));

      var wiliamMooreId = await _userService.Add(GetCreateUser("William", "Moore", projectId));
      var wiliamMooreProjectId = _projectUserService.Add(GetProjectUserDto(wiliamMooreId, projectId));

      var emmaJohnsonId = await _userService.Add(GetCreateUser("Emma", "Johnson", projectId));
      var emmaJohnsonProjectId = _projectUserService.Add(GetProjectUserDto(emmaJohnsonId, projectId));

      var oliviaWilliamsId = await _userService.Add(GetCreateUser("Olivia", "Williams", projectId));
      var oliviaWilliamsProjectId = _projectUserService.Add(GetProjectUserDto(oliviaWilliamsId, projectId));

      var miaDavisId = await _userService.Add(GetCreateUser("Mia", "Davis", projectId));
      var miaDavisProjectId = _projectUserService.Add(GetProjectUserDto(miaDavisId, projectId));

      var lindaWilsonId = await _userService.Add(GetCreateUser("Linda", "Wilson", projectId));
      var lindaWilsonProjectId = _projectUserService.Add(GetProjectUserDto(lindaWilsonId, projectId));

      var susanTaylorId = await _userService.Add(GetCreateUser("Susan", "Taylor", projectId));
      var susanTaylorProjectId = _projectUserService.Add(GetProjectUserDto(susanTaylorId, projectId));

      return (jamesSmithId, jamesSmithProjectId, 
        johnJonesId, johnJonesProjectId, 
        robertBrownId, robertBrownProjectId,
        michaelMillerId, michaelMillerProjectId,
        wiliamMooreId, wiliamMooreProjectId,
        emmaJohnsonId, emmaJohnsonProjectId,
        oliviaWilliamsId, oliviaWilliamsProjectId,
        miaDavisId, miaDavisProjectId,
        lindaWilsonId, lindaWilsonProjectId,
        susanTaylorId, susanTaylorProjectId);
    }

    private CreateUserDto GetCreateUser(string firstName, string lastName, long projectId)
    {
      var guid = Guid.NewGuid();
      var password = $"Password123!{guid.ToString()}";
      return new CreateUserDto
      {
        FirstName = firstName,
        LastName = lastName,
        Email = $"project-{projectId}{GetEmail(firstName, lastName)}",
        Password = password,
        IsDummyUser = true
      };
    }

    private ProjectUserDto GetProjectUserDto(string userId, long projectId)
    {
      return new ProjectUserDto
      {
        ProjectID = projectId,
        UserID = userId,
      };
    }

    private void CreateCast(
      long projectId,
      (long aliceId, long bobId, long charlieId)characterIds)
    {
      AddAndLinkCastMember("Eva", "Johnson", projectId, characterIds.aliceId);
      AddAndLinkCastMember("Paul", "Thompson", projectId, characterIds.bobId);
      AddAndLinkCastMember("Johnny", "Peters", projectId, characterIds.charlieId);
    }

    private void AddAndLinkCastMember(string firstName, string lastName, long projectId, long characterId)
    {
      var castMemberId = _castMemberService.Add(GetCastMemberDto(firstName, lastName, projectId));
      _castMemberService.AddLink(castMemberId, characterId);
    }

    private CastMemberDto GetCastMemberDto(string firstName, string lastName, long projectId)
    {
      return new CastMemberDto
      {
        FirstName = firstName,
        LastName = lastName,
        Email = GetEmail(firstName, lastName),
        Telephone = GetRandomPhone(),
        ProjectID = projectId
      };
    }

    private void CreateCrew(long projectId, (long mainUnitId, long secondUnitId)crewUnitIds)
    {
      CreateCrewForUnit(projectId, crewUnitIds.mainUnitId);
      CreateCrewForUnit(projectId, crewUnitIds.secondUnitId);
    }

    private void CreateCrewForUnit(long projectId, long crewUnitId)
    {
      var crewDepartments = _crewDepartmentService.GetSummariesForUnit(crewUnitId);

      var directorDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Director")?.ID;
      if(directorDepartmentId.HasValue)
      {
        CreateMembersForDirectorDepartment(directorDepartmentId.Value);
      }
      
      var producersDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Producers")?.ID;
      if(producersDepartmentId.HasValue)
      {
        CreateMembersForProducersDepartment(producersDepartmentId.Value);
      }
      
      var productionDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Production")?.ID;
      if(productionDepartmentId.HasValue)
      {
        CreateMembersForProductionDepartment(productionDepartmentId.Value);
      }
      
      var artDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Art Department")?.ID;
      if(artDepartmentId.HasValue)
      {
        CreateMembersForArtDepartment(artDepartmentId.Value);
      }
      
      var assistantDirectorsDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Assistant Directors")?.ID;
      if(assistantDirectorsDepartmentId.HasValue)
      {
        CreateMembersForAssistantDirectorDepartment(assistantDirectorsDepartmentId.Value);
      }
      
      var cameraDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Camera")?.ID;
      if(cameraDepartmentId.HasValue)
      {
        CreateMembersForCameraDepartment(cameraDepartmentId.Value);
      }
      
      var costumeDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Costume")?.ID;
      if(costumeDepartmentId.HasValue)
      {
        CreateMembersForCostumeDepartment(costumeDepartmentId.Value);
      }
      
      var electricalDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Electrical")?.ID;
      if(electricalDepartmentId.HasValue)
      {
        CreateMembersForElectricalDepartment(electricalDepartmentId.Value);
      }
      
      var locationsDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Locations")?.ID;
      if(locationsDepartmentId.HasValue)
      {
        CreateMembersForLocationsDepartment(locationsDepartmentId.Value);
      }
      
      var makeupDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Make Up & Hair")?.ID;
      if(makeupDepartmentId.HasValue)
      {
        CreateMembersForMakeUpDepartment(makeupDepartmentId.Value);
      }
      
      var propsDepartmentId = crewDepartments.FirstOrDefault(d => d.Name == "Props")?.ID;
      if(propsDepartmentId.HasValue)
      {
        CreateMembersForPropsDepartment(propsDepartmentId.Value);
      }
    }

    private void CreateMembersForDirectorDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "Director"
      });
    }
    private void CreateMembersForProducersDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "Producer",
        "Executive Producer",
        "Executive Producer"
      });
    }
    private void CreateMembersForProductionDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "Unit Production Manager",
        "Production Coordinator",
        "Assistant Production Coordinator",
        "Production Secretary",
        "Production Runner",
        "Production Runner"
      });
    }
    private void CreateMembersForArtDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "Production Designer",
        "Supervising Art Director",
        "Art Director",
        "Art Director",
        "Assistant Art Director",
        "Assistant Art Director",
        "Assistant Art Director",
        "Standby Art Director",
        "Art Department Coordinator",
        "Storyboard Artist",
        "Draughtsman",
        "Junior Draughtsman",
        "Graphic Artist",
        "Modelmaker",
        "Art Department Assistant"
      });
    }
    private void CreateMembersForAssistantDirectorDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "1st Assistant Director",
        "Key 2nd Assistant Director",
        "Co 2nd Assistant Director",
        "Crowd 2nd Assistant Director",
        "3rd Assistant Director",
        "Base Runner",
        "Floor Runner",
        "Floor Runner",
        "Floor Runner",
        "Floor Runner"
      });
    }
    private void CreateMembersForCameraDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "Director of Photography",
        "A Camera Operator",
        "A Camera 1st AC",
        "A Camera 2nd AC",
        "B Camera Operator",
        "B Camera 1st AC",
        "B Camera 2nd AC",
        "Central Loader",
        "Trainee"
      });
    }
    private void CreateMembersForCostumeDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "Costume Designer",
        "Costume Supervisor",
        "Costume Coordinator",
        "Wardrobe Mistress",
        "Principal Standby Costumer",
        "Costume Assistant"
      });
    }
    private void CreateMembersForElectricalDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "Gaffer",
        "Best Boy",
        "Floor Electrician",
        "Floor Electrician",
        "Floor Electrician",
        "Floor Electrician",
        "Rigging Gaffer",
        "Rigging Electrician",
        "Rigging Electrician",
        "Rigging Electrician",
        "Rigging Electrician",
      });
    }
    private void CreateMembersForLocationsDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "Location Manager",
        "Assistant Location Manager",
        "Studio Manager",
        "Unit Manager",
        "Site/ Unit Manager",
        "Locations Coordinator",
        "Location Assistant",
        "Location Assistant",
        "Location PA",
        "Location Trainee",
      });
    }
    private void CreateMembersForMakeUpDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "Make-up & Hair Designer",
        "Make up & Hair Artist",
        "Make up & Hair Artist",
        "Make up & Hair Artist",
      });
    }
    private void CreateMembersForPropsDepartment(long departmentId)
    {
      CreateCrewMembersForDepartment(departmentId, new string[]{
        "Property Master",
        "Assistant Propmaster",
        "Storeman",
        "Chargehand Prop",
        "Dresser",
        "Dresser",
        "Dresser",
        "Prop Coordinator",
      });
    }

    private void CreateCrewMembersForDepartment(long departmentId, IEnumerable<string> jobTitles)
    {
      foreach(var jobTitle in jobTitles)
      {
        CreateCrewMemberForDepartment(departmentId, jobTitle);
      }
    }

    private void CreateCrewMemberForDepartment(long departmentId, string jobTitle)
    {
      var fullName = GetRandomFullName();
      _crewMemberService.Add(new CrewMemberDto
      {
        FirstName = fullName.firstName,
        LastName = fullName.lastName,
        JobTitle = jobTitle,
        Email = GetEmail(fullName.firstName, fullName.lastName),
        Telephone = GetRandomPhone(),
        Department = new CrewDepartmentDto { ID = departmentId }
      });
    }
    private (string firstName, string lastName) GetRandomFullName()
    {
      var firstNames = new string[]{"James", "John", "Joseph", "Mark", "Matt", "Paul", "Peter", "Richard", "Liam", "Noah", "Logan",
        "Benjamin", "Oliver", "Jacob", "Robert", "David", "Jack", "Conrad", "Michael", "Emma", "Olivia", "Ava", "Isabella", "Sophia",
        "Judy", "Mia", "Charlotte", "Amy", "Kate", "Mary", "Linda", "Barbara", "Jennifer", "Susan", "Margaret", "Dorothy"};
      var lastNames = new string[]{"Peters", "Johnson", "Willis", "Williams", "Franklin", "Richards", "Smith", "Jones", "Brown",
        "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Jackson", "Thomas", "White", "Clark", "Walker", "Hill",
        "Forest", "Cooper", "Howard", "Griffin", "Simmons", "Newman", "Peterson", "Powell", "Coleman", "Alexander"};
      
      var firstName = GetRandomFromList(firstNames);
      var lastName = GetRandomFromList(lastNames);

      return (firstName, lastName);
    }

    private string GetRandomFromList(IEnumerable<string> optionList)
    {
      var i = _rnd.Next(optionList.Count());
      return optionList.ElementAt(i);
    }
#endregion

#region locations
    private (long titanicStudiosId, long stranmillisId, long westlinkBelfastId, long tollymoreForestId)
      CreateLocations(long projectId) 
    {
      var titanicStudiosId = _locationService.Add(new LocationDto
      {
        Name = "Titanic Studios",
        Address = new AddressDto
        {
          Address1 = "Queens Rd",
          Address2 = "Belfast",
          Address3 = "BT3 9DU",
          Address4 = "United Kingdom"
        },
        LatLng = new LatLngDto
        {
          Latitude = 54.610679,
          Longitude = -5.905004
        },
        ProjectID = projectId
      });
      var stranmillisId = _locationService.Add(new LocationDto
      {
        Name = "Stranmillis",
        Address = new AddressDto
        {
          Address1 = "20 Stranmillis St",
          Address2 = "Belfast",
          Address3 = "BT9 5FE",
          Address4 = "United Kingdom"
        },
        LatLng = new LatLngDto
        {
          Latitude = 54.578494,
          Longitude = -5.932810
        },
        ProjectID = projectId
      });
      var westlinkBelfastId = _locationService.Add(new LocationDto
      {
        Name = "West Link",
        Address = new AddressDto
        {
          Address1 = "West Link",
          Address2 = "Belfast",
          Address3 = "United Kingdom",
          Address4 = ""
        },
        LatLng = new LatLngDto
        {
          Latitude = 54.599273,
          Longitude = -5.939718
        },
        ProjectID = projectId
      });
      var tollymoreForestId = _locationService.Add(new LocationDto
      {
        Name = "Tollymore Forest Park",
        Address = new AddressDto
        {
          Address1 = "Bryansford Rd",
          Address2 = "Newcastle",
          Address3 = "BT33 0PR",
          Address4 = "United Kingdom"
        },
        LatLng = new LatLngDto
        {
          Latitude = 54.225827,
          Longitude = -5.939446
        },
        ProjectID = projectId
      });
      return (titanicStudiosId, stranmillisId, westlinkBelfastId, tollymoreForestId);
    }

    private (long houseLivingRoomId, long houseKitchenId, long houseId, long streetId, long highwayId, long forestId)
      CreateLocationSets((long titanicStudiosId, long stranmillisId, long westlinkBelfastId, long tollymoreForestId) locationIds,
      (long houseId,
      long houseLivingRoomId,
      long houseKitchenId,
      long bobsCarStreetId,
      long highwayId,
      long forestId) scriptLocationIds)
    {
      var houseLivingRoomId = _locationSetService.Add(new LocationSetDto
      {
        Name = "Stage 1 - Living Room Alice",
        LocationID = locationIds.titanicStudiosId,
        ScriptLocationID = scriptLocationIds.houseLivingRoomId
      });
      var houseKitchenId = _locationSetService.Add(new LocationSetDto
      {
        Name = "Stage 2 - Kitchen Alice",
        LocationID = locationIds.titanicStudiosId,
        ScriptLocationID = scriptLocationIds.houseKitchenId
      });
      var houseId = _locationSetService.Add(new LocationSetDto
      {
        Name = "HOUSE",
        LocationID = locationIds.stranmillisId,
        ScriptLocationID = scriptLocationIds.houseId
      });
      var streetId = _locationSetService.Add(new LocationSetDto
      {
        Name = "STREET",
        LocationID = locationIds.stranmillisId,
        ScriptLocationID = scriptLocationIds.bobsCarStreetId
      });
      var highwayId = _locationSetService.Add(new LocationSetDto
      {
        Name = "HIGHWAY",
        LocationID = locationIds.westlinkBelfastId,
        ScriptLocationID = scriptLocationIds.highwayId
      });
      var forestId = _locationSetService.Add(new LocationSetDto
      {
        Name = "FOREST",
        LocationID = locationIds.tollymoreForestId,
        ScriptLocationID = scriptLocationIds.forestId,
        LatLng = new LatLngDto
        {
          Latitude = 54.218097,
          Longitude = -5.943116
        }
      });
      return (houseLivingRoomId, houseKitchenId, houseId, streetId, highwayId, forestId);
    }
#endregion

#region scheduling
    private (
      long scheduleDay1_mainUnitId,
      long scheduleDay2_mainUnitId,
      long scheduleDay3_mainUnitId,
      long scheduleDay4_mainUnitId,
      long scheduleDay1_2ndUnitId)
      CreateScheduleDays(long projectId, (long mainUnitId, long secondUnitId)crewUnitIds)
      {
        var todayDate = DateTime.UtcNow.Date;

        var yesterdayDate = todayDate.AddDays(-1);
        var scheduleDay1_mainUnitId = _scheduleDayService.Add(new ScheduleDayDto
        {
          Date = yesterdayDate,
          Start = yesterdayDate.AddHours(8),
          End = yesterdayDate.AddHours(17),
          CrewUnitID = crewUnitIds.mainUnitId
        });
        var scheduleDay2_mainUnitId = _scheduleDayService.Add(new ScheduleDayDto
        {
          Date = todayDate,
          Start = todayDate.AddHours(8),
          End = todayDate.AddHours(17),
          CrewUnitID = crewUnitIds.mainUnitId
        });
        var tomorrowDate = todayDate.AddDays(1);
        var scheduleDay3_mainUnitId = _scheduleDayService.Add(new ScheduleDayDto
        {
          Date = tomorrowDate,
          Start = tomorrowDate.AddHours(8),
          End = tomorrowDate.AddHours(17),
          CrewUnitID = crewUnitIds.mainUnitId
        });
        var dayAfterTomorrowDate = todayDate.AddDays(2);
        var scheduleDay4_mainUnitId = _scheduleDayService.Add(new ScheduleDayDto
        {
          Date = dayAfterTomorrowDate,
          Start = dayAfterTomorrowDate.AddHours(17),
          End = dayAfterTomorrowDate.AddHours(26),
          CrewUnitID = crewUnitIds.mainUnitId
        });
        var scheduleDay1_secondUnitId = _scheduleDayService.Add(new ScheduleDayDto
        {
          Date = tomorrowDate,
          Start = tomorrowDate.AddHours(8),
          End = tomorrowDate.AddHours(17),
          CrewUnitID = crewUnitIds.secondUnitId
        });
        return (scheduleDay1_mainUnitId, scheduleDay2_mainUnitId, scheduleDay3_mainUnitId, scheduleDay4_mainUnitId, scheduleDay1_secondUnitId);
      }

    private (
      long main_day1_scene4Id,
      long main_day1_scene5Id,
      long main_day2_scene5Id,
      long main_day3_scene2Id,
      long main_day3_scene3Id,
      long main_day4_scene6Id,
      long second_day1_scene1Id,
      long second_day1_scene5Id,
      long second_day1_scene5AId
    )
    CreateScheduleScenes(
      (long scheduleDay1_mainUnitId,
      long scheduleDay2_mainUnitId,
      long scheduleDay3_mainUnitId,
      long scheduleDay4_mainUnitId,
      long scheduleDay1_2ndUnitId) scheduleDayIds,
      (long scene1Id,
      long scene2Id,
      long scene3Id,
      long scene4Id,
      long scene5Id,
      long scene5AId,
      long scene6Id)sceneIds,
      (long houseLivingRoomId, long houseKitchenId, long houseId, long streetId, long highwayId, long forestId) locationSetIds,
      (long scene2_AliceId,
      long scene3_AliceId,
      long scene4_AliceId,
      long scene4_BobId,
      long scene5_AliceId,
      long scene5_BobId,
      long scene5A_AliceId,
      long scene5A_BobId,
      long scene6_AliceId,
      long scene6_BobId,
      long scene6_CharlieId
      )characterSceneIds
      )
    {
      var main_day1_scene4Id = _scheduleSceneService.Add(new ScheduleSceneDto
      {
        SceneID = sceneIds.scene4Id,
        ScheduleDayID = scheduleDayIds.scheduleDay1_mainUnitId,
        LocationSetID = locationSetIds.houseId,
        PageLength = 5
      });

      var main_day1_scene5Id = _scheduleSceneService.Add(new ScheduleSceneDto
      {
        SceneID = sceneIds.scene5Id,
        ScheduleDayID = scheduleDayIds.scheduleDay1_mainUnitId,
        LocationSetID = locationSetIds.streetId,
        PageLength = 2
      });

      var main_day2_scene5Id = _scheduleSceneService.Add(new ScheduleSceneDto
      {
        SceneID = sceneIds.scene5Id,
        ScheduleDayID = scheduleDayIds.scheduleDay2_mainUnitId,
        LocationSetID = locationSetIds.streetId,
        PageLength = 7
      });

      var main_day3_scene2Id = _scheduleSceneService.Add(new ScheduleSceneDto
      {
        SceneID = sceneIds.scene2Id,
        ScheduleDayID = scheduleDayIds.scheduleDay3_mainUnitId,
        LocationSetID = locationSetIds.houseLivingRoomId,
        PageLength = 3
      });

      var main_day3_scene3Id = _scheduleSceneService.Add(new ScheduleSceneDto
      {
        SceneID = sceneIds.scene3Id,
        ScheduleDayID = scheduleDayIds.scheduleDay3_mainUnitId,
        LocationSetID = locationSetIds.houseKitchenId,
        PageLength = 4
      });

      var main_day4_scene6Id = _scheduleSceneService.Add(new ScheduleSceneDto
      {
        SceneID = sceneIds.scene6Id,
        ScheduleDayID = scheduleDayIds.scheduleDay4_mainUnitId,
        LocationSetID = locationSetIds.forestId,
        PageLength = 6
      });

      var second_day1_scene1Id = _scheduleSceneService.Add(new ScheduleSceneDto
      {
        SceneID = sceneIds.scene1Id,
        ScheduleDayID = scheduleDayIds.scheduleDay1_2ndUnitId,
        LocationSetID = locationSetIds.houseId,
        PageLength = 1
      });
      var second_day1_scene5Id = _scheduleSceneService.Add(new ScheduleSceneDto
      {
        SceneID = sceneIds.scene5Id,
        ScheduleDayID = scheduleDayIds.scheduleDay1_2ndUnitId,
        LocationSetID = locationSetIds.streetId,
        PageLength = 1
      });
      var second_day1_scene5_linkedCharactersToRemove = _scheduleCharacterService.GetCharacters(second_day1_scene5Id).ToList();
      foreach(var character in second_day1_scene5_linkedCharactersToRemove)
      {
        _scheduleCharacterService.RemoveLink(character.LinkID);
      }
      var second_day1_scene5AId = _scheduleSceneService.Add(new ScheduleSceneDto
      {
        SceneID = sceneIds.scene5AId,
        ScheduleDayID = scheduleDayIds.scheduleDay1_2ndUnitId,
        LocationSetID = locationSetIds.highwayId,
        PageLength = 1
      });
      var second_day1_scene5A_linkedCharactersToRemove = _scheduleCharacterService.GetCharacters(second_day1_scene5AId).ToList();
      foreach(var character in second_day1_scene5A_linkedCharactersToRemove)
      {
        _scheduleCharacterService.RemoveLink(character.LinkID);
      }
      return (main_day1_scene4Id, main_day1_scene5Id, main_day2_scene5Id, main_day3_scene2Id, main_day3_scene3Id, main_day4_scene6Id, second_day1_scene1Id, second_day1_scene5Id, second_day1_scene5AId);
    }
#endregion

#region callsheets
    private (long mainCallsheet1Id, long mainCallsheet2Id, long mainCallsheet3Id, long secondCallsheet1Id) CreateCallsheets(
      long projectId,
      (long mainUnitId, long secondUnitId) crewUnitIds,
      (long scheduleDay1_mainUnitId,
      long scheduleDay2_mainUnitId,
      long scheduleDay3_mainUnitId,
      long scheduleDay4_mainUnitId,
      long scheduleDay1_2ndUnitId) scheduleDayIds
    )
    {
      var mainCallsheet1Id = CreateCallsheetForScheduleDay(projectId, scheduleDayIds.scheduleDay1_mainUnitId);
      var mainCallsheet2Id = CreateCallsheetForScheduleDay(projectId, scheduleDayIds.scheduleDay2_mainUnitId);
      var mainCallsheet3Id = CreateCallsheetForScheduleDay(projectId, scheduleDayIds.scheduleDay3_mainUnitId);
      var secondCallsheet1Id = CreateCallsheetForScheduleDay(projectId, scheduleDayIds.scheduleDay1_2ndUnitId);
      return (mainCallsheet1Id, mainCallsheet2Id, mainCallsheet3Id, secondCallsheet1Id);
    }

    private long CreateCallsheetForScheduleDay(long projectId, long scheduleDayId)
    {
      var scheduleDay = _scheduleDayService.Get(scheduleDayId);
      var callsheetId = _callsheetService.Add(new CallsheetDto
      {
        ShootingDay = new ShootingDayDto
        {
          ID = scheduleDay.ID
        },
        CrewCall = scheduleDay.Start.Value.AddHours(-1),
        Start = scheduleDay.Start.Value,
        End = scheduleDay.End.Value,
        CrewUnitID = scheduleDay.CrewUnitID
      });

      _callsheetCharacterService.SetCharacters(callsheetId, projectId);

      var callsheetCharacters = _callsheetCharacterService.GetCharacters(callsheetId);

      foreach(var callsheetCharacter in callsheetCharacters)
      {
        foreach(var call in callsheetCharacter.Calls)
        {
          call.CallTime = scheduleDay.Start.Value.AddHours(-1);
          _characterCallService.Update(call);
        }
      }
      return callsheetId;
    }
#endregion

#region breakdown
    private long CreateBreakdown(long projectId, string userId)
    {
      var breakdownId = _breakdownService.Add(new BreakdownDto
      {
        Name = "Main Breakdown",
        ProjectID = projectId,
        UserID = userId
      });
      _breakdownService.TogglePublishBreakdown(new PublishBreakdownDto
      {
        BreakdownID = breakdownId,
        Publish = true
      });
      _breakdownService.SetDefaultProjectBreakdown(projectId, breakdownId);
      return breakdownId;
    }

    private (
      long bobsCarId,
      long charliesCarId,
      long alicesPhoneId,
      long bobsPhoneId,
      long alicesBagId,
      long alicesCoatId
    ) CreateBreakdownItems(long breakdownId)
    {
      (
        long bobsCarId,
        long charliesCarId,
        long alicesPhoneId,
        long bobsPhoneId,
        long alicesBagId,
        long alicesCoatId
      ) results = (0, 0, 0, 0, 0, 0);
      var breakdownTypes = _breakdownTypeService.GetAllForParent(breakdownId);

      var vehiclesTypeId = breakdownTypes.FirstOrDefault(t=> t.Name == "Vehicles")?.ID;
      if(vehiclesTypeId.HasValue)
      {
        var vehicleItemIds = CreateVehicleBreakdownItems(breakdownId, vehiclesTypeId.Value);
        results.bobsCarId = vehicleItemIds.bobsCarId;
        results.charliesCarId = vehicleItemIds.charliesCarId;
      }
      var costumeTypeId = breakdownTypes.FirstOrDefault(t=> t.Name == "Costume")?.ID;
      if(costumeTypeId.HasValue)
      {
        var aliceCoatId = CreateCostumeBreakdownItems(breakdownId, costumeTypeId.Value);
        results.alicesCoatId = aliceCoatId;
      }
      var propsTypeId = breakdownTypes.FirstOrDefault(t=> t.Name == "Props")?.ID;
      if(propsTypeId.HasValue)
      {
        var propsItemIds = CreatePropsBreakdownItems(breakdownId, propsTypeId.Value);
        results.alicesPhoneId = propsItemIds.alicePhoneId;
        results.bobsPhoneId = propsItemIds.bobsPhoneId;
        results.alicesBagId = propsItemIds.aliceBagId;
      }
      return results;
    }

    private (long bobsCarId, long charliesCarId) CreateVehicleBreakdownItems(long breakdownId, long breakdownTypeId)
    {
      var bobsCarId = _breakdownItemService.Add(GetBreakdownItemDto(breakdownId, breakdownTypeId, "Bob's car"));
      var charliesCarId = _breakdownItemService.Add(GetBreakdownItemDto(breakdownId, breakdownTypeId, "Charlie's car"));
      return (bobsCarId, charliesCarId);
    }
    private long CreateCostumeBreakdownItems(long breakdownId, long breakdownTypeId)
    {
      var aliceCoatId = _breakdownItemService.Add(GetBreakdownItemDto(breakdownId, breakdownTypeId, "Alice's coat"));
      return aliceCoatId;
    }
    private (long alicePhoneId, long bobsPhoneId, long aliceBagId) CreatePropsBreakdownItems(long breakdownId, long breakdownTypeId)
    {
      var alicePhoneId = _breakdownItemService.Add(GetBreakdownItemDto(breakdownId, breakdownTypeId, "Alice's phone"));
      var bobsPhoneId = _breakdownItemService.Add(GetBreakdownItemDto(breakdownId, breakdownTypeId, "Bob's phone"));
      var aliceBagId = _breakdownItemService.Add(GetBreakdownItemDto(breakdownId, breakdownTypeId, "Alice's bag"));
      return (alicePhoneId, bobsPhoneId, aliceBagId);
    }

    private BreakdownItemDto GetBreakdownItemDto(long breakdownId, long breakdownTypeId, string name)
    {
      return new BreakdownItemDto
      {
        Name = name,
        BreakdownID = breakdownId,
        BreakdownTypeID = breakdownTypeId
      };
    }

    public void LinkBreakdownItemScenes(
      (
        long bobsCarId,
        long charliesCarId,
        long alicesPhoneId,
        long bobsPhoneId,
        long alicesBagId,
        long alicesCoatId
      ) breakdownItemIds,
      (
        long scene1Id,
        long scene2Id,
        long scene3Id,
        long scene4Id,
        long scene5Id,
        long scene5AId,
        long scene6Id
      )sceneIds
    )
    {
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesBagId, sceneIds.scene2Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesCoatId, sceneIds.scene2Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesBagId, sceneIds.scene3Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesCoatId, sceneIds.scene3Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesPhoneId, sceneIds.scene3Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesBagId, sceneIds.scene4Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesCoatId, sceneIds.scene4Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesPhoneId, sceneIds.scene4Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.bobsCarId, sceneIds.scene4Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.bobsPhoneId, sceneIds.scene4Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesBagId, sceneIds.scene5Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesCoatId, sceneIds.scene5Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesPhoneId, sceneIds.scene5Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.bobsCarId, sceneIds.scene5Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.bobsPhoneId, sceneIds.scene5Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesBagId, sceneIds.scene5AId);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesCoatId, sceneIds.scene5AId);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesPhoneId, sceneIds.scene5AId);
      _breakdownItemSceneService.AddLink(breakdownItemIds.bobsCarId, sceneIds.scene5AId);
      _breakdownItemSceneService.AddLink(breakdownItemIds.bobsPhoneId, sceneIds.scene5AId);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesBagId, sceneIds.scene6Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesCoatId, sceneIds.scene6Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.alicesPhoneId, sceneIds.scene6Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.bobsCarId, sceneIds.scene6Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.bobsPhoneId, sceneIds.scene6Id);
      _breakdownItemSceneService.AddLink(breakdownItemIds.charliesCarId, sceneIds.scene6Id);
    }
#endregion

#region comments
    private void CreateComments(
    (
      string jamesSmithId, long jamesSmithProjectId,
      string johnJonesId, long johnJonesProjectId,
      string robertBrownId, long robertBrownProjectId,
      string michaelMillerId, long michaelMillerProjectId,
      string wiliamMooreId, long wiliamMooreProjectId,
      string emmaJohnsonId, long emmaJohnsonProjectId,
      string oliviaWilliamsId, long oliviaWilliamsProjectId,
      string miaDavisId, long miaDavisProjectId,
      string lindaWilsonId, long lindaWilsonProjectId,
      string susanTaylorId, long susanTaylorProjectId
    ) userIds,
    (long aliceId, long bobId, long charlieId) characterIds,
    (long mainCallsheet1Id, long mainCallsheet2Id, long mainCallsheet3Id, long secondCallsheet1Id) callsheetIds,
    (
      long houseId,
      long houseLivingRoomId,
      long houseKitchenId,
      long bobsCarStreetId,
      long highwayId,
      long forestId
    ) scriptLocationIds,
    (long titanicStudiosId, long stranmillisId, long westlinkBelfastId, long tollymoreForestId) locationIds,
    (
      long bobsCarId,
      long charliesCarId,
      long alicesPhoneId,
      long bobsPhoneId,
      long alicesBagId,
      long alicesCoatId
    )breakdownItemIds,
    ( long scene1Id,
      long scene2Id,
      long scene3Id,
      long scene4Id,
      long scene5Id,
      long scene5AId,
      long scene6Id)sceneIds
    )
    {
      // comments for HOUSE - KITCHEN scriptlocation
      var houseKitchenQuestionCommentId = _commentService.Add(GetPostCommentDto(scriptLocationIds.houseKitchenId, ParentCommentType.ScriptLocation, 
        "Are the living room and kitchen connected? Should we be able to see from one into the other?", userIds.wiliamMooreId));
      var houseKitchenAnswerCommentId = _commentService.Add(GetPostCommentDto(houseKitchenQuestionCommentId, ParentCommentType.Comment, 
        "Living room and kitchen are not connected. They will be on separate stages.", userIds.lindaWilsonId));

      // comments for scene 5
      var scene5CommentId = _commentService.Add(GetPostCommentDto(sceneIds.scene5Id, ParentCommentType.Scene, 
        "Can we plan some exterior shots of the car driving for the second unit?", userIds.robertBrownId));

      // comments for bobs car
      var bobsCarCommentId = _commentService.Add(GetPostCommentDto(breakdownItemIds.bobsCarId, ParentCommentType.BreakdownItem, 
        "I'd like a really nice classic car for this", userIds.wiliamMooreId));
    }

    private PostCommentDto GetPostCommentDto(long parentId, ParentCommentType type, string text, string userId)
    {
      return new PostCommentDto
      {
        ParentID = parentId,
        ParentType = type,
        Text = text,
        UserID = userId
      };
    }

#endregion
    private string GetEmail(string firstName, string lastName)
    {
      return $"{firstName}.{lastName}@raccord.co.uk";
    }

    private string GetRandomPhone()
    {
      string r = "+44";
      for (int i = 0; i < 11; i++)
      {
          r += _rnd.Next(0, 9).ToString();
      }
      return r;
    }
  }
}
