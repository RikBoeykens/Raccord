using System.Linq;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.SearchEngine
{
  public static class Utilities
  {
    public static long[] GetExcludeIDs(this SearchRequestDto requestDto, EntityType type)
    {
      return requestDto.ExcludeTypeIDs.FirstOrDefault(e=> e.Type == type)?.IDs.ToArray() ?? new long[]{};
    }
  }
}