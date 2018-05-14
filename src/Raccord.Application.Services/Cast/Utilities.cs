using System.Linq;
using Raccord.Application.Core.Services.Cast;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.Scenes;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Cast;

namespace Raccord.Application.Services.Cast
{
  public static class Utilities
  {
    public static FullCastMemberDto TranslateFull(this CastMember castMember)
    {
      if(castMember == null)
      {
        return null;
      }

      return new FullCastMemberDto
      {
        ID = castMember.ID,
        FirstName = castMember.GetFirstName(),
        LastName = castMember.GetLastName(),
        Telephone = castMember.GetTelephone(),
        Email = castMember.GetEmail(),
        ProjectID = castMember.ProjectID,
        UserID = castMember.GetUserID(),
        HasImage = castMember.GetHasImage(),
        Characters = castMember.Characters.Select(c => c.TranslateSummary()),
        Scenes = castMember.Characters.SelectMany(c => c.CharacterScenes).OrderBy(cs => cs.Scene.SortingOrder).Select(cs => cs.TranslateScene()).Distinct()
      };
    }
    public static CastMemberSummaryDto TranslateSummary(this CastMember castMember)
    {
      if(castMember == null)
      {
        return null;
      }

      return new CastMemberSummaryDto
      {
        ID = castMember.ID,
        FirstName = castMember.GetFirstName(),
        LastName = castMember.GetLastName(),
        Telephone = castMember.GetTelephone(),
        Email = castMember.GetEmail(),
        ProjectID = castMember.ProjectID,
        UserID = castMember.GetUserID(),
        HasImage = castMember.GetHasImage(),
      };
    }
    public static CastMemberDto Translate(this CastMember castMember)
    {
      if(castMember == null)
      {
        return null;
      }

      return new CastMemberDto
      {
        ID = castMember.ID,
        FirstName = castMember.GetFirstName(),
        LastName = castMember.GetLastName(),
        Telephone = castMember.GetTelephone(),
        Email = castMember.GetEmail(),
        ProjectID = castMember.ProjectID,
      };
    }

    public static SearchResultDto TranslateToSearchResult(this CastMember castMember)
    {
      return new SearchResultDto
      {
        ID = castMember.ID,
        RouteIDs = new long[]{castMember.ProjectID, castMember.ID},
        DisplayName = $"{castMember.GetDisplayName()}",
        Info = $"Project: {castMember.Project.Title}",
        Type = EntityType.CastMember,  
      };
    }

    public static string GetDisplayName(this CastMember castMember)
    {
      return $"{castMember.GetFirstName()} {castMember.GetLastName()}";
    }

    private static string GetFirstName(this CastMember castMember)
    {
      if(castMember.ProjectUserID.HasValue)
      {
        return castMember.ProjectUser.User.FirstName;
      }
      return castMember.FirstName;
    }

    private static string GetLastName(this CastMember castMember)
    {
      if(castMember.ProjectUserID.HasValue)
      {
        return castMember.ProjectUser.User.LastName;
      }
      return castMember.LastName;
    }

    private static string GetTelephone(this CastMember castMember)
    {
      if(castMember.ProjectUserID.HasValue)
      {
        return castMember.ProjectUser.User.Telephone;
      }
      return castMember.Telephone;
    }

    private static string GetEmail(this CastMember castMember)
    {
      if(castMember.ProjectUserID.HasValue)
      {
        return castMember.ProjectUser.User.PreferredEmail;
      }
      return castMember.Email;
    }

    private static string GetUserID(this CastMember castMember)
    {
      if(castMember.ProjectUserID.HasValue)
      {
        return castMember.ProjectUser.UserID;
      }
      return string.Empty;
    }

    private static bool GetHasImage(this CastMember castMember)
    {
      if(castMember.ProjectUserID.HasValue)
      {
        return castMember.ProjectUser.User.ImageContent != null;
      }
      return false;
    }
  }
}