import { BaseModel } from '../../../../../shared';
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';
import { ScriptLocation } from "../../../../children/script-locations/model/script-location.model";
import { LocationSetScriptLocation } from './location-set-script-location.model';
import { SceneSummary } from '../../../scenes/model/scene-summary.model';

export class CallsheetLocationSet extends LocationSetScriptLocation{
    scenes: SceneSummary[];

    constructor(obj?: {
                        id: number, 
                        name: string,
                        description: string,
                        latLng: LatLng,
                        scriptLocation: ScriptLocation,
                        scenes: SceneSummary[],
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
        }
    }
}