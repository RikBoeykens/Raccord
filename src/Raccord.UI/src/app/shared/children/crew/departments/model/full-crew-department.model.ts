import { CrewDepartment } from './crew-department.model';
import { CrewMemberSummary } from '../..';

export class FullCrewDepartment extends CrewDepartment {
  public id: number;
  public name: string;
  public description: string;
  public crewUnitID: number;
  public crewMembers: CrewMemberSummary[];

  constructor(
    obj?: {
    id: number,
    name: string,
    description: string,
    crewUnitID: number,
    crewMembers: CrewMemberSummary[]
  }) {
      super(obj);
      if (obj) {
          this.crewMembers = obj.crewMembers;
      }
  }
}
