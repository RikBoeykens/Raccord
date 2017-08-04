namespace Raccord.API.ViewModels.Crew
{
    // vm to represent a crew user
    public class CrewUserViewModel
    {
        // ID of the crew user
        public long ID { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // ID of the linked user
        public string UserID { get; set; }
    }
}