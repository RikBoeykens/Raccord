namespace Raccord.API.ViewModels.Locations.LocationSets
{
    // ViewModel to represent a set that's linked to something
    public class LinkedLocationSetViewModel: LocationSetSummaryViewModel
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}