import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallsheetSceneHttpService } from "../../../children/callsheet-scenes/service/callsheet-scene-http.service";
import { CallsheetSceneCharacterHttpService } from "../../../children/callsheet-scene-characters/service/callsheet-scene-character-http.service";
import { CallsheetCharacterHttpService } from "../../../children/callsheet-characters/service/callsheet-character-http.service";
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { CallsheetSummary } from "../../../";
import { CallsheetScene } from "../../../";
import { CallsheetSceneCharacters } from "../../../";
import { LinkedCharacter } from "../../../..//characters/model/linked-character.model";
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'callsheet-wizard-step-3.component.html',
})
export class CallsheetWizardStep3Component implements OnInit {

    project: ProjectSummary;
    callsheet: CallsheetSummary;
    scenes: CallsheetSceneWrapper[] = [];

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        private _callsheetSceneHttpService: CallsheetSceneHttpService,
        private _callsheetSceneCharacterHttpService: CallsheetSceneCharacterHttpService,
        private _callsheetCharacterHttpService: CallsheetCharacterHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, callsheet: CallsheetSummary, scenes: CallsheetSceneCharacters[] }) => {
            this.project = data.project;
            this.callsheet = data.callsheet;
            this.scenes = data.scenes.map((scene)=> new CallsheetSceneWrapper(scene));
        });
    }

    public getScenes() {
        this._loadingWrapperService.Load(
            this._callsheetSceneHttpService.getCharacters(this.callsheet.id),
            (data) => this.scenes = data.map((scene) => new CallsheetSceneWrapper(scene))
        );
    }

    goToNextStep(){
        let loadingId = this._loadingService.startLoading();

        this._callsheetCharacterHttpService.setCharacters(this.callsheet.id, this.project.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._router.navigateByUrl(`/projects/${this.project.id}/callsheets/${this.callsheet.id}/wizard/4`)
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    updateCharacterLink(character: CallsheetSceneCharacterWrapper, callsheetSceneId: number){
        if(!character.isLinked&&character.callsheetSceneCharacterId){
            this.removeScheduleCharacterLink(character);
        }else{
            this.addScheduleCharacterLink(character, callsheetSceneId);
        }
    }

    removeScheduleCharacterLink(character: CallsheetSceneCharacterWrapper){
        let loadingId = this._loadingService.startLoading();

        this._callsheetSceneCharacterHttpService.removeLink(character.callsheetSceneCharacterId).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                character.callsheetSceneCharacterId = null;
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    addScheduleCharacterLink(character: CallsheetSceneCharacterWrapper, callsheetSceneId: number){
        let loadingId = this._loadingService.startLoading();

        this._callsheetSceneCharacterHttpService.addLink(callsheetSceneId, character.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                character.callsheetSceneCharacterId = data;
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}

export class CallsheetSceneWrapper extends CallsheetSceneCharacters{
    characterWrappers: CallsheetSceneCharacterWrapper[];
    constructor(obj){
        super(obj);
        let characters = [];
        for(let sceneCharacter of this.availableCharacters){
            let newCharacter = new CallsheetSceneCharacterWrapper(sceneCharacter);
            let existingCallsheetSceneCharacters = this.characters.filter((callsheetSceneCharacter)=> callsheetSceneCharacter.id===sceneCharacter.id);
            if(existingCallsheetSceneCharacters.length>0){
                newCharacter.isLinked = true;
                newCharacter.callsheetSceneCharacterId = existingCallsheetSceneCharacters[0].linkID;
            }
            characters.push(newCharacter);
        }
        this.characterWrappers = characters;
    }    
}

export class CallsheetSceneCharacterWrapper extends LinkedCharacter{
    isLinked: boolean;
    callsheetSceneCharacterId: number;
    
    constructor(obj){
        super(obj);
    }
}