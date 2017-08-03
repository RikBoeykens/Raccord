using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.CharacterScenes;
using Raccord.API.ViewModels.Common.Sorting;
using Raccord.API.ViewModels.Characters;
using Raccord.Application.Core.Services.Callsheets.CallsheetSceneCharacters;
using Raccord.API.ViewModels.Callsheets.CallsheetScenes;

namespace Raccord.API.Controllers
{
    public class CallsheetSceneCharactersController : AbstractApiAuthController
    {
        private readonly ICallsheetSceneCharacterService _callsheetSceneCharacterService;

        public CallsheetSceneCharactersController(ICallsheetSceneCharacterService callsheetSceneCharacterService)
        {
            if (callsheetSceneCharacterService == null)
                throw new ArgumentNullException(nameof(callsheetSceneCharacterService));

            _callsheetSceneCharacterService = callsheetSceneCharacterService;
        }

        // GET: api/callsheetscenecharacters/1/characters
        [HttpGet("{id}/characters")]
        public IEnumerable<LinkedCharacterViewModel> GetCharacters(long id)
        {
            var dtos = _callsheetSceneCharacterService.GetCharacters(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/callsheetscenecharacters/1/scenes
        [HttpGet("{id}/callsheetscenes")]
        public IEnumerable<LinkedCallsheetSceneViewModel> GetCallsheetScenes(long id)
        {
            var dtos = _callsheetSceneCharacterService.GetCallsheetScenes(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/callsheetscenecharacters/5/1/link
        [HttpPost("{callsheetSceneId}/{characterSceneId}/addlink")]
        public JsonResult AddLink(long callsheetSceneId, long characterSceneId)
        {
            var response = new JsonResponse();

            try
            {
                var id = _callsheetSceneCharacterService.AddLink(callsheetSceneId, characterSceneId);

                response = new JsonResponse
                {
                    ok = true,
                    data = id
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to add link between callsheet scene and character scene",
                };
            }

            return new JsonResult(response);
        }

        // POST api/callsheetscenecharacters/5/removelink
        [HttpPost("{id}/removelink")]
        public JsonResult RemoveLink(long id)
        {
            var response = new JsonResponse();

            try
            {
                _callsheetSceneCharacterService.RemoveLink(id);

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
                    message = "Something went wrong while attempting to remove link",
                };
            }

            return new JsonResult(response);
        }
    }
}
