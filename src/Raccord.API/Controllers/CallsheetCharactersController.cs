using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Callsheets.Characters;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Callsheets.Characters;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class CallsheetCharactersController : AbstractApiAuthController
    {
        private readonly ICallsheetCharacterService _callsheetCharacterService;

        public CallsheetCharactersController(
            ICallsheetCharacterService callsheetCharacterService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (callsheetCharacterService == null)
                throw new ArgumentNullException(nameof(callsheetCharacterService));

            _callsheetCharacterService = callsheetCharacterService;
        }

        [HttpGet("{callsheetId}/characters")]
        public IEnumerable<CallsheetCharacterCharacterViewModel> GetCharacters(long callsheetId)
        {
            var dtos = _callsheetCharacterService.GetCharacters(callsheetId);

            return dtos.Select(d=> d.Translate());
        }

        // POST api/callsheetcharacters/7/5/setcharacters
        [HttpPost("{projectId}/{callsheetId}/setcharacters")]
        public JsonResult SetCharacters(long projectId, long callsheetId)
        {
            var response = new JsonResponse();

            try
            {
                _callsheetCharacterService.SetCharacters(callsheetId, projectId);

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
                    message = "Something went wrong while attempting to set characters.",
                };
            }

            return new JsonResult(response);
        }
    }
}
