using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.ImageBreakdownItems;
using Raccord.API.ViewModels.Common.Sorting;
using Raccord.API.ViewModels.Images;

namespace Raccord.API.Controllers
{
    public class ImageBreakdownItemsController : AbstractApiAuthController
    {
        private readonly IImageBreakdownItemService _imageBreakdownItemService;

        public ImageBreakdownItemsController(IImageBreakdownItemService imageBreakdownItemService)
        {
            if (imageBreakdownItemService == null)
                throw new ArgumentNullException(nameof(imageBreakdownItemService));

            _imageBreakdownItemService = imageBreakdownItemService;
        }

        // GET: api/imagebreakdownitems/1/images
        [HttpGet("{id}/images")]
        public IEnumerable<LinkedImageViewModel> GetAll(long id)
        {
            var dtos = _imageBreakdownItemService.GetImages(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }

        // POST api/imagebreakdownitems/5/1/link
        [HttpPost("{imageId}/{breakdownItemId}/addlink")]
        public JsonResult AddLink(long imageId, long breakdownItemId)
        {
            var response = new JsonResponse();

            try
            {
                _imageBreakdownItemService.AddLink(imageId, breakdownItemId);

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
                    message = "Something went wrong while attempting to add link between image and breakdown item",
                };
            }

            return new JsonResult(response);
        }

        // POST api/imagebreakdownitems/5/removelink
        [HttpPost("{id}/removelink")]
        public JsonResult RemoveLink(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageBreakdownItemService.RemoveLink(id);

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
        
        // POST api/imagebreakdownitems/5/removeprimary
        [HttpPost("{id}/setprimary")]
        public JsonResult SetAsPrimary(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageBreakdownItemService.SetAsPrimary(id);

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
                    message = "Something went wrong while attempting to set image as primary for breakdown item",
                };
            }

            return new JsonResult(response);
        }
        
        // POST api/imagebreakdownitems/5/removeprimary
        [HttpPost("{id}/removeprimary")]
        public JsonResult RemoveAsPrimary(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageBreakdownItemService.RemoveAsPrimary(id);

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
                    message = "Something went wrong while attempting to remove image as primary for breakdown item",
                };
            }

            return new JsonResult(response);
        }
    }
}
