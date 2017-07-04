namespace Raccord.API.ViewModels.Common.Location
{
    public class LatLngViewModel
    {
        // Latitude
        public double? Latitude { get; set; }

        // Longitude
        public double? Longitude { get; set; }

        public bool HasLatLng
        {
            get
            {
                return this.Latitude.HasValue && this.Longitude.HasValue;
            }
        }
    }
}