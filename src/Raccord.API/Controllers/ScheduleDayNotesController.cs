using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Scheduling.ScheduleDayNotes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes;

namespace Raccord.API.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleDayNotesController : Controller
    {
        private readonly IScheduleDayNoteService _scheduleDayNoteService;

        public ScheduleDayNotesController(IScheduleDayNoteService scheduleDayNoteService)
        {
            if (scheduleDayNoteService == null)
                throw new ArgumentNullException(nameof(scheduleDayNoteService));

            _scheduleDayNoteService = scheduleDayNoteService;
        }

        // GET: api/scheduledaynotes/1/day
        [HttpGet("{id}/day")]
        public IEnumerable<ScheduleDayNoteSummaryViewModel> GetAll(long id)
        {
            var dtos = _scheduleDayNoteService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/scheduledaynotes/5
        [HttpGet("{id}")]
        public FullScheduleDayNoteViewModel Get(long id)
        {
            var dto = _scheduleDayNoteService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/scheduledaynotes/5
        [HttpGet("{id}/summary")]
        public ScheduleDayNoteSummaryViewModel GetSummary(long id)
        {
            var dto = _scheduleDayNoteService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/scheduledaynotes
        [HttpPost]
        public JsonResult Post([FromBody]ScheduleDayNoteViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _scheduleDayNoteService.Add(dto);
                }
                else
                {
                    id = _scheduleDayNoteService.Update(dto);
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
                    message = "Something went wrong while attempting to update schedule day note",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/scheduledaynotes/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _scheduleDayNoteService.Delete(id);

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
                    message = "Something went wrong while attempting to delete schedule day notes.",
                };
            }

            return new JsonResult(response);
        }
    }
}
