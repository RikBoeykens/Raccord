using System;

namespace Raccord.API.ViewModels.Cast
{
  public class CastMemberSummaryViewModel : CastMemberViewModel
  {
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
  }
}