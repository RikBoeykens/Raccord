using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Crew;
using Raccord.Application.Core.Services.Crew;

namespace Raccord.API.Controllers.Admin
{
    public class CrewController : AbstractAdminController
    {
        private readonly ICrewService _crewService;

        public CrewController(ICrewService crewService)
        {
            if (crewService == null)
                throw new ArgumentNullException(nameof(crewService));

            _crewService = crewService;
        }

        // GET: api/crew/1/projects
        [HttpGet("{userID}/projects")]
        public IEnumerable<CrewUserProjectViewModel> GetProjects(string userID)
        {
            var dtos = _crewService.GetProjects(userID);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/crew/1/users
        [HttpGet("{projectID}/users")]
        public IEnumerable<CrewUserUserViewModel> GetUsers(long projectID)
        {
            var dtos = _crewService.GetUsers(projectID);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET api/crew/5
        [HttpGet("{id}")]
        public FullCrewUserViewModel Get(long id)
        {
            var dto = _crewService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/crew
        [HttpPost]
        public JsonResult Post([FromBody]CrewUserViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _crewService.Add(dto);
                }
                else
                {
                    id = _crewService.Update(dto);
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
                    message = "Something went wrong while attempting to update crew",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/crew/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _crewService.Delete(id);

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
                    message = "Something went wrong while attempting to delete crew.",
                };
            }

            return new JsonResult(response);
        }
    }
}
