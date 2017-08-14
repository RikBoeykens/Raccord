using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.ShootingDays;
using Raccord.Application.Core.Services.ShootingDays;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class ShootingDaysController : AbstractApiAuthController
    {
        private IShootingDayService _shootingDayService;

        public ShootingDaysController(
            IShootingDayService shootingDayService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
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

        
        // GET: api/shootingdays/1/project
        [HttpGet("{projectID}/project")]
        public IEnumerable<ShootingDayViewModel> GetAll(long projectID)
        {
            var availableDays = _shootingDayService.GetAll(projectID);

            return availableDays.Select(ad=> ad.Translate());
        }
    }
}