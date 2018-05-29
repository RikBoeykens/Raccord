using System.Collections.Generic;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Domain.Model.Images;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Scheduling;
using Raccord.Domain.Model.Callsheets.Scenes;
using Raccord.Domain.Model.Shots;
using System;
using Raccord.Domain.Model.ShootingDays.Scenes;
using Raccord.Domain.Model.ScriptUploads;
using Raccord.Domain.Model.Scenes.Actions;
using Raccord.Domain.Model.Scenes.Dialogues;
using Raccord.Domain.Model.Comments;

namespace Raccord.Domain.Model.Scenes
{
    /// Represents a scene
    public class Scene : Entity<long>
    {
        private ICollection<ImageScene> _images;
        private ICollection<CharacterScene> _characters;
        private ICollection<BreakdownItemScene> _breakdownItems;
        private ICollection<ScheduleScene> _scheduleScenes;
        private ICollection<CallsheetScene> _callsheetScenes;
        private ICollection<Slate> _slates;
        private ICollection<ShootingDayScene> _shootingDayScenes;
        private ICollection<SceneAction> _actions;
        private ICollection<SceneDialogue> _dialogues;
        private ICollection<Comment> _comments;

        // Number of the scene
        public string Number { get; set; }

        // Summary of the scene
        public string Summary { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // The sorting order of the scene within the project
        public int? SortingOrder { get; set; }

        // Timing length
        public TimeSpan Timing { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }

        // Linked project
        public virtual Project Project { get; set; }

        // ID of the linked int/ext
        public long? IntExtID { get; set; }

        // Linked int/ext
        public virtual IntExt IntExt { get; set; }

        // ID of the linked day/night
        public long? DayNightID { get; set; }

        // Linked day/night
        public virtual DayNight DayNight { get; set; }

        // ID of the linked day/night
        public long? ScriptLocationID { get; set; }

        // Linked day/night
        public virtual ScriptLocation ScriptLocation { get; set; }

        // ID of the linked script upload
        public long? ScriptUploadID { get; set; }

        // Linked script upload
        public virtual ScriptUpload ScriptUpload { get; set; }

        // Linked images
        public virtual ICollection<ImageScene> ImageScenes
        {
            get
            {
                return _images ?? (_images = new List<ImageScene>());
            }
            set
            {
                _images = value;
            }
        }

        // Linked characters
        public virtual ICollection<CharacterScene> CharacterScenes
        {
            get
            {
                return _characters ?? (_characters = new List<CharacterScene>());
            }
            set
            {
                _characters = value;
            }
        }

        // Linked breakdown items
        public virtual ICollection<BreakdownItemScene> BreakdownItemScenes
        {
            get
            {
                return _breakdownItems ?? (_breakdownItems = new List<BreakdownItemScene>());
            }
            set
            {
                _breakdownItems = value;
            }
        }

        // Linked schedule scenes
        public virtual ICollection<ScheduleScene> ScheduleScenes
        {
            get
            {
                return _scheduleScenes ?? (_scheduleScenes = new List<ScheduleScene>());
            }
            set
            {
                _scheduleScenes = value;
            }
        }

        // Linked schedule scenes
        public virtual ICollection<CallsheetScene> CallsheetScenes
        {
            get
            {
                return _callsheetScenes ?? (_callsheetScenes = new List<CallsheetScene>());
            }
            set
            {
                _callsheetScenes = value;
            }
        }

        // Linked slates
        public virtual ICollection<Slate> Slates
        {
            get
            {
                return _slates ?? (_slates = new List<Slate>());
            }
            set
            {
                _slates = value;
            }
        }

        // Linked shooting day scenes
        public virtual ICollection<ShootingDayScene> ShootingDayScenes
        {
            get
            {
                return _shootingDayScenes ?? (_shootingDayScenes = new List<ShootingDayScene>());
            }
            set
            {
                _shootingDayScenes = value;
            }
        }

        // Actions on a scene
        public virtual ICollection<SceneAction> Actions
        {
            get
            {
                return _actions ?? (_actions = new List<SceneAction>());
            }
            set
            {
                _actions = value;
            }
        }

        // Dialogues on a scene
        public virtual ICollection<SceneDialogue> Dialogues
        {
            get
            {
                return _dialogues ?? (_dialogues = new List<SceneDialogue>());
            }
            set
            {
                _dialogues = value;
            }
        }
        
        // Comments made to the scene
        public virtual ICollection<Comment> Comments
        {
            get
            {
                return _comments ?? (_comments = new List<Comment>());
            }
            set
            {
                _comments = value;
            }
        }
    }
}