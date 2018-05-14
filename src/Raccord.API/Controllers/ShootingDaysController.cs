using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
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

        
        // GET: api/shootingdays/1/available/callsheet
        [HttpGet("{projectID}/available/callsheet")]
        public IEnumerable<ShootingDayCrewUnitViewModel> GetAvailableCallsheet(long projectID)
        {
            var availableDays = _shootingDayService.GetAvailableForCallsheet(projectID);

            return availableDays.Select(ad=> ad.Translate());
        }

        // GET: api/shootingdays/1/available/completion
        [HttpGet("{projectID}/available/completion")]
        public IEnumerable<ShootingDayCrewUnitViewModel> GetAvailableCompletion(long projectID)
        {
            var availableDays = _shootingDayService.GetAvailableForCompletion(projectID);

            return availableDays.Select(ad=> ad.Translate());
        }
        
        // GET: api/shootingdays/1/completed
        [HttpGet("{projectID}/completed")]
        public IEnumerable<ShootingDaySummaryViewModel> GetCompleted(long projectID)
        {
            var availableDays = _shootingDayService.GetCompleted(projectID);

            return availableDays.Select(ad=> ad.Translate());
        }

        
        // GET: api/shootingdays/1/crewunit
        [HttpGet("{crewUnitId}/crewunit")]
        public IEnumerable<ShootingDayViewModel> GetAll(long crewUnitId)
        {
            var availableDays = _shootingDayService.GetAll(crewUnitId);

            return availableDays.Select(ad=> ad.Translate());
        }
        
        // GET api/shootingdays/5
        [HttpGet("{id}")]
        public FullShootingDayViewModel Get(long id)
        {
            var dto = _shootingDayService.GetFull(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/shootingdays/5/summary
        [HttpGet("{id}/summary")]
        public ShootingDaySummaryViewModel GetSummary(Int64 id)
        {
            var dto = _shootingDayService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/shootingdays/5/preparecompletion
        [HttpPost("{id}/preparecompletion")]
        public JsonResult PrepareCompletion(long id)
        {
            var response = new JsonResponse();

            try
            {
                long returnedId  = _shootingDayService.PrepareForCompletion(id);

                response = new JsonResponse
                {
                    ok = true,
                    data = id,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to prepare shooting day for completion",
                };
            }

            return new JsonResult(response);
        }

        // POST api/shootingdays
        [HttpPost]
        public JsonResult Post([FromBody]ShootingDayViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id  = _shootingDayService.Update(dto);

                response = new JsonResponse
                {
                    ok = true,
                    data = id,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to update shooting day",
                };
            }

            return new JsonResult(response);
        }
    }
}