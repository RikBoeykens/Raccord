import { Character } from './character.model';
import { LinkedScene } from '../../scenes/model/linked-scene.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { LinkedScheduleScene } from '../../scheduling/schedule-scenes/model/linked-schedule-scene.model';

export class FullCharacter extends Character{
    scenes: LinkedScene[];
    images: LinkedImage[];
    scheduleScenes: LinkedScheduleScene[];

    constructor(obj?: {
                        id: number,
                        number: number,
                        name: string,
                        description: string,
                        projectId: number,
                        scenes: LinkedScene[],
                        images: LinkedImage[],
                        scheduleScenes: LinkedScheduleScene[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.images = obj.images;
            this.scheduleScenes = obj.scheduleScenes;
        }
    }
}