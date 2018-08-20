import { CrewUnit, CrewMember } from '../..';

export class ProjectLinkCrewUnit extends CrewUnit {
  public linkID: number;
  public crewMembers: CrewMember[];

  constructor(obj?: {
                      id: number,
                      name: string,
                      description: string,
                      projectID: number,
                      linkID: number;
                      crewMembers: CrewMember[]
                  }) {
      super(obj);
      if (obj) {
          this.linkID = obj.linkID;
          this.crewMembers = obj.crewMembers;
      }
  }
}
