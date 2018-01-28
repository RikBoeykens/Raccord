using System;
using System.Collections.Generic;
using System.Linq;

namespace Raccord.Application.Core.Common.Paging
{
  public static class Utilities
  {
    public static PagedDataDto<TDto> GetPaged<T, TDto>(this IEnumerable<T> data, PaginationRequestDto dto, Func<T, TDto> translate)
    {
      var count = data.Count();
      return new PagedDataDto<TDto>
      {
        Data = data.GetPagedData<T, TDto>(dto, translate),
        PageInfo = new PageInfoDto
        {
          Page = dto.Page,
          PageSize = dto.PageSize,
          Total = count,
          Full = dto.Full ? dto.Full : count <= dto.PageSize
        }
      };
    }

    public static IEnumerable<TDto> GetPagedData<T, TDto>(this IEnumerable<T> data, PaginationRequestDto dto, Func<T, TDto> translate)
    {
      if(dto.Full)
      {
        return data.Select(d=> translate(d));
      }

      return data.Skip(dto.PageSize * (dto.Page - 1)).Take(dto.PageSize).Select(d=> translate(d));
    }
  }
}