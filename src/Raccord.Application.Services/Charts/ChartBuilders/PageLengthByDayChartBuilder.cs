using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Charts;
using Raccord.Application.Core.Services.Charts.ChartBuilders;
using Raccord.Core.Enums;
using Raccord.Data.EntityFramework.Repositories.Scenes;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;

namespace Raccord.Application.Services.Charts.ChartBuilders
{
    public class PageLengthByDayChartBuilder: IPageLengthByDayChartBuilder
    {
        private ISceneRepository _sceneRepository;
        private IShootingDayRepository _shootingDayRepository;
        public PageLengthByDayChartBuilder(
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
            return ChartInfoType.PagelengthByDay;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {            
            var baseData = new List<object>();
            var seriesData = new List<object>();

            // TODO implement for crew unit
            var shootingDays = _shootingDayRepository.GetAllForProject(request.ProjectID).OrderBy(sd=> sd.Date);
            foreach(var shootingDay in shootingDays)
            {
                baseData.Add($"SD {shootingDay.Number} - unit {shootingDay.CrewUnit.Name}");
                var pageLengthSum = shootingDay.ShootingDayScenes.Sum(sds=> sds.PageLength);
                seriesData.Add(shootingDay.Completed ? (int?)pageLengthSum : null);
            }
            return new ChartInfoDto
            {
                Title = "Pagelength by day",
                ChartType = ChartType.Column,
                DataType = ChartDataType.Pagelength,
                BaseData = baseData,
                ChartWidth = 2,
                SeriesData = new List<ChartSeriesDataDto>
                {
                    new ChartSeriesDataDto{ Name = "Pagelength", Data = seriesData}
                }
            };
        }
    }
}