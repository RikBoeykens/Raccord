import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallsheetCharacterHttpService } from "../../../children/callsheet-characters/service/callsheet-character-http.service";
import { CharacterCallHttpService } from "../../../children/character-calls/service/character-call-http.service";
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { CallsheetSummary } from "../../../";
import { CallsheetCharacterCharacter } from "../../../";
import { CharacterCall } from "../../../";
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
        private _characterCallHttpService: CharacterCallHttpService,
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

    getCharacters(){
        let loadingId = this._loadingService.startLoading();

        this._callsheetCharacterHttpService.getCharacters(this.callsheet.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.characters = data;
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    updateCall(call: CharacterCall){
        let loadingId = this._loadingService.startLoading();

        this._characterCallHttpService.post(call).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}