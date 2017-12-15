using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.Application.Core.Services.ScriptUpload;
using Microsoft.AspNetCore.Http;

namespace Raccord.API.Controllers
{
    public class ScriptUploadController : AbstractApiController
    {
        private readonly IScriptUploadService _scriptUploadService;

        public ScriptUploadController(
            IScriptUploadService scriptUploadService
            //UserManager<ApplicationUser> userManager
            ): base(/*userManager*/)
        {
            _scriptUploadService = scriptUploadService;
        }

        [HttpPost("{projectID}")]
        public JsonResult Upload(ICollection<IFormFile> files, long projectID)
        {
            var response = new JsonResponse();

            try
            {

                var file = files.First().OpenReadStream();

                var uploadResponse = _scriptUploadService.UploadScript(new ScriptUploadRequestDto
                {
                    FileContent = file,
                    ProjectID = projectID
                });

                response = new JsonResponse
                {
                    ok = true,
                    data = uploadResponse
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
