using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Callsheets.CallsheetScenes;
using Raccord.API.ViewModels.Common.Sorting;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;

namespace Raccord.API.Controllers
{
    [Route("api/[controller]")]
    public class CallsheetScenesController : Controller
    {
        private readonly ICallsheetSceneService _callsheetSceneService;

        public CallsheetScenesController(ICallsheetSceneService callsheetSceneService)
        {
            if (callsheetSceneService == null)
                throw new ArgumentNullException(nameof(callsheetSceneService));

            _callsheetSceneService = callsheetSceneService;
        }

        // GET: api/callsheetscenes/1/callsheet
        [HttpGet("{id}/callsheet")]
        public IEnumerable<CallsheetSceneSceneViewModel> GetScenes(long id)
        {
            var dtos = _callsheetSceneService.GetScenes(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/callsheetscenes/1/locations
        [HttpGet("{id}/locations")]
        public IEnumerable<CallsheetSceneLocationViewModel> GetLocations(long id)
        {
            var dtos = _callsheetSceneService.GetLocations(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/callsheetscenes/1/characters
        [HttpGet("{id}/characters")]
        public IEnumerable<CallsheetSceneCharactersViewModel> GetCharacters(long id)
        {
            var dtos = _callsheetSceneService.GetCharacters(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/callsheetscenes/1/scene
        [HttpGet("{id}/scene")]
        public IEnumerable<CallsheetSceneCallsheetViewModel> GetCallsheets(long id)
        {
            var dtos = _callsheetSceneService.GetCallsheets(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET api/callsheetscenes/5
        [HttpGet("{id}")]
        public FullCallsheetSceneViewModel Get(long id)
        {
            var dto = _callsheetSceneService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/callsheetscenes
        [HttpPost]
        public JsonResult Post([FromBody]CallsheetSceneViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _callsheetSceneService.Add(dto);
                }
                else
                {
                    id = _callsheetSceneService.Update(dto);
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
                    message = "Something went wrong while attempting to update callsheet scene",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/callsheetscenes/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _callsheetSceneService.Delete(id);

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
                    message = "Something went wrong while attempting to delete callsheet scene.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/sort
        [HttpPost("sort")]
        public JsonResult Sort([FromBody]SortOrderViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                _callsheetSceneService.Sort(dto);

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
