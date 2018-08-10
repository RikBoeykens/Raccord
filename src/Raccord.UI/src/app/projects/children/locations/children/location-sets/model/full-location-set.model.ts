import { LocationSetSummary } from './location-set-summary.model';
import {
    Location,
    ShootingDayInfoSceneCollection,
    Comment
} from '../../../../..';
import { LatLng } from '../../../../../../shared';
import { ScriptLocation } from '../../../../../../shared/children/script-locations';

export class FullLocationSet extends LocationSetSummary {
    public comments: Comment[];
    public shootingDays: ShootingDayInfoSceneCollection[];

    constructor(
        obj?: {
        id: number,
        name: string,
        description: string,
        latLng: LatLng,
        location: Location,
        scriptLocation: ScriptLocation,
        shootingDays: ShootingDayInfoSceneCollection[],
        comments: Comment[]
    }) {
        super(obj);
        if (obj) {
            this.shootingDays = obj.shootingDays;
            this.comments = obj.comments;
        }
    }
}
