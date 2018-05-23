using System;
using System.Collections.Generic;

namespace Raccord.Domain.Model.Users.Invitations
{
  public class UserInvitation : Entity<Guid>
  {
    private ICollection<ProjectUserInvitation> _projectUserInvitations;
    public string Email { get; set; }
    public string FirstName { get; set;}
    public string LastName { get; set; }
    public DateTime? AcceptedDate { get; set; }

    // Projects associated with the user
    public virtual ICollection<ProjectUserInvitation> ProjectUsers
    {
      get
      {
        return _projectUserInvitations ?? new List<ProjectUserInvitation>();
      }
      set
      {
        _projectUserInvitations = value;
      }
    }
  }
}