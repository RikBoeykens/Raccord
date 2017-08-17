import { Slate } from "./slate.model";
import { Scene } from "../../../scenes/model/scene.model";
import { ShootingDay } from "../../../shooting-days/index";

export class LinkedSlate extends Slate {
    linkID: number;

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
                        linkID: number
                    }){
        super(obj);
        if(obj){
            this.linkID = obj.linkID;
        }
        else{
            this.id = 0;
        }
    }
}