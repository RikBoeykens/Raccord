using System;
using System.Linq;
using Microsoft.Extensions.Options;
using Raccord.Application.Core.Common.Location;
using Raccord.Application.Core.ExternalServices.Weather;
using Raccord.Core.Options;
using RestSharp;
using RestSharp.Deserializers;

namespace Raccord.Application.ExternalServices.Weather
{
  public class WeatherService : IWeatherService
  {
    private WeatherSettings _weatherSettings;
    private const string _exclude = "currently,minutely,hourly,alerts,flags";

    public WeatherService(IOptions<WeatherSettings> weatherSettings)
    {
      _weatherSettings = weatherSettings.Value;
    }

    public WeatherInfoDto GetWeatherInfo(WeatherRequestDto requestDto)
    {
      // if request is for a day that will not be returned, don't bother
      if(requestDto.Date < DateTime.UtcNow.Date.AddDays(-1) || requestDto.Date > DateTime.UtcNow.Date.AddDays(10))
      {
        return null;
      }
      var client = GetRestClient();
      var request = GetRequest(requestDto.LatLng);
      var response = client.Execute(request);
      return ParseResponse(response, requestDto.Date);
    }

    private RestClient GetRestClient()
    {
      RestClient client = new RestClient ();
      client.BaseUrl = new Uri (_weatherSettings.Uri);
      return client;
    }

    private RestRequest GetRequest(LatLngDto latLng)
    {
      RestRequest request = new RestRequest ("{apiKey}/{lat},{lng}");
      request.AddUrlSegment ("apiKey", _weatherSettings.ApiKey);
      request.AddUrlSegment ("lat", latLng.Latitude);
      request.AddUrlSegment ("lng", latLng.Longitude);

      request.AddParameter ("units", "auto");
      request.AddParameter ("exclude", _exclude);
      request.Method = Method.GET;
      return request;
    }

    private WeatherInfoDto ParseResponse(IRestResponse response, DateTime requestedDate)
    {
      var deserializer = new JsonDeserializer();
      var parsedResponse = deserializer.Deserialize<DarkskyResponse>(response);

      var chosenDay = parsedResponse.Daily.Data.FirstOrDefault(d => d.IsInfoForDate(parsedResponse.Offset, requestedDate));

      if(chosenDay == null)
      {
        return null;
      }

      return new WeatherInfoDto
      {
        Date = Utilities.GetUtcDate(chosenDay.Time, parsedResponse.Offset),
        Summary = chosenDay.Summary,
        Icon = chosenDay.Icon,
        TemperatureLow = chosenDay.TemperatureLow,
        TemperatureLowTime = Utilities.GetLocalDate(chosenDay.TemperatureLowTime),
        TemperatureHigh = chosenDay.TemperatureHigh,
        TemperatureHighTime = Utilities.GetLocalDate(chosenDay.TemperatureHighTime),
        SunriseTime = Utilities.GetLocalDate(chosenDay.SunriseTime),
        SunsetTime = Utilities.GetLocalDate(chosenDay.SunsetTime),
        LatLng = new LatLngDto
        {
          Latitude = parsedResponse.Latitude,
          Longitude = parsedResponse.Longitude
        }
      };
    }
  }
}