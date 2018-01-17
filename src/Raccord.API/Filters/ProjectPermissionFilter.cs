using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Raccord.Application.Core.Services.Users.ProjectRoles;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Filters
{
    /// <summary>
    /// Filter for project permissions
    /// </summary>
    public class ProjectPermissionFilter : ActionFilterAttribute
    {
        private readonly ProjectPermissionEnum _permission;

        public ProjectPermissionFilter(ProjectPermissionEnum permission)
        {
            _permission = permission;
        }

        /// <summary>
        /// Filter for the authorization (on executing)
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var projectPermissionService = (IProjectPermissionService)context.HttpContext.RequestServices.GetService(typeof(IProjectPermissionService));
            if(!context.RouteData.Values.TryGetValue("authProjectId", out object projectIdString))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if(!long.TryParse((string)projectIdString, out long projectID))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!projectPermissionService.HasPermission(projectID, _permission))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}