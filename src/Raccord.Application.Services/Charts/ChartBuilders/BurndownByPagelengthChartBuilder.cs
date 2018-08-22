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
    public class BurndownByPagelengthChartBuilder: IBurndownByPagelengthChartBuilder
    {
        private ISceneRepository _sceneRepository;
        private IShootingDayRepository _shootingDayRepository;
        public BurndownByPagelengthChartBuilder(
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
            return ChartInfoType.BurndownByPagelength;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {
            var baseData = new List<object>();
            var seriesData = new List<object>();

            // Get full pagelength
            var scenes = _sceneRepository.GetAllForProject(request.ProjectID);
            var totalPagelength = scenes.Sum(s=> s.PageLength);

            // TODO implement for crew unit
            var shootingDays = _shootingDayRepository.GetAllForProject(request.ProjectID).OrderBy(sd=> sd.Date);
            
            //set data for 0
            baseData.Add("0");
            seriesData.Add(totalPagelength);

            foreach(var shootingDay in shootingDays)
            {
                baseData.Add($"SD {shootingDay.Number} - unit {shootingDay.CrewUnit.Name}");
                var pageLengthSum = shootingDay.ShootingDayScenes.Sum(sds=> sds.PageLength);
                totalPagelength -= pageLengthSum;
                seriesData.Add(shootingDay.Completed ? (int?)totalPagelength : null);
            }

            return new ChartInfoDto
            {
                Title = "Burndown by pagelength",
                ChartType = ChartType.Area,
                DataType = ChartDataType.Pagelength,
                BaseData = baseData,
                ChartWidth = 3,
                SeriesData = new List<ChartSeriesDataDto>
                {
                    new ChartSeriesDataDto{ Name = "Burndown", Data = seriesData}
                }
            };
        }
    }
}