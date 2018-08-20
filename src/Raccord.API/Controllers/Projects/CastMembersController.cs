using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Cast;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Cast;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.API.Filters;
using Raccord.Core.Enums;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class CastMembersController : AbstractProjectsController
    {
        private readonly ICastMemberService _castMemberService;

        public CastMembersController(
            ICastMemberService castMemberService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (castMemberService == null)
                throw new ArgumentNullException(nameof(castMemberService));

            _castMemberService = castMemberService;
        }

        // GET: api/castmembers/1/project
        [HttpGet("project")]
        public IEnumerable<CastMemberSummaryViewModel> GetAll(long authProjectId)
        {
            var dtos = _castMemberService.GetAllForParent(authProjectId);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/castmembers/5
        [HttpGet("{id}")]
        public FullCastMemberViewModel Get(long id)
        {
            var dto = _castMemberService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/castmembers/5/summary
        [HttpGet("{id}/summary")]
        public CastMemberSummaryViewModel GetSummary(Int64 id)
        {
            var dto = _castMemberService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/castmembers
        [HttpPost]
        public JsonResult Post([FromBody]CastMemberViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _castMemberService.Add(dto);
                }
                else
                {
                    id = _castMemberService.Update(dto);
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
                    message = "Something went wrong while attempting to update cast member",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/castmembers/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _castMemberService.Delete(id);

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
                    message = "Something went wrong while attempting to delete cast member.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/castmembers/5/1/addlink
        [HttpPost("{castMemberId}/{characterId}/addlink")]
        public JsonResult AddLink(long castMemberId, long characterId)
        {
            var response = new JsonResponse();

            try
            {
                _castMemberService.AddLink(castMemberID: castMemberId, characterID: characterId);

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
                    message = "Something went wrong while attempting to add link between cast member and character",
                };
            }

            return new JsonResult(response);
        }

        // POST api/castmembers/5/1/removelink
        [HttpPost("{castMemberId}/{characterId}/removelink")]
        public JsonResult RemoveLink(long castMemberId, long characterId)
        {
            var response = new JsonResponse();

            try
            {
                _castMemberService.RemoveLink(castMemberID: castMemberId, characterID: characterId);

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
                    message = "Something went wrong while attempting to remove link between cast member and character",
                };
            }

            return new JsonResult(response);
        }
    }
}
