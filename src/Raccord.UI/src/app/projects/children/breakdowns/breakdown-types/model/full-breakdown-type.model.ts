import { BreakdownType } from './breakdown-type.model';

export class FullBreakdownType extends BreakdownType{

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        sceneCount: number,
                        linkID: number
                    }){
        super(obj);
        if(obj){
        }
    }
}