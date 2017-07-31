using Microsoft.AspNetCore.Authorization;

namespace Raccord.API.Controllers
{
    [Authorize]
    public abstract class AbstractApiAuthController : AbstractApiController {}
}