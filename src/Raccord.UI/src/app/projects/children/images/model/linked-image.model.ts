import { Image } from './image.model';

export class LinkedImage extends Image{
    linkID: number;
    isPrimaryImage: boolean;

    constructor(obj?: {
                        id: number, 
                        title: string, 
                        description: string,
                        fileName: string,
                        projectId: number,
                        linkID: number,
                        isPrimaryImage: boolean
                    }){
        super(obj);
        if(obj){
            this.linkID = obj.linkID;
            this.isPrimaryImage = obj.isPrimaryImage;
        }
    }
}