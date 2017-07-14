import { Callsheet } from './callsheet.model';
import { ShootingDay } from "../../shooting-days";
import { CallsheetSceneScene } from "../";

export class FullCallsheet extends Callsheet{
    scenes: CallsheetSceneScene[];

    constructor(obj?: {
                        id: number,
                        shootingDay: ShootingDay,
                        scenes: CallsheetSceneScene[],
                        projectId: number,
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
        }
    }
}