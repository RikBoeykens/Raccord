import { Breakdown } from './breakdown.model';
import { BreakdownType } from '../children/breakdown-types/model/breakdown-type.model';

export class SelectedBreakdown extends Breakdown {
  public types: BreakdownType[];

  constructor(obj?: {
                      id: number,
                      name: string,
                      description: string,
                      projectID: number,
                      types: BreakdownType[]
                  }) {
      super(obj);
      this.types = obj.types;
  }
}
