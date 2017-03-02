import { Image } from './image.model';

export class ImageSummary extends Image{
    isPrimary: boolean;

    constructor(obj?: {
                        id: number, 
                        title: string, 
                        description: string,
                        fileName: string,
                        projectId: number,
                        isPrimary: boolean
                    }){
        super(obj);
        if(obj){
            this.isPrimary = obj.isPrimary;
        }
    }
}