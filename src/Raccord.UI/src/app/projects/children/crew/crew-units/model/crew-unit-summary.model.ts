import { CrewUnit } from './crew-unit.model';

export class CrewUnitSummary extends CrewUnit {
    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        projectID: number
                    }) {
        super(obj);
    }
}
