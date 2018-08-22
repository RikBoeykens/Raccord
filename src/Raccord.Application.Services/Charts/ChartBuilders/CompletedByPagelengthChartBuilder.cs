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
    public class CompletedByPagelengthChartBuilder: ICompletedByPagelengthChartBuilder
    {
        private ISceneRepository _sceneRepository;
        private IShootingDayRepository _shootingDayRepository;
        public CompletedByPagelengthChartBuilder(
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
            return ChartInfoType.CompletedByPagelength;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {
            // Get full pagelength
            var scenes = _sceneRepository.GetAllForProject(request.ProjectID);
            var totalPagelength = scenes.Sum(s=> s.PageLength);

            // TODO implement for crew unit
            var shootingDays = _shootingDayRepository.GetAllForProject(request.ProjectID);
            var shotPagelength = shootingDays.Sum(sd=> sd.ShootingDayScenes.Sum(sds=> sds.PageLength));
            
            var baseData = new List<object>{ "Shot", "Not Shot"};
            var seriesData = new List<object>{ shotPagelength, totalPagelength - shotPagelength };
            
            return new ChartInfoDto
            {
                Title = "Completed by pagelength",
                ChartType = ChartType.Pie,
                DataType = ChartDataType.Pagelength,
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