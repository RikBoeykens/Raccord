using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Raccord.Domain.Model.Users
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<ProjectUser> _projectUsers;

        /// <summary>
        /// First name of the user
        /// </summary>
        /// <returns></returns>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        /// <returns></returns>
        public string LastName { get; set; }

        /// <summary>
        /// Telephone number for the user
        /// </summary>
        /// <returns></returns>
        public string Telephone { get; set; }

        /// <summary>
        /// Preferred email for the user
        /// </summary>
        /// <returns></returns>
        public string PreferredEmail { get; set; }

        /// <summary>
        /// User image
        /// </summary>
        /// <returns></returns>
        public byte[] ImageContent { get; set; }

        public string ImageName { get; set; }

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