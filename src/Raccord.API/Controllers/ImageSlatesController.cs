using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Core.Services.ImageSlates;
using Raccord.API.ViewModels.Common.Sorting;
using Raccord.API.ViewModels.Images;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class ImageSlatesController : AbstractApiAuthController
    {
        private readonly IImageSlateService _imageSlateService;

        public ImageSlatesController(
            IImageSlateService imageSlateService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (imageSlateService == null)
                throw new ArgumentNullException(nameof(imageSlateService));

            _imageSlateService = imageSlateService;
        }

        // GET: api/imageslates/1/images
        [HttpGet("{id}/images")]
        public IEnumerable<LinkedImageViewModel> GetAll(long id)
        {
            var dtos = _imageSlateService.GetImages(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/imageslates/5/1/link
        [HttpPost("{imageId}/{slateId}/addlink")]
        public JsonResult AddLink(long imageId, long slateId)
        {
            var response = new JsonResponse();

            try
            {
                _imageSlateService.AddLink(imageId, slateId);

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
                    message = "Something went wrong while attempting to add link between image and slate",
                };
            }

            return new JsonResult(response);
        }

        // POST api/imageslates/5/removelink
        [HttpPost("{id}/removelink")]
        public JsonResult RemoveLink(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageSlateService.RemoveLink(id);

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
        
        // POST api/imageslates/5/removeprimary
        [HttpPost("{id}/setprimary")]
        public JsonResult SetAsPrimary(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageSlateService.SetAsPrimary(id);

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
                    message = "Something went wrong while attempting to set image as primary for slate",
                };
            }

            return new JsonResult(response);
        }
        
        // POST api/imageslates/5/removeprimary
        [HttpPost("{id}/removeprimary")]
        public JsonResult RemoveAsPrimary(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageSlateService.RemoveAsPrimary(id);

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
                    message = "Something went wrong while attempting to remove image as primary for slate",
                };
            }

            return new JsonResult(response);
        }
    }
}
