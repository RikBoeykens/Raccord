using System;
using System.Collections.Generic;
using Raccord.API.ViewModels.ShootingDays.Scenes;
using Raccord.API.ViewModels.Shots.Slates;

namespace Raccord.API.ViewModels.ShootingDays
{
    // Dto to represent a full shooting day
    public class FullShootingDayViewModel : ShootingDayViewModel
    {
        private IEnumerable<ShootingDaySceneSceneViewModel> _scenes;
        private IEnumerable<SlateSummaryViewModel> _slates;
        private IEnumerable<String> _cameraRolls;
        private IEnumerable<String> _soundRolls;

        // Total count of previously completed scenes
        public int PreviouslyCompletedSceneCount { get; set; }

        // Total count of previously completed page count
        public int PreviouslyCompletedScenePageCount { get; set; }

        // Total count of previously completed timespans
        public TimeSpan PreviouslyCompletedTimingsCount { get; set; }

        // Scenes on the shooting day scene
        public IEnumerable<ShootingDaySceneSceneViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<ShootingDaySceneSceneViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Slates on the shooting day scene
        public IEnumerable<SlateSummaryViewModel> Slates
        {
            get
            {
                return _slates ?? (_slates = new List<SlateSummaryViewModel>());
            }
            set
            {
                _slates = value;
            }
        }

        // Camera rolls on the shooting day
        public IEnumerable<String> CameraRolls
        {
            get
            {
                return _cameraRolls ?? (_cameraRolls = new List<String>());
            }
            set
            {
                _cameraRolls = value;
            }
        }

        // Camera rolls on the shooting day
        public IEnumerable<String> SoundRolls
        {
            get
            {
                return _soundRolls ?? (_soundRolls = new List<String>());
            }
            set
            {
                _soundRolls = value;
            }
        }
    }
}