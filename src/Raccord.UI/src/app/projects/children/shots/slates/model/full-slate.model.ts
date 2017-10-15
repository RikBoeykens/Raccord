import { Slate } from "./slate.model";
import { Scene } from "../../../scenes/model/scene.model";
import { ShootingDay } from "../../../shooting-days/index";
import { Take } from "../../takes/model/take.model";
import { LinkedImage } from "../../../images/model/linked-image.model";

export class FullSlate extends Slate {
    takes: Take[];
    images: LinkedImage[];

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
                        takes: Take[],
                        images: LinkedImage[],
                    }){
        super(obj);
        if(obj){
            this.takes = obj.takes;
            this.images = obj.images;
        }
        else{
            this.id = 0;
        }
    }
}