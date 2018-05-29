import { BaseModel } from './base.model';

export class ErrorInfo extends BaseModel {
  public hasError: boolean;
  public message: string;
  public error: Error;

  constructor(obj?: {
    message: string,
    error: Error
  }) {
    super();
    if (obj) {
      this.hasError = true;
      this.message = obj.message;
      this.error = obj.error;
    }
  }
}
