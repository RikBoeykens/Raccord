import { Breakdown } from './breakdown.model';
import { BreakdownType } from '../../..';

export class FullBreakdown extends Breakdown {
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
