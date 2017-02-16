import { Location } from './location.model';

export class LocationSummary extends Location{
    sceneCount: number;

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        sceneCount: number
                    }){
        super(obj);
        if(obj){
            this.sceneCount = obj.sceneCount;
        }
    }
}