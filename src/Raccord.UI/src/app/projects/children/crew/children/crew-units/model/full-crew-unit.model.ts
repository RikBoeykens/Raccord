import { CrewUnit } from '../../../../../../shared/children/crew';

export class FullCrewUnit extends CrewUnit {
  constructor(obj?: {
                      id: number,
                      name: string,
                      description: string,
                      projectID: number
                  }) {
      super(obj);
  }
}
