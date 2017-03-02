using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Core;
using Raccord.Application.Core.Services.Images;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Raccord.Core.Utilities;
using Raccord.API.ViewModels.Common.SelectedEntity;

namespace Raccord.API.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            if (imageService == null)
                throw new ArgumentNullException(nameof(imageService));

            _imageService = imageService;
        }

        // GET: api/images/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<ImageSummaryViewModel> GetAll(long id)
        {
            var dtos = _imageService.GetAllForProject(id);

            var vms = dtos.Select(p => p.Translate());

            return vms;
        }
        // GET api/images/5
        [HttpGet("{id}")]
        public FullImageViewModel Get(long id)
        {
            var dto = _imageService.Get(id);

            var vm = dto.Translate();

            return vm;
        }

        // GET api/images/5
        [HttpGet("{id}/summary")]
        public ImageSummaryViewModel GetSummary(long id)
        {
            var dto = _imageService.GetSummary(id);

            var vm = dto.Translate();

            return vm;
        }

        [HttpPost("{projectID}/upload")]
        public JsonResult Add(ICollection<IFormFile> files, long projectID)
        {
            var response = new JsonResponse();

            try
            {

                var images = new List<NewImageContentDto>();

                foreach(var file in files)
                {
                    images.Add(new NewImageContentDto
                    {
                        FileContent = file.OpenReadStream(),
                        FileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"'),
                    });
                }

                var imageContentDto = new AddImageContentDto
                {
                    Images = images,
                    ProjectID = projectID,
                };

                _imageService.Add(imageContentDto);

                response = new JsonResponse
                {
                    ok = true,
                };
            }
            catch (Exception ex)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while attempting to upload image.",
                };
            }

            return new JsonResult(response);
        }
        
        // POST api/images
        [HttpPost]
        public JsonResult Post([FromBody]ImageViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                long id = _imageService.Update(dto);

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
                    message = "Something went wrong while attempting to update image",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/images/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageService.Delete(id);

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
                    message = "Something went wrong while attempting to delete image.",
                };
            }

            return new JsonResult(response);
        }

        [HttpGet("{id}/download/{fileName}")]
        public ActionResult Download(long id, string fileName)
        {
            try
            {
                var file = _imageService.GetContent(id);

                if (file.FileContent == null)
                    return new EmptyResult();

                string mimeType = MimeTypes.GetMimeType(file.FileName);

                return File(file.FileContent, mimeType, file.FileName);

            }
            catch
            {
                return new EmptyResult();

            }
        }

        
        // POST api/images/link
        [HttpPost("link")]
        public JsonResult Link([FromBody]LinkImageViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                _imageService.AddImageLink(dto);

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
                    message = "Something went wrong while attempting to add image link",
                };
            }

            return new JsonResult(response);
        }
        
        // POST api/images/removelink
        [HttpPost("removelink")]
        public JsonResult RemoveLink([FromBody]LinkImageViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate();

                _imageService.RemoveImageLink(dto);

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
                    message = "Something went wrong while attempting to remove image link",
                };
            }

            return new JsonResult(response);
        }
        
        // POST api/images/5/setprimary
        [HttpPost("{id}/setprimary")]
        public JsonResult SetAsPrimary(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageService.SetAsPrimary(id);

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
                    message = "Something went wrong while attempting to set image as primary for project",
                };
            }

            return new JsonResult(response);
        }
        
        // POST api/images/5/removeprimary
        [HttpPost("{id}/removeprimary")]
        public JsonResult RemoveAsPrimary(long id)
        {
            var response = new JsonResponse();

            try
            {
                _imageService.RemoveAsPrimary(id);

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
                    message = "Something went wrong while attempting to remove image as primary for project",
                };
            }

            return new JsonResult(response);
        }
    }
}
