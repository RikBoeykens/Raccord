using System.Linq;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Application.Core.Services.Shots.Slates;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Services.ShootingDays;
using Raccord.Application.Services.Shots.Takes;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Shots;

namespace Raccord.Application.Services.Shots.Slates
{
    public static class Utilities
    {
        public static FullSlateDto TranslateFull(this Slate slate)
        {
            return new FullSlateDto
            {
                ID = slate.ID,
                Number = slate.Number,
                Description = slate.Description,
                Lens = slate.Lens,
                Distance = slate.Distance,
                Aperture = slate.Aperture,
                Filters = slate.Filters,
                Sound = slate.Sound,
                ProjectID = slate.ProjectID,
                Scene = slate.SceneID.HasValue ? slate.Scene.Translate() : null,
                ShootingDay = slate.ShootingDayID.HasValue ? slate.ShootingDay.Translate() : null,
                Takes = slate.Takes.Select(t=> t.Translate()),
            };
        }
        public static SlateSummaryDto TranslateSummary(this Slate slate)
        {
            return new SlateSummaryDto
            {
                ID = slate.ID,
                Number = slate.Number,
                Description = slate.Description,
                Lens = slate.Lens,
                Distance = slate.Distance,
                Aperture = slate.Aperture,
                Filters = slate.Filters,
                Sound = slate.Sound,
                ProjectID = slate.ProjectID,
                Scene = slate.SceneID.HasValue ? slate.Scene.Translate() : null,
                ShootingDay = slate.ShootingDayID.HasValue ? slate.ShootingDay.Translate() : null,
                TakeCount = slate.Takes.Count(),
            };
        }
        public static SlateDto Translate(this Slate slate)
        {
            return new SlateDto
            {
                ID = slate.ID,
                Number = slate.Number,
                Description = slate.Description,
                Lens = slate.Lens,
                Distance = slate.Distance,
                Aperture = slate.Aperture,
                Filters = slate.Filters,
                Sound = slate.Sound,
                ProjectID = slate.ProjectID,
                Scene = slate.SceneID.HasValue ? slate.Scene.Translate() : null,
                ShootingDay = slate.ShootingDayID.HasValue ? slate.ShootingDay.Translate() : null,
            };
        }

        public static SearchResultDto TranslateToSearchResult(this Slate slate)
        {
            return new SearchResultDto
            {
                ID = slate.ID,
                RouteIDs = new long[]{slate.ProjectID, slate.ID},
                DisplayName = slate.Number,
                Info = $"Project: {slate.Project.Title}",
                Type = EntityType.ScriptLocation,  
            };
        }
    }
}