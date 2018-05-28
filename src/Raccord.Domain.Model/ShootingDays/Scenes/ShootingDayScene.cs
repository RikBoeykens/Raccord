using System;
using System.Collections.Generic;
using Raccord.Domain.Model.Callsheets.Scenes;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Locations.LocationSets;
using Raccord.Domain.Model.Scenes;
using Raccord.Domain.Model.ShootingDays;
using Raccord.Core.Enums;

namespace Raccord.Domain.Model.ShootingDays.Scenes
{
    /// Represents shooting day scene
    public class ShootingDayScene : Entity<long>
    {
        // Length in eights
        public int PageLength { get; set; }
        // Length in eights
        public TimeSpan Timings { get; set; }

        // Indicates if the scene is completed
        public Completion Completion { get; set; }

        // ID of the linked callsheet
        public long ShootingDayID { get; set; }

        // Linked callsheet
        public virtual ShootingDay ShootingDay { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }

        // Linked scene
        public virtual Scene Scene { get; set; }

        public long? CallsheetSceneID { get; set; }

        public virtual CallsheetScene CallsheetScene { get; set; }

        public long? LocationSetID { get; set; }

        public virtual LocationSet LocationSet { get; set; }
    }
}