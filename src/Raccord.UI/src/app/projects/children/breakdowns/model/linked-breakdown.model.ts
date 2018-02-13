import { Breakdown } from './breakdown.model';
import { LinkedBreakdownItem } from '../children/breakdown-items/model/linked-breakdown-item.model';
import { BreakdownType } from '../children/breakdown-types/model/breakdown-type.model';

export class LinkedBreakdown extends Breakdown {
  public userID: string;
  public items: LinkedBreakdownItem[];
  public types: BreakdownType[];

  constructor(obj?: {
                      id: number,
                      name: string,
                      description: string,
                      projectID: number,
                      userID: string,
                      items: LinkedBreakdownItem[],
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
