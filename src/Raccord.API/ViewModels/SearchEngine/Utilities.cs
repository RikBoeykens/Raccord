using Raccord.Application.Core.Services.SearchEngine;
using System.Linq;

namespace Raccord.API.ViewModels.SearchEngine
{
    public static class Utilities
    {
        // Translates a search request viewmodel to a search request dto
        public static SearchRequestDto Translate(this SearchRequestViewModel vm)
        {
            return new SearchRequestDto
            {
                SearchText = vm.SearchText,
                ProjectID = vm.ProjectID,
                IncludeTypes = vm.IncludeTypes,
                ExcludeTypes = vm.ExcludeTypes,
                ExcludeTypeIDs = vm.ExcludeTypeIDs.Select(e=> e.Translate())
            };
        }

        // Translates a search result dto to a search result viewmodel
        public static SearchResultViewModel Translate(this SearchResultDto dto)
        {
            return new SearchResultViewModel
            {
                ID = dto.ID,
                RouteIDs = dto.RouteIDs,
                DisplayName = dto.DisplayName,
                Type = dto.Type,
                Info = dto.Info
            };
        }

        // Translates a searchtyperesultdto to a viewmodel
        public static SearchTypeResultViewModel Translate(this SearchTypeResultDto dto)
        {
            return new SearchTypeResultViewModel
            {
                Count = dto.Count,
                Type = dto.Type,
                Results = dto.Results.Select(r=> r.Translate()),
            };
        }

        public static ExcludeTypeIDsDto Translate(this ExcludeTypeIDsViewModel vm)
        {
            if(vm == null)
            {
                return null;
            }

            return new ExcludeTypeIDsDto
            {
                Type = vm.Type,
                IDs = vm.IDs
            };
        }
    }
}
