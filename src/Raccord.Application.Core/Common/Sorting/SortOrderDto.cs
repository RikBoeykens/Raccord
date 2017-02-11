namespace Raccord.Application.Core.Common.Sorting
{
    //  Dto for sorting functionality
    public class SortOrderDto
    {
        // ID of the parent element
        public long ParentID {get; set;}
        // Sorted IDs
        public long[] SortIDs {get;set;}
    }
}