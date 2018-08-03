import { Breakdown } from './breakdown.model';
import { BreakdownType } from '../../..';

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
