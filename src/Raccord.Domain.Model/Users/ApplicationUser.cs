using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Raccord.Domain.Model.Crew;

namespace Raccord.Domain.Model.Users
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<CrewUser> _crew;

        // Crew associated with the project
        public virtual ICollection<CrewUser> Crew
        {
            get
            {
                return _crew ?? (_crew = new List<CrewUser>());
            }
            set
            {
                _crew = value;
            }
        }
    }
}