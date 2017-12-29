import { BaseModel } from '../../shared/model/base.model';

export class UserProfile extends BaseModel{
    firstName: string;
    lastName: string;
    telephone: string;
    preferredEmail: string;

    constructor(obj?: {
                        firstName: string,
                        lastName: string,
                        telephone: string,
                        preferredEmail: string
                    }){
        super();
        if(obj){
            this.firstName = obj.firstName;
            this.lastName = obj.lastName;
            this.telephone = obj.telephone;
            this.preferredEmail = obj.preferredEmail;
        }
    }
}