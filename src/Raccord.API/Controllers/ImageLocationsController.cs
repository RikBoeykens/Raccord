using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Locations;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Core.Services.ImageLocations;
using Raccord.API.ViewModels.Common.Sorting;
using Raccord.API.ViewModels.Images;

namespace Raccord.API.Controllers
{
    [Route("api/[controller]")]
    public class ImageLocationsController : Controller
    {
        private readonly IImageLocationService _imageLocationService;

        public ImageLocationsController(IImageLocationService imageLocationService)
        {
            if (imageLocationService == null)
                throw new ArgumentNullException(nameof(imageLocationService));

            _imageLocationService = imageLocationService;
        }

        // GET: api/imagelocations/1/images
        [HttpGet("{id}/images")]
        public IEnumerable<LinkedImageViewModel> GetAll(long id)
        {
            var dtos = _imageLocationService.GetImages(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/imagelocations/5/1/link
        [HttpPost("{imageId}/{locationId}/addlink")]
        public JsonResult AddLink(long imageId, long locationId)
        {
            var response = new JsonResponse();

            try
            {
                _imageLocationService.AddLink(imageId, locationId);

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
                    message = "Something went wrong while attempting to add link between image and location",
                };
            }

            return new JsonResult(response);
        }

        // POST api/imagelocations/5/removelink
        [HttpPost("{id}/removelink")]
        public JsonResult RemoveLink(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageLocationService.RemoveLink(id);

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
        
        // POST api/imagelocations/5/removeprimary
        [HttpPost("{id}/setprimary")]
        public JsonResult SetAsPrimary(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageLocationService.SetAsPrimary(id);

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
                    message = "Something went wrong while attempting to set image as primary for location",
                };
            }

            return new JsonResult(response);
        }
        
        // POST api/imagelocations/5/removeprimary
        [HttpPost("{id}/removeprimary")]
        public JsonResult RemoveAsPrimary(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageLocationService.RemoveAsPrimary(id);

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
                    message = "Something went wrong while attempting to remove image as primary for location",
                };
            }

            return new JsonResult(response);
        }
    }
}
