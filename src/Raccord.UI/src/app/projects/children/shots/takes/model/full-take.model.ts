import { Take } from './take.model';
import { Slate } from '../../../..';

export class FullTake extends Take {

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
        super(obj);
    }
}
