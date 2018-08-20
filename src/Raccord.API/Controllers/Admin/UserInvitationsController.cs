using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Users;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Users;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Raccord.Application.Core.Services.Users.Invitations;
using Raccord.API.ViewModels.Users.Invitations;
using Raccord.Application.Core.Common.Paging;

namespace Raccord.API.Controllers.Admin
{
    public class UserInvitationsController : AbstractAdminController
    {
        private readonly IUserInvitationService _userInvitationService;

        public UserInvitationsController(IUserInvitationService userInvitationService)
        {
            _userInvitationService = userInvitationService;
        }

        // GET: api/admin/users
        [HttpGet]
        public IEnumerable<AdminUserInvitationSummaryViewModel> Get()
        {
            var pagedDtos = _userInvitationService.GetAdminPaged(new PaginationRequestDto{ Full = true });

            return pagedDtos.Data.Select(p => p.Translate());
        }
        // GET api/admin/users/5
        [HttpGet("{id}")]
        public FullUserInvitationViewModel Get(Guid id)
        {
            var dto = _userInvitationService.GetFull(id);

            return dto.Translate();
        }

        // GET api/admin/users/5
        [HttpGet("{id}/summary")]
        public UserInvitationSummaryViewModel GetSummary(Guid id)
        {
            var dto = _userInvitationService.GetSummary(id);

            return dto.Translate();
        }

        // POST api/admin/users/create
        [HttpPost("create")]
        public JsonResult Create([FromBody]UserInvitationViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                var userID  = _userInvitationService.Add(dto);

                response = new JsonResponse
                {
                    ok = true,
                    data = new UserInvitationResultViewModel
                    {
                        ID = userID
                    },
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to add user invitation",
                };
            }

            return new JsonResult(response);
        }

        // POST api/admin/users/update
        [HttpPost("update")]
        public JsonResult Update([FromBody]UserInvitationViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                var userID = _userInvitationService.Update(dto);

                response = new JsonResponse
                {
                    ok = true,
                    data = new UserInvitationResultViewModel
                    {
                        ID = userID
                    },
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to update user invitation",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/admin/users/5
        [HttpDelete("{id}")]
        public JsonResult Delete(Guid id)
        {
            var response = new JsonResponse();

            try
            {
                _userInvitationService.Delete(id);

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
                    message = "Something went wrong while attempting to delete user.",
                };
            }

            return new JsonResult(response);
        }
    }
}
