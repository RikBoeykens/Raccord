import { CrewUnit } from './crew-unit.model';

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
