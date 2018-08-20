import { BaseModel } from '../../../../shared/model/base.model';
import { PagedData } from '../../../../shared/children/paging';
import { SceneSummary } from '../../../../shared/children/scenes';
import { CharacterSummary } from '../../../../shared/children/characters';
import { ScriptLocationSummary } from '../../../../shared/children/script-locations';

export class ScriptDashboard extends BaseModel {
  public scenes: PagedData<SceneSummary>;
  public characters: PagedData<CharacterSummary>;
  public scriptLocations: PagedData<ScriptLocationSummary>;

  constructor(
    obj?: {
      scenes: PagedData<SceneSummary>,
      characters: PagedData<CharacterSummary>,
      scriptLocations: PagedData<ScriptLocationSummary>
  }) {
    super();
    if (obj) {
      this.scenes = obj.scenes;
      this.characters = obj.characters;
      this.scriptLocations = obj.scriptLocations;
    }
  }
}
