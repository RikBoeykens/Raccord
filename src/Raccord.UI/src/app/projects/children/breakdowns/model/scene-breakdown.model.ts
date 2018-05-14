import { Breakdown } from './breakdown.model';
import { SceneBreakdownItem } from '../children/breakdown-items/model/scene-breakdown-item.model';
import { BreakdownType } from '../children/breakdown-types/model/breakdown-type.model';

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
