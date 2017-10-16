namespace Raccord.Application.Core.Services.Users.Project
{
    public class ProjectUserDto
    {
        // ID of the crew user
        public long ID { get; set; }

        // Linked User
        public string UserID { get; set; }

        // Linked project
        public long ProjectID { get; set; }
    }
}