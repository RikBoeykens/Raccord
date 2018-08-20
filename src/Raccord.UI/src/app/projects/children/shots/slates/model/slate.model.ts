import { BaseModel } from '../../../../../shared';
import { Scene } from '../../../../../shared/children/scenes';
import { ShootingDay } from '../../../..';

export class Slate extends BaseModel {
    public id: number;
    public number: string;
    public description: string;
    public lens: string;
    public distance: string;
    public aperture: string;
    public filters: string;
    public sound: string;
    public isVfx: boolean;
    public projectID: number;
    public scene?: Scene;
    public shootingDay?: ShootingDay;

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
                    }) {
        super();
        if (obj) {
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
        } else {
            this.id = 0;
        }
    }

    public getNumber(): string {
        return this.number ? this.number : '...';
    }
}
