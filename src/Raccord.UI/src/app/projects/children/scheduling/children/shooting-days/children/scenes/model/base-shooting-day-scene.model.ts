import { BaseModel, Completion } from '../../../../../../../../shared';

export class BaseShootingDayScene extends BaseModel {
    public id: number;
    public pageLength: number;
    public timings: string;
    public completion: Completion;
    public callsheetSceneID: number;

    constructor(obj?: {
                        id: number,
                        pageLength: number,
                        timings: string,
                        completion: Completion,
                        callsheetSceneID: number
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.completion = obj.completion;
            this.timings = obj.timings;
            this.pageLength = obj.pageLength;
            this.callsheetSceneID = obj.callsheetSceneID;
        } else {
            this.id = 0;
        }
    }
}
