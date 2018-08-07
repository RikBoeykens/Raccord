import { Character } from '../../../../../../shared/children/characters';
import { LinkedScene } from '../../../../../../shared/children/scenes';
import { CastMemberSummary } from '../../../../../../shared/children/cast';
import { LinkedImage } from '../../../../../../shared/children/images';
import { ShootingDayInfoSceneCollection, Comment } from '../../../../..';

export class FullCharacter extends Character {
  public scenes: LinkedScene[];
  public images: LinkedImage[];
  public shootingDays: ShootingDayInfoSceneCollection[];
  public castMember: CastMemberSummary;
  public comments: Comment[];

  constructor(obj?: {
                      id: number,
                      number: number,
                      name: string,
                      description: string,
                      projectID: number,
                      scenes: LinkedScene[],
                      images: LinkedImage[],
                      shootingDays: ShootingDayInfoSceneCollection[],
                      castMember: CastMemberSummary,
                      comments: Comment[]
                  }) {
      super(obj);
      if (obj) {
          this.scenes = obj.scenes;
          this.images = obj.images;
          this.shootingDays = obj.shootingDays;
          this.castMember = obj.castMember;
          this.comments = obj.comments;
      }
  }
}
