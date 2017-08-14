import {Component, Inject} from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { SceneSummary } from "../../model/scene-summary.model";

@Component({
    selector: 'choose-scene-dialog',
    templateUrl: "choose-scene-dialog.component.html",
})

export class ChooseSceneDialog {

    scenes: SceneSummary[] = [];

    constructor(
        private _dialogRef: MdDialogRef<ChooseSceneDialog>,
        @Inject(MD_DIALOG_DATA) private data: SceneSummary[]
    ) { 
        this.scenes = data;
    }

    chooseScene(scene: SceneSummary){
        this._dialogRef.close(scene);
    }
}