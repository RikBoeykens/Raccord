import { BaseModel } from '../../../../../shared/model/base.model';
import { Scene } from '../../../scenes/model/scene.model';

export class ScheduleSceneScene extends BaseModel{
    id: number;
    pageLength: number;
    scene: Scene;

    constructor(obj?: {
                        id: number, 
                        pageLength: number, 
                        scene: Scene
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.scene = obj.scene;
        }
        else{
            this.id = 0;
        }
    }
}