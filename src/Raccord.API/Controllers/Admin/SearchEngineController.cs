using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.SearchEngine;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers.Admin
{
    public class SearchEngineController : AbstractAdminController
    {
        private ISearchEngineServiceWrapper _searchEngineService;

        public SearchEngineController(
            ISearchEngineServiceWrapper searchEngineService
            )
        {
            if (searchEngineService == null)
                throw new ArgumentNullException(nameof(searchEngineService));

            _searchEngineService = searchEngineService;
        }

        // api/searchengine/post
        [HttpPost]
        public JsonResult Post([FromBody]SearchRequestViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var requestDto = vm.Translate();
                requestDto.IsAdminSearch = true;
                var results = _searchEngineService.GetResults(requestDto);

                response = new JsonResponse
                {
                    ok = true,
                    data = results.Select(r=> r.Translate()),
                };
            }
            catch (Exception)
            {
                response = new JsonResponse
                {
                    ok = false,
                    message = "Something went wrong while trying to get search results.",
                };
            }

            return new JsonResult(response);
        }
    }
}