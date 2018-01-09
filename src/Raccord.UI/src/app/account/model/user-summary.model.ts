export class UserSummary{
    id: string;
    email: string;
    isAdmin: boolean;
    firstName: string;
    lastName: string;

    constructor(obj?: {
                        id: string,
                        email: string,
                        isAdmin: boolean,
                        firstName: string,
                        lastName: string
                    }){
        if(obj){
            this.id = obj.id;
            this.email = obj.email;
            this.isAdmin = obj.isAdmin;
            this.firstName = obj.firstName;
            this.lastName = obj.lastName;
        }
    }
}