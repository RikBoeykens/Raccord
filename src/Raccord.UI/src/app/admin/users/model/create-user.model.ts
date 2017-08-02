import { User } from "./user.model";

export class CreateUser extends User{
    password: string;

    constructor(obj?: {
                        id: string,
                        email: string,
                        password: string
                    }){
        super(obj);
        if(obj){
            this.password = obj.password;
        }
    }
}