using System;
using Raccord.Application.Core.Common.Paging;
using System.Linq;

namespace Raccord.API.ViewModels.Common.Paging
{
  public static class Utilities
  {
    public static PagedDataViewModel<TVm> Translate<TVm, TDto>(this PagedDataDto<TDto> dto, Func<TDto, TVm> translate)
    {
      if(dto == null)
      {
        return null;
      }
      return new PagedDataViewModel<TVm>
      {
        Data = dto.Data.Select(d=> translate(d)),
        PageInfo = dto.PageInfo.Translate(),
      };
    }

    public static PageInfoViewModel Translate(this PageInfoDto dto)
    {
      if(dto == null)
      {
        return null;
      }

      return new PageInfoViewModel
      {
        Page = dto.Page,
        PageSize = dto.PageSize,
        Total = dto.Total,
        Full = dto.Full
      };
    }

    public static PaginationRequestDto ConstructRequest(int? pageSize, int? page, bool full)
    {
      if(full || !pageSize.HasValue || !page.HasValue)
      {
        return new PaginationRequestDto
        {
          Full = true,
        };
      }

      return new PaginationRequestDto
      {
        PageSize = pageSize.Value,
        Page = page.Value
      };
    }
  }
}