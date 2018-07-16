using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.SceneProperties;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.SceneProperties;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class TimeOfDaysController : AbstractApiAuthController
    {
        private readonly ITimeOfDayService _timeOfDayService;

        public TimeOfDaysController(
            ITimeOfDayService timeOfDayService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (timeOfDayService == null)
                throw new ArgumentNullException(nameof(timeOfDayService));

            _timeOfDayService = timeOfDayService;
        }

        // GET: api/daynights/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<TimeOfDaySummaryViewModel> GetAll(long id)
        {
            var dtos = _timeOfDayService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/daynights/5
        [HttpGet("{id}")]
        public FullTimeOfDayViewModel Get(long id)
        {
            var dto = _timeOfDayService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/daynights/5
        [HttpGet("{id}/summary")]
        public TimeOfDaySummaryViewModel GetSummary(Int64 id)
        {
            var dto = _timeOfDayService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/daynights
        [HttpPost]
        public JsonResult Post([FromBody]TimeOfDayViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _timeOfDayService.Add(dto);
                }
                else
                {
                    id = _timeOfDayService.Update(dto);
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
                    message = "Something went wrong while attempting to update day/night",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/daynights/5
        [HttpDelete("{id}")]
        public JsonResult Delete(Int64 id)
        {
            var response = new JsonResponse();

            try
            {
                _timeOfDayService.Delete(id);

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
                    message = "Something went wrong while attempting to delete day/night.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/daynights/merge/5/1
        [HttpPost("merge/{toId}/{mergeId}")]
        public JsonResult Merge(long toId, long mergeId)
        {
            var response = new JsonResponse();

            try
            {
                _timeOfDayService.Merge(toId, mergeId);

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
                    message = "Something went wrong while attempting to merge day/night.",
                };
            }

            return new JsonResult(response);
        }
    }
}
