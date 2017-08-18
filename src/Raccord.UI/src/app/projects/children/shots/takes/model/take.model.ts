import { BaseModel } from '../../../../../shared/model/base.model';
import { Slate } from "../../slates/model/slate.model";

export class Take extends BaseModel {
    id: number;
    number: string;
    notes: string;
    length: string;
    selected: Boolean;
    cameraRoll: string;
    soundRoll: string;
    slate: Slate;

    constructor(obj?: {
                        id: number,
                        number: string,
                        notes: string,
                        length: string,
                        selected: Boolean,
                        cameraRoll: string,
                        soundRoll: string,
                        slate: Slate
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.number = obj.number;
            this.notes = obj.notes,
            this.length = obj.length;
            this.selected = obj.selected;
            this.cameraRoll = obj.cameraRoll;
            this.soundRoll = obj.soundRoll;
            this.slate = obj.slate;
        }
        else{
            this.id = 0;
        }
    }
}