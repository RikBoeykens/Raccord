import { Component, Input } from '@angular/core';
import { SlateSummary } from "../../../shots/slates/model/slate-summary.model";

@Component({
    selector: 'scene-slates',
    templateUrl: 'scene-slates.component.html'
})
export class SceneSlatesComponent{

    @Input() projectId: number;
    @Input() sceneId: number;
    @Input() slates: SlateSummary[];


    constructor(
    ){
    }
}