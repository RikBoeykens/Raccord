using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers.Projects
{
    [Route("api/projects/{authProjectId}/[controller]")]
    public abstract class AbstractProjectsController : AbstractApiAuthController 
    {
      public AbstractProjectsController(
        UserManager<ApplicationUser> userManager
      ): base(userManager){}
    }
}