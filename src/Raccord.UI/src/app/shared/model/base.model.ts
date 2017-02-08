export abstract class BaseModel{

    equals(obj: any){
        return JSON.stringify(this)==JSON.stringify(obj);
    }
}