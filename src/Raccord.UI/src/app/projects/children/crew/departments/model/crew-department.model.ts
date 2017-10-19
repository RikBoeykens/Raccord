import { BaseModel } from "../../../../../shared/index";

export class CrewDepartment extends BaseModel {
    id: number;
    name: string;
    description: string;
    projectId: number;

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        projectId: number
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
            this.projectId = obj.projectId;
        }
        else {
            this.id = 0;
        }
    }
}