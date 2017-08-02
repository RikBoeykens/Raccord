import { User } from "./user.model";

export class CreateUser extends User{

    constructor(obj?: {
                        id: string,
                        email: string
                    }){
        super(obj);
    }
}