using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.API.ViewModels.Charts;
using Raccord.Core.Enums;
using Raccord.Application.Core.Services.Charts;

namespace Raccord.API.Controllers
{
    public class ChartsController : AbstractApiAuthController
    {
        private readonly IChartService _chartService;
        public ChartsController(
            IChartService chartService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if(chartService == null)
                throw new ArgumentNullException(nameof(chartService));

            _chartService = chartService;
        }

        // GET: api/charts/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<ChartInfoViewModel> GetForProject(long id)
        {
            var dtos = _chartService.GetForProject(id);

            return dtos.Select(c=> c.Translate());
        }
    }
}
