import { BaseModel } from '../../../../../shared/model/base.model';
import { Scene } from "../../../scenes/model/scene.model";
import { ShootingDay } from "../../../shooting-days/index";

export class Slate extends BaseModel{
    id: number;
    number: string;
    description: string;
    lens: string;
    distance: string;
    aperture: string;
    filter: string;
    sound: string;
    projectID: number;
    scene? : Scene;
    shootingDay?: ShootingDay;

    constructor(obj?: {
                        id: number,
                        number: string,
                        description: string,
                        lens: string,
                        distance: string,
                        aperture: string,
                        filter: string,
                        sound: string,
                        projectID: number,
                        scene?: Scene,
                        shootingDay?: ShootingDay
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.number = obj.number;
            this.description = obj.description;
            this.lens = obj.lens;
            this.distance = obj.distance;
            this.aperture = obj.aperture;
            this.filter = obj.filter;
            this.sound = obj.sound;
            this.projectID = obj.projectID;
            this.shootingDay = obj.shootingDay;
        }
        else{
            this.id = 0;
        }
    }
}