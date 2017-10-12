using System.Collections.Generic;
using Raccord.Domain.Model.Images;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.ShootingDays;

namespace Raccord.Domain.Model.Shots
{

    public class Slate : Entity
    {
        private ICollection<Take> _takes;
        private ICollection<ImageSlate> _images;

        // Number of the shot
        public string Number { get; set; }

        // Desciption of the shot
        public string Description { get; set; }

        // Lens used
        public string Lens { get; set; }

        // Distance
        public string Distance { get; set; }

        // Aperture used
        public string Aperture { get; set; }

        // Filters used
        public string Filters { get; set; }

        // Sound used
        public string Sound { get; set; }

        // Indicates if the slate is VFX
        public bool IsVfx { get; set; }

        // Sorting order
        public int SortingOrder { get; set; }

        // ID of the linked scene
        public long? SceneID { get; set; }

        // Linked scene
        public virtual Scene Scene { get; set; }

        // ID of the linked schooting day
        public long? ShootingDayID { get; set; }

        // Linked Shooting day
        public virtual ShootingDay  ShootingDay { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // Takes linked to the slate
        public virtual ICollection<Take> Takes
        {
            get
            {
                return _takes ?? (_takes = new List<Take>());
            }
            set
            {
                _takes = value;
            }
        }

        // Linked images
        public virtual ICollection<ImageSlate> ImageSlates
        {
            get
            {
                return _images ?? (_images = new List<ImageSlate>());
            }
            set
            {
                _images = value;
            }
        }
    }
}