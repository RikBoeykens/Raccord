export class User{
    id: string;
    email: string;
    firstName: string;
    lastName: string;

    constructor(obj?: {
                        id: string,
                        email: string,
                        firstName: string,
                        lastName: string
                    }){
        if(obj){
            this.id = obj.id;
            this.email = obj.email;
            this.firstName = obj.firstName;
            this.lastName = obj.lastName;
        }
    }
}