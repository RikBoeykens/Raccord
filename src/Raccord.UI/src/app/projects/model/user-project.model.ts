import { Image } from '../children/images/model/image.model';
import { ProjectSummary } from './project-summary.model';
import { CrewMember } from '../children/crew/crew-members/model/crew-member.model';

export class UserProject extends ProjectSummary {
    crewMembers: CrewMember[];

    constructor(obj?: {id: number, 
                       title: string,
                       primaryImage: Image,
                       crewMembers: CrewMember[]
                    }){
        super(obj);
        if(obj){
            this.crewMembers = obj.crewMembers;
        }
    }
}