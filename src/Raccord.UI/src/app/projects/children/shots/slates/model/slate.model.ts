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
    filters: string;
    sound: string;
    isVfx: boolean;
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
                        filters: string,
                        sound: string,
                        isVfx: boolean,
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
            this.filters = obj.filters;
            this.sound = obj.sound;
            this.isVfx = obj.isVfx;
            this.projectID = obj.projectID;
            this.scene = obj.scene;
            this.shootingDay = obj.shootingDay;
        }
        else{
            this.id = 0;
        }
    }

    getNumber(): string{
        return this.number ? this.number : "..."; 
    }
}