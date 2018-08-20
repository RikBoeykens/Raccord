import { BaseModel } from '../../../../../../../../shared';

export class ScheduleDayNote extends BaseModel {
    public id: number;
    public content: string;
    public scheduleDayId: number;

    constructor(obj?: {
                        id: number,
                        content: string,
                        scheduleDayId: number
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.content = obj.content;
            this.scheduleDayId = obj.scheduleDayId;
        } else {
            this.id = 0;
        }
    }
}
