import { UserProfileSummary } from './user-profile-summary.model';

export class UserProfile extends UserProfileSummary{
    telephone: string;
    preferredEmail: string;

    constructor(obj?: {
                        id: string,
                        firstName: string,
                        lastName: string,
                        telephone: string,
                        preferredEmail: string,
                        hasImage: boolean
                    }){
        super(obj);
        if(obj){
            this.telephone = obj.telephone;
            this.preferredEmail = obj.preferredEmail;
        }
    }
}