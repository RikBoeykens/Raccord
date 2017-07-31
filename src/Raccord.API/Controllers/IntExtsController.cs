using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.SceneProperties;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.SceneProperties;

namespace Raccord.API.Controllers
{
    public class IntExtsController : AbstractApiAuthController
    {
        private readonly IIntExtService _intExtService;

        public IntExtsController(IIntExtService intExtService)
        {
            if (intExtService == null)
                throw new ArgumentNullException(nameof(intExtService));

            _intExtService = intExtService;
        }

        // GET: api/intexts/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<IntExtSummaryViewModel> GetAll(long id)
        {
            var dtos = _intExtService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/intexts/5
        [HttpGet("{id}")]
        public FullIntExtViewModel Get(long id)
        {
            var dto = _intExtService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/intexts/5
        [HttpGet("{id}/summary")]
        public IntExtSummaryViewModel GetSummary(Int64 id)
        {
            var dto = _intExtService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/intexts
        [HttpPost]
        public JsonResult Post([FromBody]IntExtViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _intExtService.Add(dto);
                }
                else
                {
                    id = _intExtService.Update(dto);
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
                    message = "Something went wrong while attempting to update int/ext",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/intexts/5
        [HttpDelete("{id}")]
        public JsonResult Delete(Int64 id)
        {
            var response = new JsonResponse();

            try
            {
                _intExtService.Delete(id);

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
                    message = "Something went wrong while attempting to delete int/ext.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/intexts/merge/5/1
        [HttpPost("merge/{toId}/{mergeId}")]
        public JsonResult Merge(long toId, long mergeId)
        {
            var response = new JsonResponse();

            try
            {
                _intExtService.Merge(toId, mergeId);

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
                    message = "Something went wrong while attempting to merge int/ext.",
                };
            }

            return new JsonResult(response);
        }
    }
}
