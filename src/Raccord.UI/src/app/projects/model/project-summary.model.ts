import { Project } from './project.model';
import { Image } from '../children/images/model/image.model';

export class ProjectSummary extends Project {
    public primaryImage: Image;
    public publishedSchedule: boolean;

    constructor(obj?: {id: number,
                       title: string,
                       primaryImage: Image,
                       publishedSchedule: boolean
                    }) {
        super(obj);
        if (obj) {
            this.primaryImage = obj.primaryImage;
            this.publishedSchedule = obj.publishedSchedule;
        }
    }
}
