import { BaseModel } from '../../../../../shared';
import { Slate } from '../../../..';

export class Take extends BaseModel {
    public id: number;
    public number: string;
    public notes: string;
    public length: string;
    public selected: boolean;
    public cameraRoll: string;
    public soundRoll: string;
    public slate: Slate;

    constructor(obj?: {
                        id: number,
                        number: string,
                        notes: string,
                        length: string,
                        selected: boolean,
                        cameraRoll: string,
                        soundRoll: string,
                        slate: Slate
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.number = obj.number;
            this.notes = obj.notes,
            this.length = obj.length;
            this.selected = obj.selected;
            this.cameraRoll = obj.cameraRoll;
            this.soundRoll = obj.soundRoll;
            this.slate = obj.slate;
        } else {
            this.id = 0;
        }
    }
}
