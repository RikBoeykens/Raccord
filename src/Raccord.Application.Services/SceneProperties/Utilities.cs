using System.Linq;
using Raccord.Application.Core.Services.SceneProperties;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using Raccord.Application.Core.Common.Routing;

namespace Raccord.Application.Services.SceneProperties
{
    // Utilities and helper methods for Locations
    public static class Utilities
    {
        public static FullSceneIntroDto TranslateFull(this SceneIntro sceneIntro)
        {
            if(sceneIntro == null)
            {
                return null;
            }

            var dto = new FullSceneIntroDto
            {
                ID = sceneIntro.ID,
                Name = sceneIntro.Name,
                Description = sceneIntro.Description,
                Scenes = sceneIntro.Scenes.Select(s=> s.TranslateSummary()),
                ProjectID = sceneIntro.ProjectID,
            };

            return dto;
        }
        public static SceneIntroSummaryDto TranslateSummary(this SceneIntro sceneIntro)
        {
            if(sceneIntro == null)
            {
                return null;
            }
            
            var dto = new SceneIntroSummaryDto
            {
                ID = sceneIntro.ID,
                Name = sceneIntro.Name,
                Description = sceneIntro.Description,
                ProjectID = sceneIntro.ProjectID,
                SceneCount = sceneIntro.Scenes.Count(),
            };

            return dto;
        }
        public static SceneIntroDto Translate(this SceneIntro sceneIntro)
        {
            if(sceneIntro == null)
            {
                return null;
            }
            
            var dto = new SceneIntroDto
            {
                ID = sceneIntro.ID,
                Name = sceneIntro.Name,
                Description = sceneIntro.Description,
                ProjectID = sceneIntro.ProjectID,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this SceneIntro sceneIntro)
        {
            if(sceneIntro == null)
            {
                return null;
            }
            
            var dto = new SearchResultDto
            {
                ID = sceneIntro.ID,
                DisplayName = sceneIntro.Name,
                RouteInfo = new RouteInfoDto
                {
                    RouteIDs = new object[]{sceneIntro.ProjectID, sceneIntro.ID},
                    Type = EntityType.SceneIntro,
                }
            };

            return dto;
        }

        public static FullTimeOfDayDto TranslateFull(this TimeOfDay timeOfDay)
        {
            if(timeOfDay == null)
            {
                return null;
            }
            
            var dto = new FullTimeOfDayDto
            {
                ID = timeOfDay.ID,
                Name = timeOfDay.Name,
                Description = timeOfDay.Description,
                Scenes = timeOfDay.Scenes.Select(s=> s.TranslateSummary()),
                ProjectID = timeOfDay.ProjectID,
            };

            return dto;
        }
        public static TimeOfDaySummaryDto TranslateSummary(this TimeOfDay timeOfDay)
        {
            if(timeOfDay == null)
            {
                return null;
            }
            
            var dto = new TimeOfDaySummaryDto
            {
                ID = timeOfDay.ID,
                Name = timeOfDay.Name,
                Description = timeOfDay.Description,
                ProjectID = timeOfDay.ProjectID,
                SceneCount = timeOfDay.Scenes.Count(),
            };

            return dto;
        }
        public static TimeOfDayDto Translate(this TimeOfDay timeOfDay)
        {
            if(timeOfDay == null)
            {
                return null;
            }
            
            var dto = new TimeOfDayDto
            {
                ID = timeOfDay.ID,
                Name = timeOfDay.Name,
                Description = timeOfDay.Description,
                ProjectID = timeOfDay.ProjectID,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this TimeOfDay timeOfDay)
        {
            if(timeOfDay == null)
            {
                return null;
            }
            
            var dto = new SearchResultDto
            {
                ID = timeOfDay.ID,
                DisplayName = timeOfDay.Name,
                RouteInfo = new RouteInfoDto
                {
                    RouteIDs = new object[]{timeOfDay.ProjectID, timeOfDay.ID},
                    Type = EntityType.TimeOfDay,
                }
            };

            return dto;
        }
    }
}