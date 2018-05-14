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
    public class CumulativeTimingsByDayChartBuilder: ICumulativeTimingsByDayChartBuilder
    {
        private ISceneRepository _sceneRepository;
        private IShootingDayRepository _shootingDayRepository;
        public CumulativeTimingsByDayChartBuilder(
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
            return ChartInfoType.CumulativeTimingsByDay;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {
            var baseData = new List<object>();
            var seriesData = new List<object>();
            
            var timings = new TimeSpan();

            // TODO implement for crew unit
            var shootingDays = _shootingDayRepository.GetAllForCrewUnit(request.ProjectID).OrderBy(sd=> sd.Date);
            foreach(var shootingDay in shootingDays)
            {
                baseData.Add($"SD {shootingDay.Number}");
                var completedTimings = new TimeSpan(shootingDay.ShootingDayScenes.Sum(sds=> sds.Timings.Ticks));
                timings = timings.Add(completedTimings);
                seriesData.Add(shootingDay.Completed ? timings : (TimeSpan?)null);
            }

            return new ChartInfoDto
            {
                Title = "Cumulative timings",
                ChartType = ChartType.Area,
                DataType = ChartDataType.Timespan,
                BaseData = baseData,
                SeriesData = new List<ChartSeriesDataDto>
                {
                    new ChartSeriesDataDto{ Name = "Timings", Data = seriesData}
                }
            };
        }
    }
}