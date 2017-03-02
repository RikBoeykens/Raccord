import { Project } from './project.model'
import { Image } from '../children/images/model/image.model';

export class ProjectSummary extends Project {
    primaryImage: Image;

    constructor(obj?: {id: number, 
                       title: string,
                       primaryImage: Image}){
        super(obj);
        if(obj){
            this.primaryImage = obj.primaryImage;
        }
    }
}