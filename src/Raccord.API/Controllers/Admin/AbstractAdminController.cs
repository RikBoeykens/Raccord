using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Raccord.API.Controllers.Admin
{
    [Authorize(Roles="admin")]
    [Route("api/admin/[controller]")]
    public abstract class AbstractAdminController : Controller {}
}