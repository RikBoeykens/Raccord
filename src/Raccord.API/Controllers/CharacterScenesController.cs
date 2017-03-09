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

namespace Raccord.API.Controllers
{
    [Route("api/[controller]")]
    public class CharacterScenesController : Controller
    {
        private readonly ICharacterSceneService _characterSceneService;

        public CharacterScenesController(ICharacterSceneService characterSceneService)
        {
            if (characterSceneService == null)
                throw new ArgumentNullException(nameof(characterSceneService));

            _characterSceneService = characterSceneService;
        }

        // GET: api/characterscenes/1/characters
        [HttpGet("{id}/characters")]
        public IEnumerable<LinkedCharacterViewModel> GetCharacters(long id)
        {
            var dtos = _characterSceneService.GetCharacters(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/characterscenes/1/scenes
        [HttpGet("{id}/scenes")]
        public IEnumerable<LinkedSceneViewModel> GetScenes(long id)
        {
            var dtos = _characterSceneService.GetScenes(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/characterscenes/5/1/link
        [HttpPost("{characterId}/{sceneId}/addlink")]
        public JsonResult AddLink(long characterId, long sceneId)
        {
            var response = new JsonResponse();

            try
            {
                _characterSceneService.AddLink(characterId, sceneId);

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
                    message = "Something went wrong while attempting to add link between character and scene",
                };
            }

            return new JsonResult(response);
        }

        // POST api/characterscenes/5/removelink
        [HttpPost("{id}/removelink")]
        public JsonResult RemoveLink(long id)
        {
            var response = new JsonResponse();

            try
            {
                _characterSceneService.RemoveLink(id);

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
