namespace Raccord.Application.Core.Services.Crew.CrewMembers
{
    public class FullCrewMemberDto : CrewMemberDto
    {
        /// <summary>
        /// Linked user ID (if applicable)
        /// </summary>
        /// <returns></returns>
        public string UserID { get; set; }

        /// <summary>
        /// Indicates if the crew member has an image specified
        /// </summary>
        /// <returns></returns>
        public bool HasImage { get; set; }
    }
}