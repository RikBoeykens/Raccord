using Raccord.Domain.Model.Crew.CrewMembers;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Users
{
    public class ProjectUser : Entity
    {
        // ID of the linked project
        public long ProjectID { get; set; }
        // Linked project
        public virtual Project Project { get; set; }

        // ID of the linked user
        public string UserID { get; set; }
        // linked user
        public virtual ApplicationUser User { get; set; }
    }
}