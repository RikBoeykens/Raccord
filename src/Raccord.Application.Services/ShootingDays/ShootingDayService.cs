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

        public IEnumerable<ShootingDayDto> GetAvailableDays(long projectID)
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
            var previousShootingDayScenes = _shootingDaySceneRepository.GetAllBeforeDate(shootingDay.Date);
            return shootingDay.TranslateFull(previousShootingDayScenes);
        }

        public ShootingDaySummaryDto GetSummary(long ID)
        {
            var shootingDay = _shootingDayRepository.GetSummary(ID);
            return shootingDay.TranslateSummary();
        }

        public void PrepareForCompletion(long ID)
        {
            var shootingDay = _shootingDayRepository.GetSingle(ID);
            var callsheet = _callsheetRepository.GetSummary(shootingDay.CallsheetID.Value);

            shootingDay.Start = callsheet.Start;
            shootingDay.End = callsheet.End;
            shootingDay.Completed = true;
            shootingDay.ShootingDayScenes = callsheet.CallsheetScenes.Select(cs=> new ShootingDayScene
            {
                SceneID = cs.SceneID,
                PageLength = cs.PageLength,
                LocationSetID = cs.LocationSetID,
            }).ToList();
            _shootingDayRepository.Edit(shootingDay);
            _shootingDayRepository.Commit();
        }

        public void Update(ShootingDayDto dto)
        {

        }
    }
}