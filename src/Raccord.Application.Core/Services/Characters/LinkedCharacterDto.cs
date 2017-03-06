namespace Raccord.Application.Core.Services.Characters
{
    // Dto to represent a character that's linked to something
    public class LinkedCharacterDto: CharacterSummaryDto
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}