using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Characters;
using Raccord.API.ViewModels.Common.Sorting;
using Raccord.API.ViewModels.Images;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class CharactersController : AbstractApiAuthController
    {
        private readonly ICharacterService _characterService;

        public CharactersController(
            ICharacterService characterService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (characterService == null)
                throw new ArgumentNullException(nameof(characterService));

            _characterService = characterService;
        }

        // GET: api/characters/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<CharacterSummaryViewModel> GetAll(long id)
        {
            var dtos = _characterService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET: api/characters/1/castmember
        [HttpGet("{castMemberId}/castmember")]
        public IEnumerable<CharacterSummaryViewModel> GetAllForCastMember(long castMemberId)
        {
            var dtos = _characterService.GetAllForCastMember(castMemberId);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/characters/5
        [HttpGet("{id}")]
        public FullCharacterViewModel Get(long id)
        {
            var dto = _characterService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/characters/5/summary
        [HttpGet("{id}/summary")]
        public CharacterSummaryViewModel GetSummary(Int64 id)
        {
            var dto = _characterService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/characters
        [HttpPost]
        public JsonResult Post([FromBody]CharacterViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _characterService.Add(dto);
                }
                else
                {
                    id = _characterService.Update(dto);
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
                    message = "Something went wrong while attempting to update character",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/characters/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _characterService.Delete(id);

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
                    message = "Something went wrong while attempting to delete character.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/characters/merge/5/1
        [HttpPost("merge/{toId}/{mergeId}")]
        public JsonResult Merge(long toId, long mergeId)
        {
            var response = new JsonResponse();

            try
            {
                _characterService.Merge(toId, mergeId);

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
                    message = "Something went wrong while attempting to merge characters.",
                };
            }

            return new JsonResult(response);
        }
    }
}
