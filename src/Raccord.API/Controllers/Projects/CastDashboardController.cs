using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.API.ViewModels.Core;
using Raccord.API.Filters;
using Raccord.Core.Enums;
using Raccord.Application.Core.Services.Calendar;
using Raccord.API.ViewModels.Calendar;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.API.ViewModels.Dashboards;
using Raccord.API.ViewModels.Common.Paging;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.Application.Core.Common.Paging;
using Raccord.Application.Core.Services.Cast;
using Raccord.API.ViewModels.Cast;

namespace Raccord.API.Controllers.Projects
{
    [ProjectPermissionFilter(ProjectPermissionEnum.CanReadGeneral)]
    public class CastDashboardController : AbstractProjectsController
    {
        private readonly ICastMemberService _castMemberService;
        private readonly ICharacterService _characterService;
        private readonly int _defaultPageSize = 4;

        public CastDashboardController(
            ICastMemberService castMemberService,
            ICharacterService characterService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            _castMemberService = castMemberService;
            _characterService = characterService;
        }

        // GET: api/admin/dashboard
        [HttpGet]
        public CastDashboardViewModel Get(long authProjectId)
        {
            var castMembers = GetCastMembers(authProjectId);
            var characters = GetCharacters(authProjectId);
            return new CastDashboardViewModel
            {
                CastMembers = castMembers,
                Characters = characters
            };
        }

        private PagedDataViewModel<CastMemberSummaryViewModel> GetCastMembers(long authProjectId)
        {
            var paginatedCastMembers = _castMemberService.GetPagedForProject(new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            }, authProjectId);

            return paginatedCastMembers.Translate<CastMemberSummaryViewModel, CastMemberSummaryDto>(x => x.Translate());
        }

        private PagedDataViewModel<CharacterSummaryViewModel> GetCharacters(long authProjectId)
        {
            var paginatedCharacters = _characterService.GetPagedForProject(new PaginationRequestDto
            {
                Page = 1,
                PageSize = _defaultPageSize
            }, authProjectId);

            return paginatedCharacters.Translate<CharacterSummaryViewModel, CharacterSummaryDto>(x => x.Translate());
        }
    }
}
