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
    public class CompletedBySceneChartBuilder: ICompletedBySceneChartBuilder
    {
        private ISceneRepository _sceneRepository;
        private IShootingDayRepository _shootingDayRepository;
        public CompletedBySceneChartBuilder(
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
            return ChartInfoType.CompletedByScene;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {
            // Get full scene count
            var scenes = _sceneRepository.GetAllForProject(request.ProjectID);
            var totalScenes = scenes.Count();

            // TODO implement for crew unit
            var shootingDays = _shootingDayRepository.GetAllForProject(request.ProjectID);
            var scenesCompleted = shootingDays.Sum(sd=> sd.ShootingDayScenes.Count(sds=> sds.Completion == Completion.Completed));
            
            var baseData = new List<object>{ "Shot", "Not Shot"};
            var seriesData = new List<object>{ scenesCompleted, totalScenes - scenesCompleted };
            
            return new ChartInfoDto
            {
                Title = "Completed by scene",
                ChartType = ChartType.Pie,
                DataType = ChartDataType.Number,
                BaseData = baseData,
                ChartWidth = 1,
                SeriesData = new List<ChartSeriesDataDto>
                {
                    new ChartSeriesDataDto{ Name = "", Data = seriesData}
                }
            };
        }
    }
}