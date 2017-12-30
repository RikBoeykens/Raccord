using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Raccord.API.ViewModels.Common.Images;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Profile;
using Raccord.Application.Core.Services.Profile;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
  public class UserProfileController : AbstractApiAuthController
  {
    private readonly IUserProfileService _userProfileService;

    public UserProfileController(
        IUserProfileService userProfileService,
        UserManager<ApplicationUser> userManager
        ):base(userManager)
    {
        _userProfileService = userProfileService;
    }

    // GET: api/userprofile
    [HttpGet]
    public UserProfileViewModel Get()
    {
        var dto = _userProfileService.GetProfile(GetUserId());

        return dto.Translate();
    }



    // POST api/userprofile
    [HttpPost]
    public async Task<JsonResult> Post([FromBody]UserProfileViewModel vm)
    {
        var response = new JsonResponse();

        try
        {
            var dto = vm.Translate();

            var updatedDto = await _userProfileService.UpdateProfile(dto, GetUserId());

            response = new JsonResponse
            {
                ok = true,
                data = updatedDto,
            };
        }
        catch (Exception)
        {
            response = new JsonResponse
            {
                ok = false,
                message = "Something went wrong while attempting to update profile",
            };
        }

        return new JsonResult(response);
    }

    // GET api/userprofile/image/abc-user-id/base64
    [HttpGet("image/{userId}/base64")]
    public Base64ImageViewModel GetAsBase64([FromRoute]string userId)
    {   
        try
        {
            var file = _userProfileService.GetProfileImage(userId);

            if (file.FileContent == null)
            {
                return new Base64ImageViewModel
                {
                    HasContent = false
                };
            }

            return new Base64ImageViewModel
            {
                FileName = file.FileName,
                Content = Convert.ToBase64String(file.FileContent),
                HasContent = true
            };
        }
        catch
        {
            return new Base64ImageViewModel
            {
                HasContent = false
            };
        }
    }

    // POST /api/userprofile/image
    [HttpPost("image")]
    public JsonResult Add(ICollection<IFormFile> files)
    {
        var response = new JsonResponse();

        try
        {

            var file = files.First();

            _userProfileService.AddProfileImage(new AddProfileImageDto
            {
                ID = GetUserId(),
                FileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"'),
                FileContent = file.OpenReadStream()
            });

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
                message = "Something went wrong while attempting to upload image.",
            };
        }

        return new JsonResult(response);
    }

    // DELETE api/userprofile/image
    [HttpDelete("image")]
    public JsonResult Delete()
    {
        var response = new JsonResponse();

        try
        {
            _userProfileService.RemoveProfileImage(GetUserId());

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
  }
}