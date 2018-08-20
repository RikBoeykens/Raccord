import { ScriptLocation } from './script-location.model';
import { Image } from '../../images';

export class ScriptLocationSummary extends ScriptLocation {
    public sceneCount: number;
    public primaryImage: Image;

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        projectID: number,
                        sceneCount: number,
                        primaryImage: Image
                    }) {
        super(obj);
        if (obj) {
            this.sceneCount = obj.sceneCount;
            this.primaryImage = obj.primaryImage;
        }
    }
}
