using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.ScriptLocations;

namespace Raccord.API.Controllers
{
    public class ScriptLocationsController : RaccordApiAuthController
    {
        private readonly IScriptLocationService _scriptLocationService;

        public ScriptLocationsController(IScriptLocationService locationService)
        {
            if (locationService == null)
                throw new ArgumentNullException(nameof(locationService));

            _scriptLocationService = locationService;
        }

        // GET: api/scriptlocations/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<ScriptLocationSummaryViewModel> GetAll(long id)
        {
            var dtos = _scriptLocationService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/scriptlocations/5
        [HttpGet("{id}")]
        public FullScriptLocationViewModel Get(long id)
        {
            var dto = _scriptLocationService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/scriptlocations/5
        [HttpGet("{id}/summary")]
        public ScriptLocationSummaryViewModel GetSummary(long id)
        {
            var dto = _scriptLocationService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/scriptlocations
        [HttpPost]
        public JsonResult Post([FromBody]ScriptLocationViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _scriptLocationService.Add(dto);
                }
                else
                {
                    id = _scriptLocationService.Update(dto);
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
                    message = "Something went wrong while attempting to update script location",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/scriptlocations/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _scriptLocationService.Delete(id);

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
                    message = "Something went wrong while attempting to delete script location.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/scriptlocations/merge/5/1
        [HttpPost("merge/{toId}/{mergeId}")]
        public JsonResult Merge(long toId, long mergeId)
        {
            var response = new JsonResponse();

            try
            {
                _scriptLocationService.Merge(toId, mergeId);

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
                    message = "Something went wrong while attempting to merge script locations.",
                };
            }

            return new JsonResult(response);
        }
    }
}
