using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes;
using Raccord.API.ViewModels.Common.Sorting;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;

namespace Raccord.API.Controllers
{
    public class BreakdownItemScenesController : RaccordApiAuthController
    {
        private readonly IBreakdownItemSceneService _breakdownItemSceneService;

        public BreakdownItemScenesController(IBreakdownItemSceneService breakdownItemSceneService)
        {
            if (breakdownItemSceneService == null)
                throw new ArgumentNullException(nameof(breakdownItemSceneService));

            _breakdownItemSceneService = breakdownItemSceneService;
        }

        // GET: api/breakdownitemscenes/1/items
        [HttpGet("{id}/items")]
        public IEnumerable<LinkedBreakdownItemViewModel> GetItems(long id)
        {
            var dtos = _breakdownItemSceneService.GetItems(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/breakdownitemscenes/1/scenes
        [HttpGet("{id}/scenes")]
        public IEnumerable<LinkedSceneViewModel> GetScenes(long id)
        {
            var dtos = _breakdownItemSceneService.GetScenes(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/breakdownitemscenes/5/1/link
        [HttpPost("{itemId}/{sceneId}/addlink")]
        public JsonResult AddLink(long itemId, long sceneId)
        {
            var response = new JsonResponse();

            try
            {
                _breakdownItemSceneService.AddLink(itemId, sceneId);

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
                    message = "Something went wrong while attempting to add link between breakdown item and scene",
                };
            }

            return new JsonResult(response);
        }

        // POST api/breakdownitemscenes/5/removelink
        [HttpPost("{id}/removelink")]
        public JsonResult RemoveLink(long id)
        {
            var response = new JsonResponse();

            try
            {
                _breakdownItemSceneService.RemoveLink(id);

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
                    message = "Something went wrong while attempting to remove link",
                };
            }

            return new JsonResult(response);
        }
    }
}
