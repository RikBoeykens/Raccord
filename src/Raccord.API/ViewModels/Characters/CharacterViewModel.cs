namespace Raccord.API.ViewModels.Characters
{
    // Viewmodel to represent a character
    public class CharacterViewModel
    {
        // ID of the character
        public long ID { get; set; }

        /// Number of the character
        public int Number { get; set; }

        /// Name of the character
        public string Name { get; set; }

        /// Description of the character
        public string Description { get; set; }

        // ID of the project
        public long ProjectID { get; set; }
    }
}