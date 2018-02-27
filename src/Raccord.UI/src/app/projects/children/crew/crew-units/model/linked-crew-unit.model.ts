import { CrewUnit } from './crew-unit.model';

export class LinkedCrewUnit extends CrewUnit {
    public linkID: number;

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        projectID: number,
                        linkID: number;
                    }) {
        super(obj);
        if (obj) {
            this.linkID = obj.linkID;
        }
    }
}
