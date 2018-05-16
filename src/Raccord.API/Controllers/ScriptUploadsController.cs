using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.Application.Core.Services.ScriptUploads;
using Microsoft.AspNetCore.Http;
using Raccord.API.ViewModels.ScriptUploads;
using Microsoft.Net.Http.Headers;

namespace Raccord.API.Controllers
{
    public class ScriptUploadsController : AbstractApiAuthController
    {
        private readonly IScriptUploadService _scriptUploadService;

        public ScriptUploadsController(
            IScriptUploadService scriptUploadService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            _scriptUploadService = scriptUploadService;
        }

        // GET api/scriptuploads/5
        [HttpGet("{id}")]
        public FullScriptUploadViewModel Get(long id)
        {
            var dto = _scriptUploadService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        [HttpPost("{projectID}/upload")]
        public JsonResult Upload(ICollection<IFormFile> files, long projectID)
        {
            var response = new JsonResponse();

            try
            {

                var file = files.First();

                var uploadScriptID = _scriptUploadService.UploadScript(new ScriptUploadRequestDto
                {
                    FileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"'),
                    FileContent = file.OpenReadStream(),
                    ProjectID = projectID
                });

                response = new JsonResponse
                {
                    ok = true,
                    data = uploadScriptID
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to upload script.",
                };
            }

            return new JsonResult(response);
        }
    }
}
