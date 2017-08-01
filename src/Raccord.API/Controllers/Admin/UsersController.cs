using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Users;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Users;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Raccord.API.Controllers.Admin
{
    public class UsersController : AbstractAdminController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            if (userService == null)
                throw new ArgumentNullException(nameof(userService));

            _userService = userService;
        }

        // GET: api/admin/users
        [HttpGet]
        public IEnumerable<UserSummaryViewModel> Get()
        {
            var dtos = _userService.GetAll();

            return dtos.Select(p => p.Translate());
        }
        // GET api/admin/users/5
        [HttpGet("{id}")]
        public FullUserViewModel Get(string id)
        {
            var dto = _userService.Get(id);

            return dto.Translate();
        }

        // GET api/admin/users/5
        [HttpGet("{id}/summary")]
        public UserSummaryViewModel GetSummary(string id)
        {
            var dto = _userService.GetSummary(id);

            return dto.Translate();
        }

        // POST api/admin/users/create
        [HttpPost("create")]
        public async Task<JsonResult> Create([FromBody]CreateUserViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                var userID  = await _userService.Add(dto);

                response = new JsonResponse
                {
                    ok = true,
                    data = userID,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to add user",
                };
            }

            return new JsonResult(response);
        }

        // POST api/admin/users/update
        [HttpPost("update")]
        public async Task<JsonResult> Update([FromBody]UserViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                var userID = await _userService.Update(dto);

                response = new JsonResponse
                {
                    ok = true,
                    data = userID,
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to update user",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/admin/users/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(string id)
        {
            var response = new JsonResponse();

            try
            {
                await _userService.Delete(id);

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
