import {Component, Inject} from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { ShootingDaySceneScene } from "../../model/shooting-day-scene-scene.model";
import { PageLengthHelpers } from '../../../../../../shared/helpers/page-length.helpers';

@Component({
    selector: 'edit-shooting-day-scene-dialog',
    templateUrl: "edit-shooting-day-scene-dialog.component.html",
})

export class EditShootingDaySceneDialog {
    shootingDayScene: ShootingDaySceneWrapper;

    constructor(
        private _dialogRef: MdDialogRef<EditShootingDaySceneDialog>,
        @Inject(MD_DIALOG_DATA) private data: ShootingDaySceneScene
    ) { 
        this.shootingDayScene = new ShootingDaySceneWrapper(data);
    }

    submit(){
        this.shootingDayScene.pageLength = PageLengthHelpers.getPageLengthNumber(this.shootingDayScene.pageLengthString);
        console.log(this.shootingDayScene.pageLength);
        console.log(this.shootingDayScene.pageLengthString);
        this._dialogRef.close(new ShootingDaySceneScene(this.shootingDayScene));
    }
}
class ShootingDaySceneWrapper extends ShootingDaySceneScene{
    pageLengthString: string;

    constructor(shootingDayScene: ShootingDaySceneScene){
        super(shootingDayScene);
        this.pageLengthString = PageLengthHelpers.getPageLengthString(shootingDayScene.pageLength);
    }
}