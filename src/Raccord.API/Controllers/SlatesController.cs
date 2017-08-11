using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Shots.Slates;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Shots.Slates;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class SlatesController : AbstractApiAuthController
    {
        private readonly ISlateService _slateService;

        public SlatesController(
            ISlateService slateService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (slateService == null)
                throw new ArgumentNullException(nameof(slateService));

            _slateService = slateService;
        }

        // GET: api/slates/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<SlateSummaryViewModel> GetAll(long id)
        {
            var dtos = _slateService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/slates/5
        [HttpGet("{id}")]
        public FullSlateViewModel Get(long id)
        {
            var dto = _slateService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/slates/5/summary
        [HttpGet("{id}/summary")]
        public SlateSummaryViewModel GetSummary(Int64 id)
        {
            var dto = _slateService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/slates
        [HttpPost]
        public JsonResult Post([FromBody]SlateViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _slateService.Add(dto);
                }
                else
                {
                    id = _slateService.Update(dto);
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
                    message = "Something went wrong while attempting to update slate",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/slates/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _slateService.Delete(id);

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
                    message = "Something went wrong while attempting to delete slate.",
                };
            }

            return new JsonResult(response);
        }
    }
}
