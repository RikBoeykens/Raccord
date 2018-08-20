import { Location } from './location.model';
import {
    LocationSetScriptLocation,
    ShootingDayInfoSceneCollection,
    Comment
} from '../../../../..';
import {
    Address,
    LatLng
} from '../../../../../../shared';

export class FullLocation extends Location {
    public sets: LocationSetScriptLocation[];
    public shootingDays: ShootingDayInfoSceneCollection[];
    public comments: Comment[];

    constructor(
        obj?: {
        id: number,
        name: string,
        description: string,
        address: Address,
        latLng: LatLng,
        sets: LocationSetScriptLocation[],
        shootingDays: ShootingDayInfoSceneCollection[],
        projectID: number,
        comments: Comment[]
    }) {
        super(obj);
        if (obj) {
            this.sets = obj.sets;
            this.shootingDays = obj.shootingDays;
            this.comments = obj.comments;
        }
    }
}
