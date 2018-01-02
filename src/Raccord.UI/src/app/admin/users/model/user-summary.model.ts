import { User } from "./user.model";

export class UserSummary extends User{
    hasImage: boolean;

    constructor(obj?: {
                        id: string,
                        email: string,
                        firstName: string,
                        lastName: string,
                        hasImage: boolean
                    }){
        super(obj);
        this.hasImage = obj.hasImage;
    }
}