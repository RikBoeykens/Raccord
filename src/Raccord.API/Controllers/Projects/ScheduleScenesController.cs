using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.API.ViewModels.Common.Sorting;
using System.Threading.Tasks;
using Raccord.API.Filters;
using Raccord.Core.Enums;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class ScheduleScenesController : AbstractProjectsController
    {
        private readonly IScheduleSceneService _scheduleSceneService;

        public ScheduleScenesController(
            IScheduleSceneService scheduleSceneService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (scheduleSceneService == null)
                throw new ArgumentNullException(nameof(scheduleSceneService));

            _scheduleSceneService = scheduleSceneService;
        }

        // GET: api/schedulescenes/1/day
        [HttpGet("{id}/day")]
        public IEnumerable<ScheduleSceneSceneViewModel> GetScenes(long id)
        {
            var dtos = _scheduleSceneService.GetScenes(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/schedulescenes/1/scene
        [HttpGet("{id}/scene")]
        public IEnumerable<ScheduleSceneDayViewModel> GetDays(long id)
        {
            var dtos = _scheduleSceneService.GetDays(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET api/schedulescenes/5
        [HttpGet("{id}")]
        public FullScheduleSceneViewModel Get(long id)
        {
            var dto = _scheduleSceneService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/schedulescenes
        [HttpPost]
        [ProjectPermissionFilter(ProjectPermissionEnum.CanEditGeneral)]
        public JsonResult Post([FromBody]ScheduleSceneViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _scheduleSceneService.Add(dto);
                }
                else
                {
                    id = _scheduleSceneService.Update(dto);
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
                    message = "Something went wrong while attempting to update schedule scene",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/schedulescenes/5
        [HttpDelete("{id}")]
        [ProjectPermissionFilter(ProjectPermissionEnum.CanEditGeneral)]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _scheduleSceneService.Delete(id);

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
                    message = "Something went wrong while attempting to delete schedule scene.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/sort
        [HttpPost("sort")]
        [ProjectPermissionFilter(ProjectPermissionEnum.CanEditGeneral)]
        public async Task<JsonResult> Sort([FromBody]SortOrderViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                await _scheduleSceneService.SortAsync(dto);

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
                    message = "Something went wrong while attempting to sort scenes",
                };
            }

            return new JsonResult(response);
        }
    }
}
