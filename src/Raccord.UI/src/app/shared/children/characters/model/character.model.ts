import { BaseModel } from '../../../model/base.model';

export class Character extends BaseModel {
  public id: number;
  public number: number;
  public name: string;
  public description: string;
  public projectID: number;

  constructor(obj?: {
                      id: number,
                      number: number,
                      name: string,
                      description: string,
                      projectID: number,
                  }) {
      super();
      if (obj) {
          this.id = obj.id;
          this.number = obj.number;
          this.name = obj.name;
          this.description = obj.description;
          this.projectID = obj.projectID;
      } else {
          this.id = 0;
      }
  }
}
