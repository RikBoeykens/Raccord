using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.API.Filters;
using Raccord.Core.Enums;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class ScheduleDaysController : AbstractProjectsController
    {
        private readonly IScheduleDayService _scheduleDayService;

        public ScheduleDaysController(
            IScheduleDayService scheduleDayService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (scheduleDayService == null)
                throw new ArgumentNullException(nameof(scheduleDayService));

            _scheduleDayService = scheduleDayService;
        }

        // GET: api/scheduledays/user
        [HttpGet("user")]
        public IEnumerable<FullScheduleDayCrewUnitViewModel> GetAllForUser(long authProjectId)
        {
            var dtos = _scheduleDayService.GetForProjectUser(authProjectId, GetUserId());

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/scheduledays/1/crewunit
        [HttpGet("{crewUnitId}/crewunit")]
        public IEnumerable<FullScheduleDayViewModel> GetAll(long crewUnitId)
        {
            var dtos = _scheduleDayService.GetAllForParent(crewUnitId);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/scheduledays/5
        [HttpGet("{id}")]
        public FullScheduleDayViewModel Get(long id)
        {
            var dto = _scheduleDayService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/scheduledays/5
        [HttpGet("{id}/summary")]
        public ScheduleDaySummaryViewModel GetSummary(long id)
        {
            var dto = _scheduleDayService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/scheduledays
        [HttpPost]
        [ProjectPermissionFilter(ProjectPermissionEnum.CanEditGeneral)]
        public JsonResult Post([FromBody]ScheduleDayViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _scheduleDayService.Add(dto);
                }
                else
                {
                    id = _scheduleDayService.Update(dto);
                }

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
                    message = "Something went wrong while attempting to update schedule day",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/scheduledays/5
        [HttpDelete("{id}")]
        [ProjectPermissionFilter(ProjectPermissionEnum.CanEditGeneral)]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _scheduleDayService.Delete(id);

                response = new JsonResponse
                {
                    ok = true,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to delete schedule days.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/scheduledays/5/publish
        [HttpPost("publish")]
        [ProjectPermissionFilter(ProjectPermissionEnum.CanEditGeneral)]
        public JsonResult Publish(long authProjectId)
        {
            var response = new JsonResponse();

            try
            {
                _scheduleDayService.PublishDays(authProjectId);

                response = new JsonResponse
                {
                    ok = true,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to publish schedule days.",
                };
            }

            return new JsonResult(response);
        }
    }
}
