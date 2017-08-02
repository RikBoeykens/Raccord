export class User{
    id: string;
    email: string;

    constructor(obj?: {
                        id: string,
                        email: string
                    }){
        if(obj){
            this.id = obj.id;
            this.email = obj.email;
        }
    }
}