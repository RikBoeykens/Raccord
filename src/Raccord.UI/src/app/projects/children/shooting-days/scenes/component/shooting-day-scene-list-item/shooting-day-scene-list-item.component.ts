import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { ShootingDaySceneScene } from "../../model/shooting-day-scene-scene.model";
import { Completion } from "../../../../../../shared/enums/completion.enum";

@Component({
    selector: 'shooting-day-scene-list-item',
    templateUrl: 'shooting-day-scene-list-item.component.html'
})
export class ShootingDaySceneListItem{

    @Output() edit = new EventEmitter();
    @Output() remove = new EventEmitter();
    @Input() shootingDayScene: ShootingDaySceneScene;

    constructor(
    ){
    }

    shootingDayNotStarted(){
        return this.shootingDayScene.completion == Completion.notStarted;
    }

    doEdit(){
        this.edit.emit();
    }

    doRemove(){
        this.remove.emit();
    }
}