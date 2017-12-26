import { BaseSceneComponent } from './base-scene-component.model';

export class SceneAction extends BaseSceneComponent {
    constructor(obj?: {
                      text: string,
                      order: number,
                      type: string
                    }) {
        super(obj);
    }
}
