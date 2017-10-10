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
        private readonly ICompletedByPagelengthChartBuilder _completedByPagelengthChartBuilder;
        private readonly IPageLengthByDayChartBuilder _pagelengthByDayChartBuilder;
        // Initialises a new ChartService
        public ChartService(
            IBurndownByPagelengthChartBuilder burndownByPagelengthChartBuilder,
            ICompletedByPagelengthChartBuilder completedByPagelengthChartBuilder,
            IPageLengthByDayChartBuilder pagelengthByDayChartBuilder
            )
        {
            if(burndownByPagelengthChartBuilder==null)
                throw new ArgumentNullException(nameof(burndownByPagelengthChartBuilder));
            if(completedByPagelengthChartBuilder==null)
                throw new ArgumentNullException(nameof(completedByPagelengthChartBuilder));
            if(pagelengthByDayChartBuilder==null)
                throw new ArgumentNullException(nameof(pagelengthByDayChartBuilder));

            _burndownByPagelengthChartBuilder = burndownByPagelengthChartBuilder;
            _completedByPagelengthChartBuilder = completedByPagelengthChartBuilder;
            _pagelengthByDayChartBuilder = pagelengthByDayChartBuilder;
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
                _pagelengthByDayChartBuilder
            };

            return services;
        }
    }
}