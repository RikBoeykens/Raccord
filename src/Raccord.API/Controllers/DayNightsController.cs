using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.SceneProperties;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.SceneProperties;

namespace Raccord.API.Controllers
{
    [Route("api/[controller]")]
    public class DayNightsController : Controller
    {
        private readonly IDayNightService _dayNightService;

        public DayNightsController(IDayNightService dayNightService)
        {
            if (dayNightService == null)
                throw new ArgumentNullException(nameof(dayNightService));

            _dayNightService = dayNightService;
        }

        // GET: api/daynights/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<DayNightSummaryViewModel> GetAll(long id)
        {
            var dtos = _dayNightService.GetAllForProject(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/daynights/5
        [HttpGet("{id}")]
        public FullDayNightViewModel Get(long id)
        {
            var dto = _dayNightService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/daynights/5
        [HttpGet("{id}/summary")]
        public DayNightSummaryViewModel GetSummary(Int64 id)
        {
            var dto = _dayNightService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/daynights
        [HttpPost]
        public JsonResult Post([FromBody]DayNightViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _dayNightService.Add(dto);
                }
                else
                {
                    id = _dayNightService.Update(dto);
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
                _dayNightService.Delete(id);

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
    }
}
