using System;
using System.Linq;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.SearchEngine
{
  public static class Utilities
  {
    public static long[] GetExcludeLongIDs(this SearchRequestDto requestDto, EntityType type)
    {
      return requestDto.ExcludeTypeIDs.FirstOrDefault(e=> e.Type == type)?.IDs.Select(id => (long)id).ToArray() ?? new long[]{};
    }
    public static string[] GetExcludeStringIDs(this SearchRequestDto requestDto, EntityType type)
    {
      return requestDto.ExcludeTypeIDs.FirstOrDefault(e=> e.Type == type)?.IDs.Select(id => (string)id).ToArray() ?? new string[]{};
    }
    public static Guid[] GetExcludeGuidIDs(this SearchRequestDto requestDto, EntityType type)
    {
      return requestDto.ExcludeTypeIDs.FirstOrDefault(e=> e.Type == type)?.IDs.Select(id => (Guid)id).ToArray() ?? new Guid[]{};
    }
  }
}