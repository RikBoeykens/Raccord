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
    public class BurndownBySceneChartBuilder: IBurndownBySceneChartBuilder
    {
        private ISceneRepository _sceneRepository;
        private IShootingDayRepository _shootingDayRepository;
        public BurndownBySceneChartBuilder(
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
            return ChartInfoType.BurndownByScene;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {
            var baseData = new List<object>();
            var seriesData = new List<object>();

            // Get full scene count
            var scenes = _sceneRepository.GetAllForProject(request.ProjectID);
            var totalScenes = scenes.Count();

            // TODO implement for crew unit
            var shootingDays = _shootingDayRepository.GetAllForCrewUnit(request.ProjectID).OrderBy(sd=> sd.Date);
            foreach(var shootingDay in shootingDays)
            {
                baseData.Add($"SD {shootingDay.Number}");
                var completedScenes = shootingDay.ShootingDayScenes.Count(sds=> sds.Completion == Completion.Completed);
                totalScenes -= completedScenes;
                seriesData.Add(shootingDay.Completed ? (int?)totalScenes : null);
            }

            return new ChartInfoDto
            {
                Title = "Burndown by scene",
                ChartType = ChartType.Area,
                DataType = ChartDataType.Number,
                BaseData = baseData,
                SeriesData = new List<ChartSeriesDataDto>
                {
                    new ChartSeriesDataDto{ Name = "Burndown", Data = seriesData}
                }
            };
        }
    }
}