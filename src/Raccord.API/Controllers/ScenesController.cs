using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Scenes;
using Raccord.API.ViewModels.Common.Sorting;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using PaginationUtilities = Raccord.API.ViewModels.Common.Paging.Utilities;
using SceneUtilities = Raccord.API.ViewModels.Scenes.Utilities;
using Raccord.API.ViewModels.Common.Paging;

namespace Raccord.API.Controllers
{
    public class ScenesController : AbstractApiAuthController
    {
        private readonly ISceneService _sceneService;

        public ScenesController(
            ISceneService sceneService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (sceneService == null)
                throw new ArgumentNullException(nameof(sceneService));

            _sceneService = sceneService;
        }

        // GET: api/scenes/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<SceneSummaryViewModel> GetAll(long id)
        {
            var dtos = _sceneService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/scenes/5
        [HttpGet("{id}")]
        public FullSceneViewModel Get(long id)
        {
            var dto = _sceneService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/scenes/5/summary
        [HttpGet("{id}/summary")]
        public SceneSummaryViewModel GetSummary(Int64 id)
        {
            var dto = _sceneService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/scenes
        [HttpPost]
        public JsonResult Post([FromBody]SceneViewModel vm)
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
        public JsonResult Delete(long id)
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

        // POST api/filter
        [HttpPost("filter")]
        public JsonResult Filter([FromBody]SceneFilterRequestViewModel vm, [FromQuery]int? pageSize = null, [FromQuery]int? page = null, [FromQuery]bool full = true)
        {
            var response = new JsonResponse();

            try
            {
                var paginationRequest = PaginationUtilities.ConstructRequest(pageSize, page, full);
                var requestDto = vm.Translate();
                var paginationResult = _sceneService.Filter(requestDto, paginationRequest);

                response = new JsonResponse
                {
                    ok = true,
                    data = paginationResult.Translate<SceneSummaryViewModel, SceneSummaryDto>(SceneUtilities.Translate),
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while trying to get search results.",
                };
            }

            return new JsonResult(response);
        }
    }
}
