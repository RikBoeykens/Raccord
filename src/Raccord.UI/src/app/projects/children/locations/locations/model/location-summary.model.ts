import { Location } from './location.model';
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';

export class LocationSummary extends Location{
    setCount: number;

    constructor(obj?: {
                        id: number, 
                        name: string,
                        description: string,
                        address: Address,
                        latLng: LatLng,
                        setCount: number;
                        projectId: number
                    }){
        super(obj);
        if(obj){
            this.setCount = obj.setCount;
        }
        else{
            this.id = 0;
        }
    }
}