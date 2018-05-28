using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Shots.Takes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Shots.Takes;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.Application.Core.Services.Users.Invitations;
using Raccord.API.ViewModels.Users.Invitations;
using System.Threading.Tasks;

namespace Raccord.API.Controllers
{
    public class InvitationsController : AbstractApiController
    {
        private readonly IUserInvitationService _userInvitationService;

        public InvitationsController(
            IUserInvitationService userInvitationService
            )
        {
            _userInvitationService = userInvitationService;
        }

        // GET: api/takes/1/slate
        [HttpGet("{id}")]
        public UserInvitationSummaryViewModel Get(Guid id)
        {
            var dto = _userInvitationService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/takes
        [HttpPost]
        public async Task<JsonResult> Post([FromBody]CreateUserFromInvitationViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                var id = await _userInvitationService.CreateUserFromInvitation(dto);

                response = new JsonResponse
                {
                    ok = true,
                    data = new CreateUserResultViewModel
                    {
                        ID = id
                    },
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to accept invitation",
                };
            }

            return new JsonResult(response);
        }
    }
}
