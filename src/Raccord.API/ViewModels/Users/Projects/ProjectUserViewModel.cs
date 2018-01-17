namespace Raccord.API.ViewModels.Users.Projects
{
    // vm to represent a crew user
    public class ProjectUserViewModel
    {
        // ID of the crew user
        public long ID { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // ID of the linked user
        public string UserID { get; set; }

        /// <summary>
        /// Role ID
        /// </summary>
        /// <returns></returns>
        public long? RoleID { get; set; }
    }
}