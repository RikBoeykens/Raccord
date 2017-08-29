using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.Data.EntityFramework.Repositories.Callsheets;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
using Raccord.Data.EntityFramework.Repositories.ShootingDays.Scenes;
using Raccord.Domain.Model.ShootingDays.Scenes;

namespace Raccord.Application.Services.ShootingDays
{
    public class ShootingDayService : IShootingDayService
    {
        private IShootingDayRepository _shootingDayRepository;
        private IShootingDaySceneRepository _shootingDaySceneRepository;
        private ICallsheetRepository _callsheetRepository;

        public ShootingDayService(
            IShootingDayRepository shootingDayRepository,
            IShootingDaySceneRepository shootingDaySceneRepository,
            ICallsheetRepository callsheetRepository
        ){
            if(shootingDayRepository==null)
                throw new ArgumentNullException(nameof(shootingDayRepository));
            if(shootingDaySceneRepository==null)
                throw new ArgumentNullException(nameof(shootingDaySceneRepository));
            if(callsheetRepository==null)
                throw new ArgumentNullException(nameof(callsheetRepository));

            _shootingDayRepository = shootingDayRepository;
            _shootingDaySceneRepository = shootingDaySceneRepository;
            _callsheetRepository = callsheetRepository;
        }

        public IEnumerable<ShootingDayDto> GetAvailableForCallsheet(long projectID)
        {
            var availableShootingDays = _shootingDayRepository.GetAllForProject(projectID).Where(sd=> !sd.CallsheetID.HasValue);

            return availableShootingDays.Select(asd=> asd.Translate());
        }

        public IEnumerable<ShootingDayDto> GetAvailableForCompletion(long projectID)
        {
            var availableShootingDays = _shootingDayRepository.GetAllForProject(projectID).Where(sd=> sd.CallsheetID.HasValue&& !sd.Completed);

            return availableShootingDays.Select(asd=> asd.Translate());
        }

        public IEnumerable<ShootingDaySummaryDto> GetCompleted(long projectID)
        {
            var availableShootingDays = _shootingDayRepository.GetAllForProject(projectID).Where(sd=> sd.Completed);

            return availableShootingDays.Select(asd=> asd.TranslateSummary());
        }

        public IEnumerable<ShootingDayDto> GetAll(long projectID)
        {
            var shootingDays = _shootingDayRepository.GetAllForProject(projectID);

            return shootingDays.Select(asd=> asd.Translate());
        }

        public FullShootingDayDto GetFull(long ID)
        {
            var shootingDay = _shootingDayRepository.GetFull(ID);
            var previousShootingDays = _shootingDayRepository.GetAllBeforeDate(shootingDay.ProjectID, shootingDay.Date);
            return shootingDay.TranslateFull(previousShootingDays);
        }

        public ShootingDaySummaryDto GetSummary(long ID)
        {
            var shootingDay = _shootingDayRepository.GetSummary(ID);
            return shootingDay.TranslateSummary();
        }

        public long PrepareForCompletion(long ID)
        {
            var shootingDay = _shootingDayRepository.GetFull(ID);
            var callsheet = _callsheetRepository.GetSummary(shootingDay.CallsheetID.Value);

            shootingDay.Start = callsheet.Start;
            shootingDay.End = callsheet.End;
            shootingDay.Completed = true;
            foreach(var scene in shootingDay.ShootingDayScenes)
            {
                scene.LocationSetID = scene.CallsheetScene.LocationSetID;
            }

            _shootingDayRepository.Edit(shootingDay);
            _shootingDayRepository.Commit();
            return shootingDay.ID;
        }

        public long Update(ShootingDayDto dto)
        {
            var shootingDay = _shootingDayRepository.GetSingle(dto.ID);
            
            shootingDay.Start = dto.Start;
            shootingDay.Turn = dto.Turn;
            shootingDay.End = dto.End;
            shootingDay.OverTime = dto.OverTime;
            shootingDay.Completed = dto.Completed;

            _shootingDayRepository.Edit(shootingDay);
            _shootingDayRepository.Commit();
            return shootingDay.ID;
        }
    }
}