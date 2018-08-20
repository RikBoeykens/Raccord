import { CharacterSummary } from './character-summary.model';
import { Image } from '../../images';

export class LinkedCharacter extends CharacterSummary {
  public linkID: number;

  constructor(
    obj?: {
      id: number,
      number: number,
      name: string,
      description: string,
      projectID: number,
      sceneCount: number,
      primaryImage: Image,
      linkID: number
  }) {
    super(obj);
    if (obj) {
        this.linkID = obj.linkID;
    }
  }
}
