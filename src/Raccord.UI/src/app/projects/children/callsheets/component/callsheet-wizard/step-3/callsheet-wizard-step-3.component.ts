import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallsheetSceneHttpService } from "../../../children/callsheet-scenes/service/callsheet-scene-http.service";
import { CallsheetSceneCharacterHttpService } from "../../../children/callsheet-scene-characters/service/callsheet-scene-character-http.service";
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { CallsheetSummary } from "../../../";
import { CallsheetScene } from "../../../";
import { CallsheetSceneCharacters } from "../../../";
import { LinkedCharacter } from "../../../..//characters/model/linked-character.model";

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

    getScenes(){
        let loadingId = this._loadingService.startLoading();

        this._callsheetSceneHttpService.getCharacters(this.callsheet.id).then(data => {
            this.scenes = data.map((scene)=> new CallsheetSceneWrapper(scene));
            this._loadingService.endLoading(loadingId);
        });
    }

    goToNextStep(){

    }

    updateCharacterLink(character: CallsheetSceneCharacterWrapper, callsheetSceneId: number){
        if(character.isLinked&&character.callsheetSceneCharacterId){
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
                this.getScenes();
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
                this.getScenes();
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