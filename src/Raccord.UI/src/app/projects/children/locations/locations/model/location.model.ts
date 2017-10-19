import { BaseModel } from '../../../../../shared';
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';

export class Location extends BaseModel{
    id: number;
    name: string;
    description: string;
    address: Address;
    latLng: LatLng;
    projectId: number;

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        address: Address,
                        latLng: LatLng,
                        projectId: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
            this.address = obj.address;
            this.latLng = obj.latLng;
            this.projectId = obj.projectId;
        }
        else{
            this.id = 0;
            this.address = new Address();
            this.latLng = new LatLng();
        }
    }
}