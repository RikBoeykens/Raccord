using System.Linq;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Services.Crew.CrewMembers;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Crew.CrewMembers;

namespace Raccord.Application.Services.Crew.CrewMembers
{
    public static class Utilities
    {
        public static FullCrewMemberDto TranslateFull(this CrewMember crewMember)
        {
            return new FullCrewMemberDto
            {
                ID = slate.ID,
                Number = slate.Number,
                Description = slate.Description,
                Lens = slate.Lens,
                Distance = slate.Distance,
                Aperture = slate.Aperture,
                Filters = slate.Filters,
                Sound = slate.Sound,
                IsVfx = slate.IsVfx,
                ProjectID = slate.ProjectID,
                Scene = slate.SceneID.HasValue ? slate.Scene.Translate() : null,
                ShootingDay = slate.ShootingDayID.HasValue ? slate.ShootingDay.Translate() : null,
                Takes = slate.Takes.Select(t=> t.Translate()),
                Images = slate.ImageSlates.Select(s=> s.TranslateImage()),
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
                IsVfx = slate.IsVfx,
                ProjectID = slate.ProjectID,
                Scene = slate.SceneID.HasValue ? slate.Scene.Translate() : null,
                ShootingDay = slate.ShootingDayID.HasValue ? slate.ShootingDay.Translate() : null,
                TakeCount = slate.Takes.Count(),
                PrimaryImage = slate.ImageSlates.FirstOrDefault(il=> il.IsPrimaryImage)?.Image.Translate(),
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
                IsVfx = slate.IsVfx,
                ProjectID = slate.ProjectID,
                Scene = slate.SceneID.HasValue ? slate.Scene.Translate() : null,
                ShootingDay = slate.ShootingDayID.HasValue ? slate.ShootingDay.Translate() : null,
            };
        }
        public static LinkedSlateDto TranslateSlate(this ImageSlate imageSlate)
        {
            return new LinkedSlateDto
            {
                ID = imageSlate.Slate.ID,
                Number = imageSlate.Slate.Number,
                Description = imageSlate.Slate.Description,
                Lens = imageSlate.Slate.Lens,
                Distance = imageSlate.Slate.Distance,
                Aperture = imageSlate.Slate.Aperture,
                Filters = imageSlate.Slate.Filters,
                Sound = imageSlate.Slate.Sound,
                IsVfx = imageSlate.Slate.IsVfx,
                ProjectID = imageSlate.Slate.ProjectID,
                Scene = imageSlate.Slate.SceneID.HasValue ? imageSlate.Slate.Scene.Translate() : null,
                ShootingDay = imageSlate.Slate.ShootingDayID.HasValue ? imageSlate.Slate.ShootingDay.Translate() : null,
                LinkID = imageSlate.ID,
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
                Type = EntityType.Slate,  
            };
        }
    }
}