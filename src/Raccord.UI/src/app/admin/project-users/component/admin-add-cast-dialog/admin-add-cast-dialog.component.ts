import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { CharacterSummary } from
    '../../../../projects/children/characters/model/character-summary.model';

@Component({
    selector: 'admin-add-cast-dialog',
    templateUrl: 'admin-add-cast-dialog.component.html',
})

export class AdminAddCastDialogComponent {

    public characters: CharacterSummary[];

    constructor(
        private _dialogRef: MdDialogRef<AdminAddCastDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: {
            characters: CharacterSummary[]
        }
    ) {
        this.characters = data.characters;
    }

    public chooseCharacter(character: CharacterSummary) {
        this._dialogRef.close(character);
    }
}
