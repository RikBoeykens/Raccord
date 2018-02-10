using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class BreakdownTypesController : AbstractApiAuthController
    {
        private readonly IBreakdownTypeService _breakdownTypeService;

        public BreakdownTypesController(
            IBreakdownTypeService breakdownTypeService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (breakdownTypeService == null)
                throw new ArgumentNullException(nameof(breakdownTypeService));

            _breakdownTypeService = breakdownTypeService;
        }

        // GET: api/breakdowntypes/1/breakdown
        [HttpGet("{id}/breakdown")]
        public IEnumerable<BreakdownTypeSummaryViewModel> GetAll(long id)
        {
            var dtos = _breakdownTypeService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/breakdowntypes/5
        [HttpGet("{id}")]
        public FullBreakdownTypeViewModel Get(long id)
        {
            var dto = _breakdownTypeService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/breakdowntypes/5
        [HttpGet("{id}/summary")]
        public BreakdownTypeSummaryViewModel GetSummary(long id)
        {
            var dto = _breakdownTypeService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/breakdowntypes
        [HttpPost]
        public JsonResult Post([FromBody]BreakdownTypeViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _breakdownTypeService.Add(dto);
                }
                else
                {
                    id = _breakdownTypeService.Update(dto);
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
                    message = "Something went wrong while attempting to update breakdown type",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/breakdowntypes/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _breakdownTypeService.Delete(id);

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
                    message = "Something went wrong while attempting to delete breakdown type.",
                };
            }

            return new JsonResult(response);
        }
    }
}
