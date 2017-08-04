using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class BreakdownItemsController : AbstractApiAuthController
    {
        private readonly IBreakdownItemService _breakdownItemService;

        public BreakdownItemsController(
            IBreakdownItemService breakdownItemService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (breakdownItemService == null)
                throw new ArgumentNullException(nameof(breakdownItemService));

            _breakdownItemService = breakdownItemService;
        }

        // GET: api/breakdownitems/1/type
        [HttpGet("{id}/type")]
        public IEnumerable<BreakdownItemSummaryViewModel> GetAll(long id)
        {
            var dtos = _breakdownItemService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/breakdownitem/5
        [HttpGet("{id}")]
        public FullBreakdownItemViewModel Get(long id)
        {
            var dto = _breakdownItemService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/breakdownitems/5
        [HttpGet("{id}/summary")]
        public BreakdownItemSummaryViewModel GetSummary(long id)
        {
            var dto = _breakdownItemService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/breakdownitems
        [HttpPost]
        public JsonResult Post([FromBody]BreakdownItemViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _breakdownItemService.Add(dto);
                }
                else
                {
                    id = _breakdownItemService.Update(dto);
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
                    message = "Something went wrong while attempting to update breakdown item",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/breakdownitems/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _breakdownItemService.Delete(id);

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
                    message = "Something went wrong while attempting to delete breakdown item.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/breakdownitems/merge/5/1
        [HttpPost("merge/{toId}/{mergeId}")]
        public JsonResult Merge(long toId, long mergeId)
        {
            var response = new JsonResponse();

            try
            {
                _breakdownItemService.Merge(toId, mergeId);

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
                    message = "Something went wrong while attempting to merge breakdown items.",
                };
            }

            return new JsonResult(response);
        }

        // GET: api/breakdownitems/search/text/type/4
        [HttpGet("search/{searchText}/type/{typeID}")]
        public IEnumerable<BreakdownItemViewModel> SearchByType(string searchText, long typeID)
        {
            var dtos = _breakdownItemService.SearchByType(searchText, typeID);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
    }
}
