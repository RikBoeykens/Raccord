using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Common.Location;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Geocoding;
using Raccord.Application.Core.ExternalServices.Location;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class GeocodingController : AbstractApiAuthController
    {
        private IGeocodingService _geocodingService;

        public GeocodingController(
            IGeocodingService geocodingService,
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
            _geocodingService = geocodingService;
        }

        // api/geocoding
        [HttpPost]
        public JsonResult Post([FromBody]AddressViewModel vm)
        {
            var response = new JsonResponse();

            try
            {
                var requestDto = vm.Translate();
                var results = _geocodingService.GetLatLng(requestDto);

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
                    message = "Something went wrong while trying to get location.",
                };
            }

            return new JsonResult(response);
        }
    }
}