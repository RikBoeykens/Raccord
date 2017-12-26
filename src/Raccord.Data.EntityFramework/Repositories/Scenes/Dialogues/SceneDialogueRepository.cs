using Raccord.Domain.Model.Scenes.Dialogues;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Raccord.Data.EntityFramework.Repositories.Scenes.Dialogues
{
    // Repository for scene dialogues
    public class SceneDialogueRepository : BaseRepository<SceneDialogue>, ISceneDialogueRepository
    {
        public SceneDialogueRepository(RaccordDBContext context) : base(context) 
        {
        }
    }
}
