using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
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
            var dto = vm.Translate(GetUserId());

            var updatedDto = await _userProfileService.UpdateProfile(dto);

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
  }
}