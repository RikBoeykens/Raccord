import { Slate } from "./slate.model";
import { Scene } from "../../../scenes/model/scene.model";
import { ShootingDay } from "../../../shooting-days/index";
import { Take } from "../../takes/model/take.model";

export class FullSlate extends Slate {
    takes: Take[];

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
                        takes: Take[]
                    }){
        super(obj);
        if(obj){
            this.takes = obj.takes;
        }
        else{
            this.id = 0;
        }
    }
}