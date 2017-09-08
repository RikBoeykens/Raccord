using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.ShootingDays.Scenes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.ShootingDays.Scenes;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class ShootingDayScenesController : AbstractApiAuthController
    {
        private readonly IShootingDaySceneService _shootingDaySceneService;

        public ShootingDayScenesController(
            IShootingDaySceneService shootingDaySceneService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (shootingDaySceneService == null)
                throw new ArgumentNullException(nameof(shootingDaySceneService));

            _shootingDaySceneService = shootingDaySceneService;
        }

        // GET: api/shootingdaycenes/1/day
        [HttpGet("{id}/day")]
        public IEnumerable<ShootingDaySceneSceneViewModel> GetScenes(long id)
        {
            var dtos = _shootingDaySceneService.GetScenes(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/shootingdaycenes/1/scene
        [HttpGet("{id}/scene")]
        public IEnumerable<ShootingDaySceneDayViewModel> GetDays(long id)
        {
            var dtos = _shootingDaySceneService.GetDays(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/shootingdaycenes
        [HttpPost]
        public JsonResult Post([FromBody]ShootingDaySceneViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id;

                if (dto.ID == default(long))
                {
                    id = _shootingDaySceneService.Add(dto);
                }
                else
                {
                    id = _shootingDaySceneService.Update(dto);
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
                    message = "Something went wrong while attempting to update shooting day scene",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/shootingdaycenes/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _shootingDaySceneService.Delete(id);

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
                    message = "Something went wrong while attempting to delete shooting day scene.",
                };
            }

            return new JsonResult(response);
        }
    }
}
