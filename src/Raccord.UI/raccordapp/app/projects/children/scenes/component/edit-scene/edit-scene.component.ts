import { Component, Input, Output, EventEmitter } from '@angular/core';
import { SceneSummary } from '../../model/scene-summary.model';

@Component({
    selector: 'edit-scene',
    templateUrl: 'edit-scene.component.html'
})
export class EditSceneComponent{

    @Output() submitScene = new EventEmitter();
    @Input() scene: SceneSummary;

    constructor(
    ){
    }

    doSceneSubmit(){
        this.submitScene.emit();
    }

}