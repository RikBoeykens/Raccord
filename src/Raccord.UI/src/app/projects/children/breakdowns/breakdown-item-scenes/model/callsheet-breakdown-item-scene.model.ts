import { BaseModel } from '../../../../../shared/model/base.model';
import { CallsheetBreakdownItem } from '../../breakdown-items/model/callsheet-breakdown-item.model';

export class CallsheetBreakdownItemScene extends BaseModel{
    sceneID: number;
    sceneNumber: string;
    items: CallsheetBreakdownItem[];
    hasItems: boolean;

    constructor(obj?: {
                        sceneID: number, 
                        sceneNumber: string, 
                        items: CallsheetBreakdownItem[],
                        hasItems: boolean
                    }){
        super();
        if(obj){
            this.sceneID = obj.sceneID;
            this.sceneNumber = obj.sceneNumber;
            this.items = obj.items;
            this.hasItems = obj.hasItems;
        }
    }
}