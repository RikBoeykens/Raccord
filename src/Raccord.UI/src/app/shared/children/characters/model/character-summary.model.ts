import { Character } from './character.model';
import { Image } from '../../images';

export class CharacterSummary extends Character {
  public primaryImage: Image;
  public sceneCount: number;

  constructor(obj?: {
                      id: number,
                      number: number,
                      name: string,
                      description: string,
                      projectID: number,
                      primaryImage: Image,
                      sceneCount: number
                  }) {
      super(obj);
      if (obj) {
          this.primaryImage = obj.primaryImage;
          this.sceneCount = obj.sceneCount;
      }
  }
}
