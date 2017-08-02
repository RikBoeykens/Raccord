import { User } from "./user.model";

export class FullUser extends User{

    constructor(obj?: {
                        id: string,
                        email: string
                    }){
        super(obj);
    }
}