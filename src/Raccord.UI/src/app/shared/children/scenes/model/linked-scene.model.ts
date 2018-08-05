import { SceneSummary } from './scene-summary.model';
import { SceneIntro, TimeOfDay } from '../../sceneproperties';
import { ScriptLocation } from '../../script-locations';
import { Image } from '../../images';

export class LinkedScene extends SceneSummary {
    public linkID: number;

    constructor(obj?: {
                        id: number,
                        number: string,
                        summary: string,
                        pageLength: number,
                        timing: string,
                        sceneIntro: SceneIntro,
                        scriptLocation: ScriptLocation,
                        timeOfDay: TimeOfDay,
                        projectId: number,
                        primaryImage: Image,
                        linkID: number
                    }) {
        super(obj);
        if (obj) {
            this.linkID = obj.linkID;
        }
    }
}
