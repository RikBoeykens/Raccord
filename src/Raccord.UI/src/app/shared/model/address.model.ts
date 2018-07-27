import { BaseModel } from './base.model';

export class Address extends BaseModel {
    public address1: string;
    public address2: string;
    public address3: string;
    public address4: string;

    constructor(
        obj?: {
        address1: string,
        address2: string,
        address3: string,
        address4: string,
    }) {
        super();
        if (obj) {
            this.address1 = obj.address1;
            this.address2 = obj.address2;
            this.address3 = obj.address3;
            this.address4 = obj.address4;
        }
    }
}
