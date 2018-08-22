using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Charts;
using Raccord.Application.Core.Services.Charts.ChartBuilders;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Charts
{
    // Service used for character functionality
    public class ChartService : IChartService
    {
        private readonly IBurndownByPagelengthChartBuilder _burndownByPagelengthChartBuilder;
        private readonly IBurndownBySceneChartBuilder _burndownBySceneChartBuilder;
        private readonly ICompletedByPagelengthChartBuilder _completedByPagelengthChartBuilder;
        private readonly ICompletedBySceneChartBuilder _completedBySceneChartBuilder;
        private readonly IPageLengthByDayChartBuilder _pagelengthByDayChartBuilder;
        private readonly ICumulativeTimingsByDayChartBuilder _cumulativeTimingsByDayChartBuilder;
        private readonly ICumulativeSetupsByDayChartBuilder _cumulativeSetupsByDayChartBuilder;
        private readonly ISetupsByDayChartBuilder _setupsByDayChartBuilder;
        private readonly IVfxSetupsChartBuilder _vfxSetupsChartBuilder;
        // Initialises a new ChartService
        public ChartService(
            IBurndownByPagelengthChartBuilder burndownByPagelengthChartBuilder,
            IBurndownBySceneChartBuilder burndownBySceneChartBuilder,
            ICompletedByPagelengthChartBuilder completedByPagelengthChartBuilder,
            ICompletedBySceneChartBuilder completedBySceneChartBuilder,
            IPageLengthByDayChartBuilder pagelengthByDayChartBuilder,
            ICumulativeTimingsByDayChartBuilder cumulativeTimingsByDayChartBuilder,
            ICumulativeSetupsByDayChartBuilder cumulativeSetupsByDayChartBuilder,
            ISetupsByDayChartBuilder setupsByDayChartBuilder,
            IVfxSetupsChartBuilder vfxSetupsChartBuilder
            )
        {
            if(burndownByPagelengthChartBuilder==null)
                throw new ArgumentNullException(nameof(burndownByPagelengthChartBuilder));
            if(burndownBySceneChartBuilder==null)
                throw new ArgumentNullException(nameof(burndownBySceneChartBuilder));
            if(completedByPagelengthChartBuilder==null)
                throw new ArgumentNullException(nameof(completedByPagelengthChartBuilder));
            if(completedBySceneChartBuilder==null)
                throw new ArgumentNullException(nameof(completedBySceneChartBuilder));
            if(pagelengthByDayChartBuilder==null)
                throw new ArgumentNullException(nameof(pagelengthByDayChartBuilder));
            if(cumulativeTimingsByDayChartBuilder==null)
                throw new ArgumentNullException(nameof(cumulativeTimingsByDayChartBuilder));
            if(cumulativeSetupsByDayChartBuilder==null)
                throw new ArgumentNullException(nameof(cumulativeSetupsByDayChartBuilder));
            if(setupsByDayChartBuilder==null)
                throw new ArgumentNullException(nameof(setupsByDayChartBuilder));
            if(vfxSetupsChartBuilder==null)
                throw new ArgumentNullException(nameof(vfxSetupsChartBuilder));

            _burndownByPagelengthChartBuilder = burndownByPagelengthChartBuilder;
            _burndownBySceneChartBuilder = burndownBySceneChartBuilder;
            _completedByPagelengthChartBuilder = completedByPagelengthChartBuilder;
            _completedBySceneChartBuilder = completedBySceneChartBuilder;
            _pagelengthByDayChartBuilder = pagelengthByDayChartBuilder;
            _cumulativeTimingsByDayChartBuilder = cumulativeTimingsByDayChartBuilder;
            _cumulativeSetupsByDayChartBuilder = cumulativeSetupsByDayChartBuilder;
            _setupsByDayChartBuilder = setupsByDayChartBuilder;
            _vfxSetupsChartBuilder = vfxSetupsChartBuilder;
        }

        // Gets all characters for a project
        public IEnumerable<ChartInfoDto> GetForProject(long projectID)
        {
            var services = GetChartBuilders();
            var results = new List<ChartInfoDto>();

            foreach(var service in services)
            {
                results.Add(service.GetChartInfo(new ChartRequestDto{ ProjectID = projectID}));
            }

            return results;
        }

        private IEnumerable<IChartBuilder> GetChartBuilders()
        {
            var services = new List<IChartBuilder>
            {
                _burndownByPagelengthChartBuilder,
                _completedByPagelengthChartBuilder,
                _burndownBySceneChartBuilder,
                _completedBySceneChartBuilder,
                _pagelengthByDayChartBuilder,
                //_cumulativeTimingsByDayChartBuilder,
                _cumulativeSetupsByDayChartBuilder,
                _setupsByDayChartBuilder,
                _vfxSetupsChartBuilder
            };

            return services;
        }
    }
}