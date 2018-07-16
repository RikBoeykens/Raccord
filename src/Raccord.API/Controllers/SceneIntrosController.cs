using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.SceneProperties;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.SceneProperties;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class SceneIntrosController : AbstractApiAuthController
    {
        private readonly ISceneIntroService _sceneIntroService;

        public SceneIntrosController(
            ISceneIntroService sceneIntroService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (sceneIntroService == null)
                throw new ArgumentNullException(nameof(sceneIntroService));

            _sceneIntroService = sceneIntroService;
        }

        // GET: api/sceneintros/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<SceneIntroSummaryViewModel> GetAll(long id)
        {
            var dtos = _sceneIntroService.GetAllForParent(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/sceneintros/5
        [HttpGet("{id}")]
        public FullSceneIntroViewModel Get(long id)
        {
            var dto = _sceneIntroService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/sceneintros/5
        [HttpGet("{id}/summary")]
        public SceneIntroSummaryViewModel GetSummary(Int64 id)
        {
            var dto = _sceneIntroService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        // POST api/sceneintros
        [HttpPost]
        public JsonResult Post([FromBody]SceneIntroViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _sceneIntroService.Add(dto);
                }
                else
                {
                    id = _sceneIntroService.Update(dto);
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
                    message = "Something went wrong while attempting to update scene intro",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/sceneintros/5
        [HttpDelete("{id}")]
        public JsonResult Delete(Int64 id)
        {
            var response = new JsonResponse();

            try
            {
                _sceneIntroService.Delete(id);

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
                    message = "Something went wrong while attempting to delete scene intro.",
                };
            }

            return new JsonResult(response);
        }

        // POST api/sceneintros/merge/5/1
        [HttpPost("merge/{toId}/{mergeId}")]
        public JsonResult Merge(long toId, long mergeId)
        {
            var response = new JsonResponse();

            try
            {
                _sceneIntroService.Merge(toId, mergeId);

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
                    message = "Something went wrong while attempting to merge scene intro.",
                };
            }

            return new JsonResult(response);
        }
    }
}
