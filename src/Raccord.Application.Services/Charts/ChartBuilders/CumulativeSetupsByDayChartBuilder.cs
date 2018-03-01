using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Charts;
using Raccord.Application.Core.Services.Charts.ChartBuilders;
using Raccord.Core.Enums;
using Raccord.Data.EntityFramework.Repositories.Scenes;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
using Raccord.Data.EntityFramework.Repositories.ShootingDays.Scenes;

namespace Raccord.Application.Services.Charts.ChartBuilders
{
    public class CumulativeSetupsByDayChartBuilder: ICumulativeSetupsByDayChartBuilder
    {
        private ISceneRepository _sceneRepository;
        private IShootingDayRepository _shootingDayRepository;
        public CumulativeSetupsByDayChartBuilder(
            ISceneRepository sceneRepository,
            IShootingDayRepository shootingDayRepository
        )
        {
            if(sceneRepository==null)
                throw new ArgumentNullException(nameof(sceneRepository));
            if(shootingDayRepository==null)
                throw new ArgumentNullException(nameof(shootingDayRepository));

                _sceneRepository = sceneRepository;
                _shootingDayRepository = shootingDayRepository;
        }

        public new ChartInfoType GetType()
        {
            return ChartInfoType.CumulativeSetupsByDay;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {
            var baseData = new List<object>();
            var seriesData = new List<object>();
            
            var setups = 0;

            // TODO implement for crew unit
            var shootingDays = _shootingDayRepository.GetAllForCrewUnit(request.ProjectID).OrderBy(sd=> sd.Date);
            foreach(var shootingDay in shootingDays)
            {
                baseData.Add($"SD {shootingDay.Number}");
                var totalSetups = shootingDay.Slates.Count();
                setups = setups += totalSetups;
                seriesData.Add(shootingDay.Completed ? setups : (int?)null);
            }

            return new ChartInfoDto
            {
                Title = "Cumulative setups",
                ChartType = ChartType.Area,
                DataType = ChartDataType.Number,
                BaseData = baseData,
                SeriesData = new List<ChartSeriesDataDto>
                {
                    new ChartSeriesDataDto{ Name = "Setups", Data = seriesData}
                }
            };
        }
    }
}