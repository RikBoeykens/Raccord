using System;
using System.Collections.Generic;
using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.ShootingDays.Scenes;
using Raccord.API.ViewModels.Shots.Slates;
using Raccord.Application.Core.Services.Crew.CrewUnits;

namespace Raccord.API.ViewModels.ShootingDays
{
    // Dto to represent a full shooting day
    public class FullShootingDayViewModel : BaseShootingDayViewModel
    {
        private IEnumerable<ShootingDaySceneSceneViewModel> _scenes;
        private IEnumerable<SlateSummaryViewModel> _slates;
        private IEnumerable<String> _cameraRolls;
        private IEnumerable<String> _soundRolls;
        private CrewUnitViewModel _crewUnit;

        // Total count of previously completed scenes
        public int PreviouslyCompletedSceneCount { get; set; }

        // Total count of previously completed page count
        public int PreviouslyCompletedScenePageCount { get; set; }

        // Total count of previously completed timespans
        public TimeSpan PreviouslyCompletedTimingsCount { get; set; }

        // Total count of previous setups
        public int PreviousSetupCount { get; set; }

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

        public CrewUnitViewModel CrewUnit
        {
            get
            {
                return _crewUnit ?? new CrewUnitViewModel();
            }
            set
            {
                _crewUnit = value;
            }
        }
    }
}