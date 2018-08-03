import { BaseModel } from '../../../../shared';

export class PublishBreakdown extends BaseModel {
  public publish: boolean;

  constructor(obj?: {
                      publish: boolean
                  }) {
      super();
      if (obj) {
          this.publish = obj.publish;
      }
  }
}
