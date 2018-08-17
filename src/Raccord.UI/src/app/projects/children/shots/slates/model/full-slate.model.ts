import { Slate } from './slate.model';
import { LinkedImage } from '../../../../../shared/children/images';
import { Scene } from '../../../../../shared/children/scenes';
import { ShootingDay, Take, Comment } from '../../../..';

export class FullSlate extends Slate {
    public takes: Take[];
    public images: LinkedImage[];
    public comments: Comment[];

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
                        takes: Take[],
                        images: LinkedImage[],
                        comments: Comment[]
                    }) {
        super(obj);
        if (obj) {
            this.takes = obj.takes;
            this.images = obj.images;
            this.comments = obj.comments;
        } else {
            this.id = 0;
        }
    }
}
