import { Breakdown } from '../../../../breakdowns/model/breakdown.model';
import { CallsheetBreakdownType } from '../../../../..';

export class CallsheetBreakdown extends Breakdown {
  public types: CallsheetBreakdownType[];

  constructor(
    obj?: {
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
