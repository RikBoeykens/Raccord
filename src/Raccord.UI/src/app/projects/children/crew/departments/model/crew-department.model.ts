import { BaseModel } from '../../../../../shared/index';

export class CrewDepartment extends BaseModel {
    public id: number;
    public name: string;
    public description: string;
    public crewUnitID: number;

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        crewUnitID: number
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
            this.crewUnitID = obj.crewUnitID;
        } else {
            this.id = 0;
        }
    }
}
