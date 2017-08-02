import { User } from "./user.model";

export class UserSummary extends User{

    constructor(obj?: {
                        id: string,
                        email: string
                    }){
        super(obj);
    }
}