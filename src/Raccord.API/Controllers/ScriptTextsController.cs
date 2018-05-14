using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.Application.Core.Services.ScriptTexts;
using Raccord.API.ViewModels.ScriptTexts;

namespace Raccord.API.Controllers
{
    public class ScriptTextsController : AbstractApiAuthController
    {
        private readonly IScriptTextService _scriptTextService;

        public ScriptTextsController(
            IScriptTextService scriptTextService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            _scriptTextService = scriptTextService;
        }

        // GET: api/scripttexts/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<SceneTextViewModel> GetAll(long id)
        {
            var dtos = _scriptTextService.GetForProject(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/scripttexts/1/callsheet
        [HttpGet("{id}/callsheet")]
        public IEnumerable<SceneTextViewModel> GetAllForCallsheet(long id)
        {
            var dtos = _scriptTextService.GetForCallsheet(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET: api/scripttexts/1/callsheet
        [HttpGet("{projectId}/user")]
        public IEnumerable<SceneTextViewModel> GetAllForUser(long projectId)
        {
            var dtos = _scriptTextService.GetForUser(projectId, GetUserId());

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // GET api/scripttexts/5
        [HttpGet("{id}")]
        public SceneTextViewModel Get(long id)
        {
            var dto = _scriptTextService.GetForScene(id);

            var vm = dto.Translate();

            return vm;
        }
    }
}
