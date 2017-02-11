namespace Raccord.API.ViewModels.Common.Sorting
{
    //  Viewmodel for sorting functionality
    public class SortOrderViewModel
    {
        // ID of the parent element
        public long ParentID {get; set;}
        // Sorted IDs
        public long[] SortIDs {get;set;}
    }
}