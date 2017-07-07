using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.ShootingDays;
using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.API.Controllers
{
    [Route("api/shootingdays")]
    public class ShootingDaysController : Controller
    {
        private IShootingDayService _shootingDayService;

        public ShootingDaysController(
            IShootingDayService shootingDayService
        ){
            if(shootingDayService==null)
                throw new ArgumentNullException(nameof(shootingDayService));

            _shootingDayService = shootingDayService;
        }

        
        // GET: api/shootingdays/1/available
        [HttpGet("{projectID}/available")]
        public IEnumerable<ShootingDayViewModel> GetAvailableDays(long projectID)
        {
            var availableDays = _shootingDayService.GetAvailableDays(projectID);

            return availableDays.Select(ad=> ad.Translate());
        }
    }
}