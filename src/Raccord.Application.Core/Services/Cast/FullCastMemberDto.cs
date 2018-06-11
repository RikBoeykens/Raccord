using System;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Profile;
using Raccord.Application.Core.Services.Scenes;

namespace Raccord.Application.Core.Services.Cast
{
  public class FullCastMemberDto : CastMemberDto
  {
    private IEnumerable<CharacterSummaryDto> _characters;
    private IEnumerable<SceneSummaryDto> _scenes;

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
    public IEnumerable<CharacterSummaryDto> Characters
    {
      get
      {
        return _characters ?? (_characters = new List<CharacterSummaryDto>());
      }
      set
      {
        _characters = value;
      }
    }
    public IEnumerable<SceneSummaryDto> Scenes
    {
      get
      {
        return _scenes ?? (_scenes = new List<SceneSummaryDto>());
      }
      set
      {
        _scenes = value;
      }
    }
  }
}