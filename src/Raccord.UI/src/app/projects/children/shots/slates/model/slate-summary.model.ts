import { Slate } from './slate.model';
import { Image } from '../../../../../shared/children/images';
import { Scene } from '../../../../../shared/children/scenes';
import { ShootingDay } from '../../../..';

export class SlateSummary extends Slate {
    public takeCount: number;
    public primaryImage: Image;

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
                        takeCount: number,
                        primaryImage: Image
                    }) {
        super(obj);
        if (obj) {
            this.takeCount = obj.takeCount;
            this.primaryImage = obj.primaryImage;
        }
    }
}
