using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Shots.Takes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Shots.Takes;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class TakesController : AbstractApiAuthController
    {
        private readonly ITakeService _takeService;

        public TakesController(
            ITakeService takeService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (takeService == null)
                throw new ArgumentNullException(nameof(takeService));

            _takeService = takeService;
        }

        // GET: api/takes/1/slate
        [HttpGet("{id}/slate")]
        public IEnumerable<TakeSummaryViewModel> GetAll(long id)
        {
            var dtos = _takeService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/takes/5
        [HttpGet("{id}")]
        public FullTakeViewModel Get(long id)
        {
            var dto = _takeService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/takes/5/summary
        [HttpGet("{id}/summary")]
        public TakeSummaryViewModel GetSummary(Int64 id)
        {
            var dto = _takeService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/takes
        [HttpPost]
        public JsonResult Post([FromBody]TakeViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _takeService.Add(dto);
                }
                else
                {
                    id = _takeService.Update(dto);
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
                    message = "Something went wrong while attempting to update take",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/takes/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _takeService.Delete(id);

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
                    message = "Something went wrong while attempting to delete take.",
                };
            }

            return new JsonResult(response);
        }
    }
}
