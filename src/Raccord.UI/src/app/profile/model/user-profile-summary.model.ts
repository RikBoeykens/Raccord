import { BaseModel } from '../../shared/model/base.model';

export class UserProfileSummary extends BaseModel{
    id: string
    firstName: string;
    lastName: string;
    hasImage: boolean;

    constructor(obj?: {
                        id: string,
                        firstName: string,
                        lastName: string,
                        hasImage: boolean
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.firstName = obj.firstName;
            this.lastName = obj.lastName;
            this.hasImage = obj.hasImage;
        }
    }
}