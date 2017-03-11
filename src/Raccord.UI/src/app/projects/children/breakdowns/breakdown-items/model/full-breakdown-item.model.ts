import { BreakdownItem } from './breakdown-item.model';
import { LinkedScene } from '../../../scenes/model/linked-scene.model';
import { LinkedImage } from '../../../images/model/linked-image.model';
import { BreakdownType } from '../../breakdown-types/model/breakdown-type.model';

export class FullBreakdownItem extends BreakdownItem{
    scenes: LinkedScene[];
    images: LinkedImage[];

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        type: BreakdownType,
                        scenes: LinkedScene[],
                        images: LinkedImage[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.images = obj.images;
        }
    }
}