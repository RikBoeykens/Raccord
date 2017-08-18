import { Slate } from "../../slates/model/slate.model";
import { Take } from "./take.model";

export class FullTake extends Take {

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
        super(obj);
    }
}