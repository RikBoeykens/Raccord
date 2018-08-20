import { Location } from '../../../../locations/children/locations/model/location.model';
import { CallsheetLocationSet } from '../../../../..';
import { Address, LatLng } from '../../../../../../shared';

export class CallsheetLocation extends Location {
    public number: string;
    public sets: CallsheetLocationSet[];

    constructor(
        obj?: {
        id: number,
        name: string,
        description: string,
        address: Address,
        latLng: LatLng,
        projectID: number,
        number: string,
        sets: CallsheetLocationSet[],
    }) {
        super(obj);
        if (obj) {
            this.number = obj.number;
            this.sets = obj.sets;
        }
    }
}
