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
        public static FullIntExtDto TranslateFull(this IntExt intExt)
        {
            if(intExt == null)
            {
                return null;
            }

            var dto = new FullIntExtDto
            {
                ID = intExt.ID,
                Name = intExt.Name,
                Description = intExt.Description,
                Scenes = intExt.Scenes.Select(s=> s.TranslateSummary()),
                ProjectID = intExt.ProjectID,
            };

            return dto;
        }
        public static IntExtSummaryDto TranslateSummary(this IntExt intExt)
        {
            if(intExt == null)
            {
                return null;
            }
            
            var dto = new IntExtSummaryDto
            {
                ID = intExt.ID,
                Name = intExt.Name,
                Description = intExt.Description,
                ProjectID = intExt.ProjectID,
                SceneCount = intExt.Scenes.Count(),
            };

            return dto;
        }
        public static IntExtDto Translate(this IntExt intExt)
        {
            if(intExt == null)
            {
                return null;
            }
            
            var dto = new IntExtDto
            {
                ID = intExt.ID,
                Name = intExt.Name,
                Description = intExt.Description,
                ProjectID = intExt.ProjectID,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this IntExt intExt)
        {
            if(intExt == null)
            {
                return null;
            }
            
            var dto = new SearchResultDto
            {
                ID = intExt.ID,
                DisplayName = intExt.Name,
                RouteInfo = new RouteInfoDto
                {
                    RouteIDs = new object[]{intExt.ProjectID, intExt.ID},
                    Type = EntityType.IntExt,
                }
            };

            return dto;
        }

        public static FullDayNightDto TranslateFull(this DayNight dayNight)
        {
            if(dayNight == null)
            {
                return null;
            }
            
            var dto = new FullDayNightDto
            {
                ID = dayNight.ID,
                Name = dayNight.Name,
                Description = dayNight.Description,
                Scenes = dayNight.Scenes.Select(s=> s.TranslateSummary()),
                ProjectID = dayNight.ProjectID,
            };

            return dto;
        }
        public static DayNightSummaryDto TranslateSummary(this DayNight dayNight)
        {
            if(dayNight == null)
            {
                return null;
            }
            
            var dto = new DayNightSummaryDto
            {
                ID = dayNight.ID,
                Name = dayNight.Name,
                Description = dayNight.Description,
                ProjectID = dayNight.ProjectID,
                SceneCount = dayNight.Scenes.Count(),
            };

            return dto;
        }
        public static DayNightDto Translate(this DayNight dayNight)
        {
            if(dayNight == null)
            {
                return null;
            }
            
            var dto = new DayNightDto
            {
                ID = dayNight.ID,
                Name = dayNight.Name,
                Description = dayNight.Description,
                ProjectID = dayNight.ProjectID,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this DayNight dayNight)
        {
            if(dayNight == null)
            {
                return null;
            }
            
            var dto = new SearchResultDto
            {
                ID = dayNight.ID,
                DisplayName = dayNight.Name,
                RouteInfo = new RouteInfoDto
                {
                    RouteIDs = new object[]{dayNight.ProjectID, dayNight.ID},
                    Type = EntityType.DayNight,
                }
            };

            return dto;
        }
    }
}