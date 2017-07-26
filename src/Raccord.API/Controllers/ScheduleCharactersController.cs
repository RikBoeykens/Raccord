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
using Raccord.Application.Core.Services.Scheduling.ScheduleCharacters;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;

namespace Raccord.API.Controllers
{
    public class ScheduleCharactersController : RaccordApiAuthController
    {
        private readonly IScheduleCharacterService _scheduleCharacterService;

        public ScheduleCharactersController(IScheduleCharacterService scheduleCharacterService)
        {
            if (scheduleCharacterService == null)
                throw new ArgumentNullException(nameof(scheduleCharacterService));

            _scheduleCharacterService = scheduleCharacterService;
        }

        // GET: api/schedulecharacters/1/characters
        [HttpGet("{id}/characters")]
        public IEnumerable<LinkedCharacterViewModel> GetCharacters(long id)
        {
            var dtos = _scheduleCharacterService.GetCharacters(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/schedulecharacters/1/scenes
        [HttpGet("{id}/schedulescenes")]
        public IEnumerable<LinkedScheduleSceneViewModel> GetScheduleScenes(long id)
        {
            var dtos = _scheduleCharacterService.GetScheduleScenes(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/schedulecharacters/5/1/link
        [HttpPost("{scheduleSceneId}/{characterSceneId}/addlink")]
        public JsonResult AddLink(long scheduleSceneId, long characterSceneId)
        {
            var response = new JsonResponse();

            try
            {
                _scheduleCharacterService.AddLink(scheduleSceneId, characterSceneId);

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
                    message = "Something went wrong while attempting to add link between schedule scene and character scene",
                };
            }

            return new JsonResult(response);
        }

        // POST api/schedulecharacters/5/removelink
        [HttpPost("{id}/removelink")]
        public JsonResult RemoveLink(long id)
        {
            var response = new JsonResponse();

            try
            {
                _scheduleCharacterService.RemoveLink(id);

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
