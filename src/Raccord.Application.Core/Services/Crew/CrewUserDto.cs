namespace Raccord.Application.Core.Services.Crew
{
    public class CrewUserDto
    {
        // ID of the crew user
        public long ID { get; set; }

        // Linked User
        public string UserID { get; set; }

        // Linked project
        public long ProjectID { get; set; }
    }
}