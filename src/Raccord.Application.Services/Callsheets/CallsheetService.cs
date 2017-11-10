using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Callsheets;
using Raccord.Data.EntityFramework.Repositories.Callsheets;
using Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleDays;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
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

        // Initialises a new CharacterService
        public CallsheetService(
            ICallsheetRepository callsheetRepository,
            IShootingDayRepository shootingDayRepository,
            IScheduleDayRepository scheduleDayRepository,
            ICallsheetSceneCharacterRepository callsheetSceneCharacterRepository
            )
        {
            if(callsheetRepository == null)
                throw new ArgumentNullException(nameof(callsheetRepository));
            if(shootingDayRepository == null)
                throw new ArgumentNullException(nameof(shootingDayRepository));
            if(scheduleDayRepository == null)
                throw new ArgumentNullException(nameof(scheduleDayRepository));
            if(callsheetSceneCharacterRepository == null)
                throw new ArgumentNullException(nameof(callsheetSceneCharacterRepository));
            
            _callsheetRepository = callsheetRepository;
            _shootingDayRepository = shootingDayRepository;
            _scheduleDayRepository = scheduleDayRepository;
            _callsheetSceneCharacterRepository = callsheetSceneCharacterRepository;
        }

        // Gets all callsheets for a project
        public IEnumerable<CallsheetSummaryDto> GetAllForParent(long projectID)
        {
            var callsheets = _callsheetRepository.GetAllForProject(projectID);

            var dtos = callsheets.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single character by id
        public FullCallsheetDto Get(Int64 ID)
        {
            var callsheet = _callsheetRepository.GetFull(ID);

            var dto = callsheet.TranslateFull();

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
                Start = linkedScheduleDay.Start ?? default(DateTime),
                End = linkedScheduleDay.End ?? default(DateTime),
                ShootingDayID = dto.ShootingDay.ID,
                ProjectID = dto.ProjectID,
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