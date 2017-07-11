using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Callsheets.Scenes;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.ShootingDays;

namespace Raccord.Domain.Model.Callsheets
{
    public class Callsheet : Entity
    {
        private ICollection<CallsheetScene> _scenes;

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // ID of the linked shooting day
        public long ShootingDayID { get; set; }

        // Linked shooting day
        public virtual ShootingDay ShootingDay { get; set; }

        // Linked scenes
        public virtual ICollection<CallsheetScene> CallsheetScenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<CallsheetScene>());
            }
            set
            {
                _scenes = value;
            }
        }
    }
}