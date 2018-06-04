using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Raccord.Application.Core.Common.Location;
using Raccord.Application.Core.ExternalServices.Location;
using Raccord.Core.Options;
using RestSharp;
using RestSharp.Deserializers;

namespace Raccord.Application.ExternalServices.Location
{
  public class GeocodingService : IGeocodingService
  {
    private readonly GeocodingSettings _geocodingSettings;
    
    public GeocodingService(IOptions<GeocodingSettings> geocodingSettings)
    {
      _geocodingSettings = geocodingSettings.Value;
    }

    public IEnumerable<GeocodeResponseDto> GetLatLng(AddressDto requestDto)
    {
      var client = GetRestClient();
      var request = GetRequest(requestDto);
      var response = client.Execute(request);
      return ParseResponse(response);
    }

    private RestClient GetRestClient()
    {
      RestClient client = new RestClient ();
      client.BaseUrl = new Uri (_geocodingSettings.Uri);
      return client;
    }

    private RestRequest GetRequest(AddressDto address)
    {
      RestRequest request = new RestRequest ();
      request.AddParameter ("key", _geocodingSettings.ApiKey);
      request.AddParameter ("address", address.GetAddressString);
      request.Method = Method.GET;
      return request;
    }

    private IEnumerable<GeocodeResponseDto> ParseResponse(IRestResponse response)
    {
      var deserializer = new JsonDeserializer();
      var parsedResponse = deserializer.Deserialize<GeocodeResponse>(response);
      if(parsedResponse.Status == "OK")
      {
        return parsedResponse.Results.Select(result => new GeocodeResponseDto
        {
          FormattedAddress = result.FormattedAddress,
          LatLng = new LatLngDto
          {
            Latitude = result.Geometry.Location.Lat,
            Longitude = result.Geometry.Location.Lng,
          }
        });
      }
      return new List<GeocodeResponseDto>();
    }
  }
}