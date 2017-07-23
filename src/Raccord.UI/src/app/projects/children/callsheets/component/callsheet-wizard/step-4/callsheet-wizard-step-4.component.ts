import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallsheetCharacterHttpService } from "../../../children/callsheet-characters/service/callsheet-character-http.service";
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { CallsheetSummary } from "../../../";
import { CallsheetCharacterCharacter } from "../../../";
import { LinkedCharacter } from "../../../..//characters/model/linked-character.model";

@Component({
    templateUrl: 'callsheet-wizard-step-4.component.html',
})
export class CallsheetWizardStep4Component implements OnInit {

    project: ProjectSummary;
    callsheet: CallsheetSummary;
    characters: CallsheetCharacterCharacter[]=[];

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        private _callsheetCharacterHttpService: CallsheetCharacterHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, callsheet: CallsheetSummary, characters: CallsheetCharacterCharacter[] }) => {
            this.project = data.project;
            this.callsheet = data.callsheet;
            this.characters = data.characters;
        });
    }
}