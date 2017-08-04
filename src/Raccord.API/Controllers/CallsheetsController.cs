using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Callsheets;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Callsheets;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class CallsheetsController : AbstractApiAuthController
    {
        private readonly ICallsheetService _callsheetService;

        public CallsheetsController(
            ICallsheetService callsheetService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (callsheetService == null)
                throw new ArgumentNullException(nameof(callsheetService));

            _callsheetService = callsheetService;
        }

        // GET: api/callsheets/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<CallsheetSummaryViewModel> GetAll(long id)
        {
            var dtos = _callsheetService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/callsheets/5
        [HttpGet("{id}")]
        public FullCallsheetViewModel Get(long id)
        {
            var dto = _callsheetService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/callsheets/5
        [HttpGet("{id}/summary")]
        public CallsheetSummaryViewModel GetSummary(long id)
        {
            var dto = _callsheetService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/callsheets
        [HttpPost]
        public JsonResult Post([FromBody]CallsheetViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _callsheetService.Add(dto);
                }
                else
                {
                    id = _callsheetService.Update(dto);
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
                    message = "Something went wrong while attempting to update callsheet",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/callsheets/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _callsheetService.Delete(id);

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
                    message = "Something went wrong while attempting to delete callsheet.",
                };
            }

            return new JsonResult(response);
        }
    }
}
