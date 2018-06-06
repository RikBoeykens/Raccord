using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raccord.API.ViewModels.Common.Location;
using Raccord.API.ViewModels.Core;
using Raccord.API.ViewModels.Geocoding;
using Raccord.API.ViewModels.Weather;
using Raccord.Application.Core.Common.Location;
using Raccord.Application.Core.ExternalServices.Location;
using Raccord.Application.Core.ExternalServices.Weather;
using Raccord.Domain.Model.Users;

namespace Raccord.API.Controllers
{
    public class WeatherController : AbstractApiController
    {
        private IWeatherService _weatherService;

        public WeatherController(
            IWeatherService weatherService,
            UserManager<ApplicationUser> userManager
            ): base()
        {
            _weatherService = weatherService;
        }

        // api/geocoding
        [HttpPost("{addDays}")]
        public JsonResult Post([FromRoute]int addDays, [FromBody]LatLngViewModel latLng)
        {
            var response = new JsonResponse();

            try
            {
                var requestDto = new WeatherRequestDto
                {
                    LatLng = latLng.Translate(),
                    Date = DateTime.UtcNow.Date.AddDays(addDays)
                };
                var result = _weatherService.GetWeatherInfo(requestDto);

                response = new JsonResponse
                {
                    ok = true,
                    data = result.Translate(),
                };
            }
            catch (Exception ex)
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