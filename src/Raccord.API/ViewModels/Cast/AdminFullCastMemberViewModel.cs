using System;
using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Scenes;
using Raccord.Application.Core.Services.Profile;

namespace Raccord.API.ViewModels.Cast
{
  public class AdminFullCastMemberViewModel : CastMemberViewModel
  {
    private IEnumerable<CharacterSummaryViewModel> _characters;
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
    public IEnumerable<CharacterSummaryViewModel> Characters
    {
      get
      {
        return _characters ?? (_characters = new List<CharacterSummaryViewModel>());
      }
      set
      {
        _characters = value;
      }
    }
  }
}