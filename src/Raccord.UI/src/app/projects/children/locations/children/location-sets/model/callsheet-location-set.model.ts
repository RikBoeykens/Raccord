import { SceneSummary } from '../../../../../../shared/children/scenes';
import { LatLng } from '../../../../../../shared';
import { ScriptLocation } from '../../../../../../shared/children/script-locations';
import { LocationSetScriptLocation } from './location-set-script-location.model';

export class CallsheetLocationSet extends LocationSetScriptLocation {
    public scenes: SceneSummary[];

    constructor(
        obj?: {
        id: number,
        name: string,
        description: string,
        latLng: LatLng,
        scriptLocation: ScriptLocation,
        scenes: SceneSummary[],
    }) {
        super(obj);
        if (obj) {
            this.scenes = obj.scenes;
        }
    }
}
