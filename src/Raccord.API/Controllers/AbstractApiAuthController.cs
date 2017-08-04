using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    [Authorize]
    public abstract class AbstractApiAuthController : AbstractApiController 
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        
        public AbstractApiAuthController(
            UserManager<ApplicationUser> userManager
        )
        {
            if(userManager==null)
                throw new ArgumentNullException(nameof(userManager));

            _userManager = userManager;
        }

        protected string GetUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
    }
}