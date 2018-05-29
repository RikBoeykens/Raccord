using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.API.ViewModels.Comments;
using Raccord.Application.Core.Services.Comments;
using Raccord.API.ViewModels.Core;
using Raccord.API.Filters;
using Raccord.Core.Enums;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanComment)]
    public class CommentsController : AbstractProjectsController
    {
        private readonly ICommentService _commentService;

        public CommentsController(
            ICommentService commentService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if(commentService == null)
                throw new ArgumentNullException(nameof(commentService));

            _commentService = commentService;
        }

        // GET: api/comments
        [HttpGet]
        public IEnumerable<CommentViewModel> GetForProject([FromQuery]long parentId, [FromQuery]ParentCommentType parentType)
        {
            var dtos = _commentService.GetForParent(new GetCommentDto
            {
                ParentID = parentId,
                ParentType = parentType
            });

            return dtos.Select(c=> c.Translate());
        }

        // GET: api/comments
        [HttpGet("{id}")]
        public CommentViewModel Get([FromRoute]long id)
        {
            var dto = _commentService.Get(id);

            return dto.Translate();
        }

        // POST api/comments
        [HttpPost]
        public JsonResult Post([FromBody]PostCommentViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var dto = vm.Translate(GetUserId());

                long id;

                if (dto.ID == default(long))
                {
                    id = _commentService.Add(dto);
                }
                else
                {
                    id = _commentService.Update(dto);
                }

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
                    message = "Something went wrong while attempting to update comment",
                };
            }

            return new JsonResult(response);
        }

        // DELETE api/crewmembers/5
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            var response = new JsonResponse();

            try
            {
                _commentService.Remove(id);

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
                    message = "Something went wrong while attempting to delete comment.",
                };
            }

            return new JsonResult(response);
        }
    }
}
