import { BaseModel } from '../../../../shared/model/base.model';
import { PagedData } from '../../../../shared/children/paging';
import { CastMemberSummary } from '../../../../shared/children/cast';
import { CharacterSummary } from '../../../../shared/children/characters';

export class CastDashboard extends BaseModel {
  public castMembers: PagedData<CastMemberSummary>;
  public characters: PagedData<CharacterSummary>;

  constructor(
    obj?: {
      castMembers: PagedData<CastMemberSummary>,
      characters: PagedData<CharacterSummary>
  }) {
    super();
    if (obj) {
      this.castMembers = obj.castMembers;
      this.characters = obj.characters;
    }
  }
}
