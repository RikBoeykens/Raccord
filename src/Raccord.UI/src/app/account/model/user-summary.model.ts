export class UserSummary{
    email: string;
    isAdmin: boolean

    constructor(obj?: {
                        email: string,
                        isAdmin: boolean
                    }){
        if(obj){
            this.email = obj.email;
            this.isAdmin = obj.isAdmin;
        }
    }
}