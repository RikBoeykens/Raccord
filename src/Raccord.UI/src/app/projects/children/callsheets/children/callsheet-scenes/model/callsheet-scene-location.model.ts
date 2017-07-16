import { BaseModel } from '../../../../../../shared/model/base.model';
import { Scene } from '../../../../scenes/model/scene.model';
import { LocationSetSummary } from "../../../../locations";

export class CallsheetSceneLocation extends BaseModel{
    id: number;
    pageLength: number;
    scene: Scene;
    availableLocations: LocationSetSummary[];
    locationSet: LocationSetSummary;

    constructor(obj?: {
                        id: number, 
                        pageLength: number, 
                        scene: Scene,
                        availableLocations: LocationSetSummary[],
                        locationSet: LocationSetSummary,
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.scene = obj.scene;
            this.availableLocations = obj.availableLocations;
            this.locationSet = obj.locationSet;
        }
        else{
            this.id = 0;
        }
    }
}