import { Location } from './location.model';
import { Address, LatLng } from '../../../../../../shared';

export class LocationSummary extends Location {
    public setCount: number;

    constructor(
        obj?: {
        id: number,
        name: string,
        description: string,
        address: Address,
        latLng: LatLng,
        setCount: number;
        projectID: number
    }) {
        super (obj);
        if (obj) {
            this.setCount = obj.setCount;
        }
    }
}
