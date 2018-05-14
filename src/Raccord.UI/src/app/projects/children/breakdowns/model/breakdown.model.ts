import { BaseModel } from '../../../../shared/model/base.model';

export class Breakdown extends BaseModel {
  public id: number;
  public name: string;
  public description: string;
  public projectID: number;

  constructor(obj?: {
                      id: number,
                      name: string,
                      description: string,
                      projectID: number
                  }) {
      super();
      if (obj) {
          this.id = obj.id;
          this.name = obj.name;
          this.description = obj.description;
          this.projectID = obj.projectID;
      } else {
          this.id = 0;
      }
  }
}
