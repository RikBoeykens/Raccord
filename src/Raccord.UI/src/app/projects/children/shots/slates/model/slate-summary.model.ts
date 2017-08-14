import { Slate } from "./slate.model";
import { Scene } from "../../../scenes/model/scene.model";
import { ShootingDay } from "../../../shooting-days/index";

export class SlateSummary extends Slate {
    takeCount: number;

    constructor(obj?: {
                        id: number,
                        number: string,
                        description: string,
                        lens: string,
                        distance: string,
                        aperture: string,
                        filters: string,
                        sound: string,
                        projectID: number,
                        scene?: Scene,
                        shootingDay?: ShootingDay,
                        takeCount: number
                    }){
        super(obj);
        if(obj){
            this.takeCount = obj.takeCount;
        }
        else{
            this.id = 0;
        }
    }
}