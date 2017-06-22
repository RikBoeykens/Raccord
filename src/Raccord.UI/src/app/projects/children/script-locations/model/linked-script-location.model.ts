import { ScriptLocation } from './script-location.model';

export class LinkedScriptLocation extends ScriptLocation{
    linkID: number

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
            this.linkID = obj.linkID;
        }
    }
}