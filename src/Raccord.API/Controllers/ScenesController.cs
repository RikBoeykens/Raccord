using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Scenes;
using Raccord.API.ViewModels.Common.Sorting;

namespace Raccord.API.Controllers
{
    [Route("api/[controller]")]
    public class ScenesController : Controller
    {
        private readonly ISceneService _sceneService;

        public ScenesController(ISceneService sceneService)
        {
            if (sceneService == null)
                throw new ArgumentNullException(nameof(sceneService));

            _sceneService = sceneService;
        }

        // GET: api/scenes/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<SceneSummaryViewModel> GetAll(long id)
        {
            var dtos = _sceneService.GetAllForProject(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/scenes/5
        [HttpGet("{id}")]
        public SceneViewModel Get(long id)
        {
            var dto = _sceneService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/scenes/5
        [HttpGet("{id}/summary")]
        public SceneSummaryViewModel GetSummary(Int64 id)
        {
            var dto = _sceneService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/scenes
        [HttpPost]
        public JsonResult Post([FromBody]SceneSummaryViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _sceneService.Add(dto);
                }
                else
                {
                    id = _sceneService.Update(dto);
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
                    message = "Something went wrong while attempting to update scene",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/scenes/5
        [HttpDelete("{id}")]
        public JsonResult Delete(Int64 id)
        {
            var response = new JsonResponse();

            try
            {
                _sceneService.Delete(id);

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
                    message = "Something went wrong while attempting to delete scene.",
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

                _sceneService.Sort(dto);

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
