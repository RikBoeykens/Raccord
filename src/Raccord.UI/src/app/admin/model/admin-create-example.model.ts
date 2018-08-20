import { BaseModel } from '../../shared';

export class AdminCreateExample extends BaseModel {
  public projectName: string;

  constructor(
    obj?: {
      projectName: string
  }) {
    super();
    if (obj) {
      this.projectName = obj.projectName;
    }
  }
}
