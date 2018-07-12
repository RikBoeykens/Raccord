import { BaseModel } from './base.model';

export class Base64Image extends BaseModel {
  public fileName: string;
  public content: string;
  public hasContent: boolean;

  constructor(obj?: {
                      fileName: string,
                      content: string,
                      hasContent: boolean
                  }) {
      super();
      if (obj) {
          this.fileName = obj.fileName;
          this.content = obj.content;
          this.hasContent = obj.hasContent;
      }
  }
}
