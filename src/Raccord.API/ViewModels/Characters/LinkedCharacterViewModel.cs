namespace Raccord.API.ViewModels.Characters
{
    // ViewModel to represent a character linked to an entity
    public class LinkedCharacterViewModel : CharacterSummaryViewModel
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}