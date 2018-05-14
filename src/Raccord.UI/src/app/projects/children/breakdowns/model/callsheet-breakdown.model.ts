import { Breakdown } from './breakdown.model';
import { CallsheetBreakdownType } from
    '../children/breakdown-types/model/callsheet-breakdown-type.model';

export class CallsheetBreakdown extends Breakdown {
  public types: CallsheetBreakdownType[];

  constructor(obj?: {
                      id: number,
                      name: string,
                      description: string,
                      projectID: number,
                      types: CallsheetBreakdownType[]
                  }) {
      super();
      if (obj) {
          this.types = obj.types;
      }
  }
}
