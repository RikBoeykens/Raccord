using System;
using Raccord.API.ViewModels.Crew.CrewUnits;

namespace Raccord.API.ViewModels.Crew.CrewMembers
{
    public class FullCrewMemberViewModel : CrewMemberViewModel
    {
        private CrewUnitViewModel _crewUnit;

        /// <summary>
        /// Linked user ID (if applicable)
        /// </summary>
        /// <returns></returns>
        public string UserID { get; set; }

        /// <summary>
        /// Linked user invitation ID (if applicable)
        /// </summary>
        /// <returns></returns>
        public Guid? UserInvitationID { get; set; }

        /// <summary>
        /// Indicates if the crew member has an image specified
        /// </summary>
        /// <returns></returns>
        public bool HasImage { get; set; }

        public CrewUnitViewModel CrewUnit
        {
            get
            {
                return _crewUnit ?? new CrewUnitViewModel();
            }
            set
            {
                _crewUnit = value;
            }
        }
    }
}