import { BreakdownItemSummary } from './breakdown-item-summary.model';
import { Image } from '../../../images/model/image.model';
import { BreakdownType } from '../../breakdown-types/model/breakdown-type.model';

export class LinkedBreakdownItem extends BreakdownItemSummary{
    linkID: number

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        type: BreakdownType,
                        sceneCount: number,
                        primaryImage: Image,
                        linkID: number
                    }){
        super(obj);
        if(obj){
            this.linkID = obj.linkID;
        }
    }
}