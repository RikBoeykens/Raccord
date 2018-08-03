import { Breakdown } from './breakdown.model';
import { SceneBreakdownItem, BreakdownType } from '../../..';

export class SceneBreakdown extends Breakdown {
  public userID: string;
  public items: SceneBreakdownItem[];
  public types: BreakdownType[];

  constructor(obj?: {
                      id: number,
                      name: string,
                      description: string,
                      projectID: number,
                      userID: string,
                      items: SceneBreakdownItem[],
                      types: BreakdownType[]
                  }) {
      super();
      if (obj) {
          this.userID = obj.userID;
          this.items = obj.items;
          this.types = obj.types;
      }
  }
}
