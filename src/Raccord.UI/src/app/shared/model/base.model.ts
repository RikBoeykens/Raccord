export abstract class BaseModel {

  public equals(obj: any) {
      return JSON.stringify(this) === JSON.stringify(obj);
  }
}
