import { Character } from './character.model';
import { LinkedScene } from '../../scenes/model/linked-scene.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { CharacterScheduleDay } from '../../scheduling/schedule-days/model/character-schedule-day.model';

export class FullCharacter extends Character{
    scenes: LinkedScene[];
    images: LinkedImage[];
    scheduleDays: CharacterScheduleDay[];

    constructor(obj?: {
                        id: number,
                        number: number,
                        name: string,
                        description: string,
                        projectId: number,
                        scenes: LinkedScene[],
                        images: LinkedImage[],
                        scheduleDays: CharacterScheduleDay[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.images = obj.images;
            this.scheduleDays = obj.scheduleDays;
        }
    }
}