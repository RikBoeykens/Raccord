using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;

namespace Raccord.Application.Services.ShootingDays
{
    public class ShootingDayService : IShootingDayService
    {
        private IShootingDayRepository _shootingDayRepository;

        public ShootingDayService(
            IShootingDayRepository shootingDayRepository
        ){
            if(shootingDayRepository==null)
                throw new ArgumentNullException(nameof(shootingDayRepository));

            _shootingDayRepository = shootingDayRepository;
        }

        public IEnumerable<ShootingDayDto> GetAvailableDays(long projectID)
        {
            var availableShootingDays = _shootingDayRepository.GetAllForProject(projectID).Where(sd=> !sd.CallsheetID.HasValue);

            return availableShootingDays.Select(asd=> asd.Translate());
        }
    }
}