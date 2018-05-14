using System.Linq;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Scenes;
using Raccord.Application.Core.Services.Cast;

namespace Raccord.API.ViewModels.Cast
{
  public static class Utilities
  {
    public static FullCastMemberViewModel Translate(this FullCastMemberDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new FullCastMemberViewModel
      {
        ID = dto.ID,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Telephone = dto.Telephone,
        Email = dto.Email,
        ProjectID = dto.ProjectID,
        UserID = dto.UserID,
        HasImage = dto.HasImage,
        Characters = dto.Characters.Select(c => c.Translate()),
        Scenes = dto.Scenes.Select(s => s.Translate()),
      };
    }
    public static CastMemberSummaryViewModel Translate(this CastMemberSummaryDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new CastMemberSummaryViewModel
      {
        ID = dto.ID,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Telephone = dto.Telephone,
        Email = dto.Email,
        ProjectID = dto.ProjectID,
        UserID = dto.UserID,
        HasImage = dto.HasImage,
      };
    }
    public static CastMemberViewModel Translate(this CastMemberDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new CastMemberViewModel
      {
        ID = dto.ID,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Telephone = dto.Telephone,
        Email = dto.Email,
        ProjectID = dto.ProjectID,
      };
    }
    public static CastMemberDto Translate(this CastMemberViewModel vm)
    {
      if(vm == null)
      {
        return null;
      }

      return new CastMemberDto
      {
        ID = vm.ID,
        FirstName = vm.FirstName,
        LastName = vm.LastName,
        Telephone = vm.Telephone,
        Email = vm.Email,
        ProjectID = vm.ProjectID,
      };
    }
  }
}