using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Locations.LocationSets;

namespace Raccord.API.Controllers
{
    public class LocationSetsController : RaccordApiAuthController
    {
        private readonly ILocationSetService _locationSetService;

        public LocationSetsController(ILocationSetService locationSetService)
        {
            if (locationSetService == null)
                throw new ArgumentNullException(nameof(locationSetService));

            _locationSetService = locationSetService;
        }

        // GET: api/locationsets/1/scriptlocation
        [HttpGet("{id}/scriptlocation")]
        public IEnumerable<LocationSetLocationViewModel> GetLocations(long id)
        {
            var dtos = _locationSetService.GetLocations(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/locationsets/1/location
        [HttpGet("{id}/location")]
        public IEnumerable<LocationSetScriptLocationViewModel> GetScriptLocations(long id)
        {
            var dtos = _locationSetService.GetScriptLocations(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/locationsets/1/scene
        [HttpGet("{id}/scene")]
        public IEnumerable<LocationSetSummaryViewModel> GetForScene(long id)
        {
            var dtos = _locationSetService.GetSetsForScene(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET api/locationsets/5
        [HttpGet("{id}")]
        public FullLocationSetViewModel Get(long id)
        {
            var dto = _locationSetService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/locationsets
        [HttpPost]
        public JsonResult Post([FromBody]LocationSetViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _locationSetService.Add(dto);
                }
                else
                {
                    id = _locationSetService.Update(dto);
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
                    message = "Something went wrong while attempting to update location set",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/locationsets/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _locationSetService.Delete(id);

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
                    message = "Something went wrong while attempting to delete location set.",
                };
            }

            return new JsonResult(response);
        }
    }
}
