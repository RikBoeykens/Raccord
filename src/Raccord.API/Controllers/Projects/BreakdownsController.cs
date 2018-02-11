using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Breakdowns;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Breakdowns;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.API.Filters;
using Raccord.Core.Enums;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class BreakdownsController : AbstractProjectsController
    {
        private readonly IBreakdownService _breakdownService;

        public BreakdownsController(
            IBreakdownService breakdownService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (breakdownService == null)
                throw new ArgumentNullException(nameof(breakdownService));

            _breakdownService = breakdownService;
        }

        // GET: api/breakdowns/1/project
        [HttpGet("project")]
        public IEnumerable<BreakdownSummaryViewModel> GetAll(long authProjectId)
        {
            var dtos = _breakdownService.GetAllForParent(authProjectId, GetUserId());

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/breakdowns/5
        [HttpGet("{id}")]
        public FullBreakdownViewModel Get(long id)
        {
            var dto = _breakdownService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/breakdowns/5
        [HttpGet("{id}/summary")]
        public BreakdownSummaryViewModel GetSummary(long id)
        {
            var dto = _breakdownService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/breakdowns
        [HttpPost]
        public JsonResult Post([FromBody]BreakdownViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate(GetUserId());

                long id;

                if (dto.ID == default(long))
                {
                    id = _breakdownService.Add(dto);
                }
                else
                {
                    id = _breakdownService.Update(dto);
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
                    message = "Something went wrong while attempting to update breakdown",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/breakdowns/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _breakdownService.Delete(id);

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
                    message = "Something went wrong while attempting to delete schedule days.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/breakdowns/5/select
        [HttpPost("{breakdownId}/select")]
        public JsonResult Publish(long authProjectId, long breakdownId)
        {
            var response = new JsonResponse();

            try
            {
                _breakdownService.SelectBreakdown(authProjectId, GetUserId(), breakdownId);

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
                    message = "Something went wrong while attempting to select breakdown.",
                };
            }

            return new JsonResult(response);
        }
    }
}
