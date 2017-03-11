import { BreakdownItem } from './breakdown-item.model';
import { Image } from '../../../images/model/image.model';
import { BreakdownType } from '../../breakdown-types/model/breakdown-type.model';

export class BreakdownItemSummary extends BreakdownItem{
    sceneCount: number;
    primaryImage: Image;

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        type: BreakdownType,
                        sceneCount: number,
                        primaryImage: Image
                    }){
        super(obj);
        if(obj){
            this.sceneCount = obj.sceneCount;
            this.primaryImage = obj.primaryImage;
        }
    }
}