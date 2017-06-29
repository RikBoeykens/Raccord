export class Address{
    address1: string;
    address2: string;
    address3: string;
    address4: string;

    constructor(obj?: {
        address1: string,
        address2: string,
        address3: string,
        address4: string,
    }){
        if(obj){
            this.address1 = obj.address1;
            this.address2 = obj.address2;
            this.address3 = obj.address3;
            this.address4 = obj.address4;
        }
    }
}