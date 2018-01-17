import { Project } from './project.model'
import { Image } from '../children/images/model/image.model';
import { Comment } from '../children/comments/model/comment.model';

export class FullProject extends Project {
    primaryImage: Image;

    constructor(obj?: {id: number, 
                       title: string,
                       primaryImage: Image
                    }){
        super(obj);
        if(obj){
            this.primaryImage = obj.primaryImage;
        }
    }
}