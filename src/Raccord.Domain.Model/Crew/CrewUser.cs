using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Crew
{
    public class CrewUser : Entity
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