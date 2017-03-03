import { Location } from './location.model';

export class LinkedLocation extends Location{
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