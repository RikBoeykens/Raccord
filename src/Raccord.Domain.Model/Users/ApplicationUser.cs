using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Raccord.Domain.Model.Users
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<ProjectUser> _projectUsers;

        // Projects associated with the user
        public virtual ICollection<ProjectUser> ProjectUsers
        {
            get
            {
                return _projectUsers ?? (_projectUsers = new List<ProjectUser>());
            }
            set
            {
                _projectUsers = value;
            }
        }
    }
}