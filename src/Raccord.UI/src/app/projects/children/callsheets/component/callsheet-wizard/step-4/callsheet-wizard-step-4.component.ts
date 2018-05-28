import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallsheetHttpService } from "../../../service/callsheet-http.service";
import { CallsheetCharacterHttpService } from "../../../children/callsheet-characters/service/callsheet-character-http.service";
import { CharacterCallHttpService } from "../../../children/character-calls/service/character-call-http.service";
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { CallsheetSummary } from "../../../";
import { CallsheetCharacterCharacter } from "../../../";
import { CharacterCallCallType } from "../../../";
import { LinkedCharacter } from "../../../..//characters/model/linked-character.model";
import { TimeHelpers } from "../../../../../../shared/helpers/time.helpers";
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'callsheet-wizard-step-4.component.html',
})
export class CallsheetWizardStep4Component implements OnInit {

    project: ProjectSummary;
    callsheet: CallsheetWrapper;
    characters: CallsheetCharacterWrapper[]=[];

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        private _callsheetHttpService: CallsheetHttpService,
        private _callsheetCharacterHttpService: CallsheetCharacterHttpService,
        private _characterCallHttpService: CharacterCallHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, callsheet: CallsheetSummary, characters: CallsheetCharacterCharacter[] }) => {
            this.project = data.project;
            this.callsheet = new CallsheetWrapper(data.callsheet);
            this.characters = data.characters.map((character)=>new CallsheetCharacterWrapper(character));
        });
    }

    public getCharacters() {
        this._loadingWrapperService.Load(
            this._callsheetCharacterHttpService.getCharacters(this.callsheet.id),
            (data) => this.characters =
                data.map((character) => new CallsheetCharacterWrapper(character))
        );
    }

    updateCall(call: CharacterCallWrapper){
        let loadingId = this._loadingService.startLoading();
        
        call.callTime = TimeHelpers.getTime(call.callTimeString);

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

    goToNextStep(){
         let loadingId = this._loadingService.startLoading();

         this.callsheet.start = TimeHelpers.getTime(this.callsheet.startString);
         this.callsheet.end = TimeHelpers.getTime(this.callsheet.endString);
         this.callsheet.crewCall = TimeHelpers.getTime(this.callsheet.crewCallString);

        this._callsheetHttpService.post(this.callsheet).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._router.navigate(["projects", this.project.id, "callsheets"]);
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );       
    }
}

export class CallsheetWrapper extends CallsheetSummary{
    startString: string;
    endString: string;
    crewCallString: string;
    constructor(obj: CallsheetSummary){
        super(obj);
        this.startString = TimeHelpers.getTimeString(obj.start);
        this.endString = TimeHelpers.getTimeString(obj.end);
        this.crewCallString = TimeHelpers.getTimeString(obj.crewCall);
    }    
}

export class CallsheetCharacterWrapper extends CallsheetCharacterCharacter{
    callWrappers: CharacterCallWrapper[];

    constructor(obj: CallsheetCharacterCharacter){
        super(obj);
        this.callWrappers = obj.calls.map((call: CharacterCallCallType)=> new CharacterCallWrapper(call));
    }
}

export class CharacterCallWrapper extends CharacterCallCallType{
    callTimeString: string;
    
    constructor(obj: CharacterCallCallType){
        super(obj);
        this.callTimeString = TimeHelpers.getTimeString(obj.callTime);
    }
}

