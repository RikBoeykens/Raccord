import { BaseModel } from '../../../model/base.model';

export class ScriptLocation extends BaseModel {
  public id: number;
  public name: string;
  public projectID: number;

  constructor(
    obj?: {
      id: number,
      name: string,
      projectID: number
    }
  ) {
    super();
    if (obj) {
      this.id = obj.id;
      this.name = obj.name;
      this.projectID = obj.projectID;
    }
  }
}
