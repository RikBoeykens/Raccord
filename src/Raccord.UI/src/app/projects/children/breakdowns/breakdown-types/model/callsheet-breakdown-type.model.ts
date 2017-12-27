import { BreakdownType } from "./breakdown-type.model";
import { CallsheetBreakdownItemScene } from "../../breakdown-item-scenes/model/callsheet-breakdown-item-scene.model";


export class CallsheetBreakdownType extends BreakdownType{
    scenes: CallsheetBreakdownItemScene[];
    hasItems: boolean;

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        scenes: CallsheetBreakdownItemScene[],
                        hasItems: boolean;
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.hasItems = obj.hasItems;
        }
    }
}