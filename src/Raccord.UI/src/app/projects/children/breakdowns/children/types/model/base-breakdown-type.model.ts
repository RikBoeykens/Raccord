import { BaseModel } from '../../../../../../shared';

export class BaseBreakdownType extends BaseModel {
    public id: number;
    public name: string;
    public description: string;

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
        } else {
            this.id = 0;
        }
    }
}
