using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Callsheets.CharacterCalls;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Callsheets.CharacterCalls;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class CharacterCallsController : AbstractApiAuthController
    {
        private readonly ICharacterCallService _characterCallService;

        public CharacterCallsController(
            ICharacterCallService characterCallService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (characterCallService == null)
                throw new ArgumentNullException(nameof(characterCallService));

            _characterCallService = characterCallService;
        }

        // POST api/callsheetcharacters
        [HttpPost]
        public JsonResult Post([FromBody]CharacterCallViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();
                _characterCallService.Update(dto);

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
                    message = "Something went wrong while attempting to update character calls.",
                };
            }

            return new JsonResult(response);
        }
    }
}
