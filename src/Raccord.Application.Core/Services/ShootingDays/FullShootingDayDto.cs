using System;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Crew.CrewUnits;
using Raccord.Application.Core.Services.ShootingDays.Scenes;
using Raccord.Application.Core.Services.Shots.Slates;

namespace Raccord.Application.Core.Services.ShootingDays
{
    // Dto to represent a full shooting day
    public class FullShootingDayDto : BaseShootingDayDto
    {
        private IEnumerable<ShootingDaySceneSceneDto> _scenes;
        private IEnumerable<SlateSummaryDto> _slates;
        private IEnumerable<String> _cameraRolls;
        private IEnumerable<String> _soundRolls;
        private CrewUnitDto _crewUnit;

        // Total count of previously completed scenes
        public int PreviouslyCompletedSceneCount { get; set; }

        // Total count of previously completed page count
        public int PreviouslyCompletedScenePageCount { get; set; }

        // Total count of previously completed timespans
        public TimeSpan PreviouslyCompletedTimingsCount { get; set; }

        // Total count of previous setups
        public int PreviousSetupCount { get; set; }

        // Scenes on the shooting day scene
        public IEnumerable<ShootingDaySceneSceneDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<ShootingDaySceneSceneDto>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Slates on the shooting day scene
        public IEnumerable<SlateSummaryDto> Slates
        {
            get
            {
                return _slates ?? (_slates = new List<SlateSummaryDto>());
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

        public CrewUnitDto CrewUnit
        {
            get
            {
                return _crewUnit ?? new CrewUnitDto();
            }
            set
            {
                _crewUnit = value;
            }
        }
    }
}