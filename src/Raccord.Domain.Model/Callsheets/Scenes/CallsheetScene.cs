using System.Collections.Generic;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Locations.LocationSets;
using Raccord.Domain.Model.Scenes;

namespace Raccord.Domain.Model.Callsheets.Scenes
{
    /// Represents schedule scene on a day
    public class CallsheetScene : Entity
    {
        private ICollection<CallsheetSceneCharacter> _characters;

        // Length in eights
        public int PageLength { get; set; }

        // The sorting order of the scene within the callsheet
        public int SortingOrder { get; set; }

        // ID of the linked callsheet
        public long CallsheetID { get; set; }

        // Linked callsheet
        public virtual Callsheet Callsheet { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }

        // Linked scene
        public virtual Scene Scene { get; set; }

        public long? LocationSetID { get; set; }

        public virtual LocationSet LocationSet { get; set; }

        // Linked characters
        public virtual ICollection<CallsheetSceneCharacter> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<CallsheetSceneCharacter>());
            }
            set
            {
                _characters = value;
            }
        }
    }
}