import { BaseModel } from '../../../../../shared';
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';
import { CallsheetLocationSet } from '../../location-sets/model/callsheet-location-set.model';
import { Location } from './location.model';

export class CallsheetLocation extends Location {
    number: string;
    sets: CallsheetLocationSet[];

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        address: Address,
                        latLng: LatLng,
                        projectId: number,
                        number: string,
                        sets: CallsheetLocationSet[],
                    }){
        super(obj);
        if(obj){
            this.number = obj.number;
            this.sets = obj.sets;
        }
    }
}