export class UserSummary{
    email: string;
    isAdmin: boolean;
    firstName: string;
    lastName: string;

    constructor(obj?: {
                        email: string,
                        isAdmin: boolean,
                        firstName: string,
                        lastName: string
                    }){
        if(obj){
            this.email = obj.email;
            this.isAdmin = obj.isAdmin;
            this.firstName = obj.firstName;
            this.lastName = obj.lastName;
        }
    }
}