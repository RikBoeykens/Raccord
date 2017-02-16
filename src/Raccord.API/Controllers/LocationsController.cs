using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Locations;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Locations;

namespace Raccord.API.Controllers
{
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            if (locationService == null)
                throw new ArgumentNullException(nameof(locationService));

            _locationService = locationService;
        }

        // GET: api/locations/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<LocationSummaryViewModel> GetAll(long id)
        {
            var dtos = _locationService.GetAllForProject(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/locations/5
        [HttpGet("{id}")]
        public LocationViewModel Get(long id)
        {
            var dto = _locationService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/locations/5
        [HttpGet("{id}/summary")]
        public LocationSummaryViewModel GetSummary(long id)
        {
            var dto = _locationService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/location
        [HttpPost]
        public JsonResult Post([FromBody]LocationViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _locationService.Add(dto);
                }
                else
                {
                    id = _locationService.Update(dto);
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
                    message = "Something went wrong while attempting to update location",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/locations/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _locationService.Delete(id);

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
                    message = "Something went wrong while attempting to delete location.",
                };
            }

            return new JsonResult(response);
        }
    }
}
