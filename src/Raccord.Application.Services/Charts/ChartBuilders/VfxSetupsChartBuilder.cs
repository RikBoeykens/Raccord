using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Charts;
using Raccord.Application.Core.Services.Charts.ChartBuilders;
using Raccord.Core.Enums;
using Raccord.Data.EntityFramework.Repositories.Scenes;
using Raccord.Data.EntityFramework.Repositories.ShootingDays;
using Raccord.Data.EntityFramework.Repositories.ShootingDays.Scenes;
using Raccord.Data.EntityFramework.Repositories.Shots.Slates;

namespace Raccord.Application.Services.Charts.ChartBuilders
{
    public class VfxSetupsChartBuilder: IVfxSetupsChartBuilder
    {
        private ISlateRepository _slateRepository;
        public VfxSetupsChartBuilder(
            ISlateRepository slateRepository
        )
        {
            if(slateRepository==null)
                throw new ArgumentNullException(nameof(slateRepository));

                _slateRepository = slateRepository;
        }

        public new ChartInfoType GetType()
        {
            return ChartInfoType.VfxSetups;
        }

        public ChartInfoDto GetChartInfo(ChartRequestDto request)
        {
            var slateCount = _slateRepository.GetAllForProject(request.ProjectID).Count();
            var vfxSlateCount = _slateRepository.GetAllForProject(request.ProjectID).Count(s=> s.IsVfx);

            var baseData = new List<object>{ "VFX", "Non VFX"};
            var seriesData = new List<object>{ vfxSlateCount, slateCount - vfxSlateCount };

            return new ChartInfoDto
            {
                Title = "VFX Setups",
                ChartType = ChartType.Pie,
                DataType = ChartDataType.Number,
                BaseData = baseData,
                ChartWidth = 1,
                SeriesData = new List<ChartSeriesDataDto>
                {
                    new ChartSeriesDataDto{ Name = "Setups", Data = seriesData}
                }
            };
        }
    }
}