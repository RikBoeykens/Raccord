using Raccord.Application.Core.Common.Routing;

namespace Raccord.API.ViewModels.Common.Routing
{
  public static class Utilities
  {
    public static RouteInfoViewModel Translate(this RouteInfoDto dto)
    {
      return new RouteInfoViewModel
      {
        Type = dto.Type,
        RouteIDs = dto.RouteIDs
      };
    }
  }
}