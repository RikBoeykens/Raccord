using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Crew.Departments;
using Raccord.Application.Core.Services.Crew.Departments;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class CrewDepartmentsController : AbstractApiAuthController
    {
        private readonly ICrewDepartmentService _crewDepartmentService;

        public CrewDepartmentsController(
            ICrewDepartmentService crewDepartmentService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            if (crewDepartmentService == null)
                throw new ArgumentNullException(nameof(crewDepartmentService));

            _crewDepartmentService = crewDepartmentService;
        }

        // GET: api/crewdepartments/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<FullCrewDepartmentViewModel> GetAllForProject(long id)
        {
            var dtos = _crewDepartmentService.GetAllForProject(id);

            return dtos.Select(p => p.Translate());
        }
    }
}