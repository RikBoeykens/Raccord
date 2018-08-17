import { Slate } from './slate.model';
import { Scene } from '../../../../../shared/children/scenes';
import { ShootingDay } from '../../../..';

export class LinkedSlate extends Slate {
    public linkID: number;

    constructor(obj?: {
                        id: number,
                        number: string,
                        description: string,
                        lens: string,
                        distance: string,
                        aperture: string,
                        filters: string,
                        sound: string,
                        isVfx: boolean,
                        projectID: number,
                        scene?: Scene,
                        shootingDay?: ShootingDay,
                        linkID: number
                    }) {
        super(obj);
        if (obj) {
            this.linkID = obj.linkID;
        }
    }
}
