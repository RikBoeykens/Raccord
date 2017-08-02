using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Core.Services.ImageScenes;
using Raccord.API.ViewModels.Common.Sorting;
using Raccord.API.ViewModels.Images;

namespace Raccord.API.Controllers
{
    public class ImageScenesController : AbstractApiAuthController
    {
        private readonly IImageSceneService _imageSceneService;

        public ImageScenesController(IImageSceneService imageSceneService)
        {
            if (imageSceneService == null)
                throw new ArgumentNullException(nameof(imageSceneService));

            _imageSceneService = imageSceneService;
        }

        // GET: api/imagescenes/1/images
        [HttpGet("{id}/images")]
        public IEnumerable<LinkedImageViewModel> GetAll(long id)
        {
            var dtos = _imageSceneService.GetImages(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/imagescenes/5/1/link
        [HttpPost("{imageId}/{sceneId}/addlink")]
        public JsonResult AddLink(long imageId, long sceneId)
        {
            var response = new JsonResponse();

            try
            {
                _imageSceneService.AddLink(imageId, sceneId);

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
                    message = "Something went wrong while attempting to add link between image and scene",
                };
            }

            return new JsonResult(response);
        }

        // POST api/imagescenes/5/removelink
        [HttpPost("{id}/removelink")]
        public JsonResult RemoveLink(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageSceneService.RemoveLink(id);

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
        
        // POST api/imagescenes/5/removeprimary
        [HttpPost("{id}/setprimary")]
        public JsonResult SetAsPrimary(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageSceneService.SetAsPrimary(id);

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
                    message = "Something went wrong while attempting to set image as primary for scene",
                };
            }

            return new JsonResult(response);
        }
        
        // POST api/imagescenes/5/removeprimary
        [HttpPost("{id}/removeprimary")]
        public JsonResult RemoveAsPrimary(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageSceneService.RemoveAsPrimary(id);

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
                    message = "Something went wrong while attempting to remove image as primary for scene",
                };
            }

            return new JsonResult(response);
        }
    }
}
