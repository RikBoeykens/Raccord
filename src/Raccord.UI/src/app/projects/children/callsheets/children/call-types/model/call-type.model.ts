import { BaseModel } from '../../../../../../shared';

export class CallType extends BaseModel {
    public id: number;
    public shortName: string;
    public name: string;
    public description: string;
    public projectID: number;

    constructor(
        obj?: {
        id: number,
        shortName: string,
        name: string,
        description: string,
        projectID: number
    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.shortName = obj.shortName;
            this.name = obj.name;
            this.description = obj.description;
            this.projectID = obj.projectID;
        } else {
            this.id = 0;
        }
    }
}
