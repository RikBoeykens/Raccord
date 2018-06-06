using System.Collections.Generic;
using Newtonsoft.Json;

namespace Raccord.Application.ExternalServices.Location
{
  public class GeocodeResponse
  {
    public IEnumerable<GeocodeResult> Results { get; set; }
    public string Status { get; set; }
  }

  public class GeocodeResult
  {
    [JsonProperty(PropertyName = "formatted_address")]
    public string FormattedAddress { get; set; }
    public Geometry Geometry { get; set; }
  }

  public class Geometry
  {
    public Location Location { get; set; }
  }

  public class Location
  {
    public double Lat { get; set; }
    public double Lng { get; set; }
  }
}