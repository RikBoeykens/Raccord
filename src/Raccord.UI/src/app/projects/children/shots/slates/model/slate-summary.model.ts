import { Slate } from "./slate.model";
import { Scene } from "../../../scenes/model/scene.model";
import { ShootingDay } from "../../../shooting-days/index";
import { Image } from "../../../images/model/image.model";

export class SlateSummary extends Slate {
    takeCount: number;
    primaryImage: Image;

    constructor(obj?: {
                        id: number,
                        number: string,
                        description: string,
                        lens: string,
                        distance: string,
                        aperture: string,
                        filters: string,
                        sound: string,
                        isVfx: boolean,
                        projectID: number,
                        scene?: Scene,
                        shootingDay?: ShootingDay,
                        takeCount: number,
                        primaryImage: Image
                    }){
        super(obj);
        if(obj){
            this.takeCount = obj.takeCount;
            this.primaryImage = obj.primaryImage;
        }
        else{
            this.id = 0;
        }
    }
}