import { Image } from './image.model';

export class ImageSummary extends Image{

    constructor(obj?: {
                        id: number, 
                        title: string, 
                        description: string,
                        fileName: string,
                        projectId: number,
                    }){
        super(obj);
        if(obj){
        }
    }
}