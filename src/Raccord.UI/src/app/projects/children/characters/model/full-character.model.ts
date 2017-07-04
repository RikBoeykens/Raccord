import { Character } from './character.model';
import { LinkedScene } from '../../scenes/model/linked-scene.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { ScheduleDaySceneCollection } from '../../scheduling/schedule-days/model/schedule-day-scene-collection.model';

export class FullCharacter extends Character{
    scenes: LinkedScene[];
    images: LinkedImage[];
    scheduleDays: ScheduleDaySceneCollection[];

    constructor(obj?: {
                        id: number,
                        number: number,
                        name: string,
                        description: string,
                        projectId: number,
                        scenes: LinkedScene[],
                        images: LinkedImage[],
                        scheduleDays: ScheduleDaySceneCollection[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.images = obj.images;
            this.scheduleDays = obj.scheduleDays;
        }
    }
}