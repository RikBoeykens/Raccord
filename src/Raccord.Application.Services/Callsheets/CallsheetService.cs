using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Common.Paging;
using Raccord.Application.Core.ExternalServices.Weather;
using Raccord.Application.Core.Services.Callsheets;
using Raccord.Data.EntityFramework.Repositories.Breakdowns;
using Raccord.Data.EntityFramework.Repositories.Callsheets;
using Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDays;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Callsheets;
using Raccord.Domain.Model.Callsheets.Scenes;
using Raccord.Domain.Model.ShootingDays.Scenes;

namespace Raccord.Application.Services.Callsheets
{
    // Service used for character functionality
    public class CallsheetService : ICallsheetService
    {
        private readonly ICallsheetRepository _callsheetRepository;
        private readonly IShootingDayRepository _shootingDayRepository;
        private readonly IScheduleDayRepository _scheduleDayRepository;
        private readonly ICallsheetSceneCharacterRepository _callsheetSceneCharacterRepository;
        private readonly IBreakdownRepository _breakdownRepository;
        private readonly IWeatherService _weatherService;

        // Initialises a new CharacterService
        public CallsheetService(
            ICallsheetRepository callsheetRepository,
            IShootingDayRepository shootingDayRepository,
            IScheduleDayRepository scheduleDayRepository,
            ICallsheetSceneCharacterRepository callsheetSceneCharacterRepository,
            IBreakdownRepository breakdownRepository,
            IWeatherService weatherService
            )
        {
            _callsheetRepository = callsheetRepository;
            _shootingDayRepository = shootingDayRepository;
            _scheduleDayRepository = scheduleDayRepository;
            _callsheetSceneCharacterRepository = callsheetSceneCharacterRepository;
            _breakdownRepository = breakdownRepository;
            _weatherService = weatherService;
        }

        // Gets all callsheets for a crew unit
        public IEnumerable<CallsheetSummaryDto> GetAllForParent(long crewUnit)
        {
            var callsheets = _callsheetRepository.GetAllForCrewUnit(crewUnit);

            var dtos = callsheets.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets all callsheets for a crew unit
        public PagedDataDto<CallsheetCrewUnitDto> GetForProject(long projectID, PaginationRequestDto requestDto)
        {
            var callsheets = _callsheetRepository.GetAllForProject(projectID);

            return callsheets.GetPaged<Callsheet, CallsheetCrewUnitDto>(requestDto, cs => cs.TranslateCrewUnit());
        }

        // Gets all callsheets for a crew unit
        public PagedDataDto<CallsheetSummaryDto> GetForCrewUnit(long crewUnitId, PaginationRequestDto requestDto)
        {
            var callsheets = _callsheetRepository.GetAllForCrewUnit(crewUnitId);

            return callsheets.GetPaged<Callsheet, CallsheetSummaryDto>(requestDto, cs => cs.TranslateSummary());
        }

        // Gets a single callsheet by id
        public FullCallsheetDto Get(long ID, string userID)
        {
            var callsheet = _callsheetRepository.GetFull(ID);

            var breakdown = _breakdownRepository.GetForProjectUser(callsheet.CrewUnit.ProjectID, userID);

            var latLng = callsheet.GetFirstLatLng();
            var weatherInfo = (latLng != null && latLng.HasLatLng) ?  _weatherService.GetWeatherInfo(new WeatherRequestDto
            {
                LatLng = latLng,
                Date = callsheet.ShootingDay.Date
            }) : null;
            var dto = callsheet.TranslateFull(breakdown, weatherInfo);

            return dto;
        }

        // Gets a summary of a single callsheet
        public CallsheetSummaryDto GetSummary(Int64 ID)
        {
            var callsheet = _callsheetRepository.GetSummary(ID);

            var dto = callsheet.TranslateSummary();

            return dto;
        }

        // Adds a callsheet
        public long Add(CallsheetDto dto)
        {
            var linkedShootingDay = _shootingDayRepository.GetSingle(dto.ShootingDay.ID);
            var linkedScheduleDay = _scheduleDayRepository.GetFull(linkedShootingDay.ScheduleDayID.Value);

            var callsheet = new Callsheet
            {
                CrewCall = dto.CrewCall,
                Start = dto.Start,
                End = dto.End,
                ShootingDayID = dto.ShootingDay.ID,
                CrewUnitID = dto.CrewUnitID,
            };

            foreach(var scheduleScene in linkedScheduleDay.ScheduleScenes)
            {
                callsheet.CallsheetScenes.Add(new CallsheetScene
                {
                    PageLength = scheduleScene.PageLength,
                    LocationSetID = scheduleScene.LocationSetID,
                    SceneID = scheduleScene.SceneID,
                    Characters = scheduleScene.Characters.Select(cs=> new CallsheetSceneCharacter
                    {
                        CharacterSceneID = cs.CharacterSceneID,
                    }).ToList(),
                    ShootingDayScene = new ShootingDayScene
                    {
                        ShootingDayID = linkedShootingDay.ID,
                        SceneID = scheduleScene.SceneID,
                    }
                });
            }

            _callsheetRepository.Add(callsheet);
            _callsheetRepository.Commit();

            linkedShootingDay.CallsheetID = callsheet.ID;
            _shootingDayRepository.Edit(linkedShootingDay);
            _shootingDayRepository.Commit();

            return callsheet.ID;
        }

        // Updates a character
        public long Update(CallsheetDto dto)
        {
            var callsheet = _callsheetRepository.GetSingle(dto.ID);

            callsheet.Start = dto.Start;
            callsheet.End = dto.End;
            callsheet.CrewCall = dto.CrewCall;

            _callsheetRepository.Edit(callsheet);
            _callsheetRepository.Commit();

            return  callsheet.ID;
        }

        // Deletes a character
        public void Delete(long ID)
        {
            var callsheet = _callsheetRepository.GetSingle(ID);

            _callsheetRepository.Delete(callsheet);

            _callsheetRepository.Commit();
        }
    }
}