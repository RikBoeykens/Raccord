import { Component, OnInit, OnChanges } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FullScheduleScene } from '../../model/full-schedule-scene.model';
import { ScheduleScene } from '../../model/schedule-scene.model';
import { LinkedCharacter } from '../../../../../children/characters/model/linked-character.model';
import { ScheduleSceneHttpService } from '../../service/schedule-scene-http.service';
import { ScheduleCharacterHttpService } from '../../../schedule-characters/service/schedule-character-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { PageLengthHelpers } from '../../../../../../shared/helpers/page-length.helpers';

@Component({
    templateUrl: 'schedule-scene-landing.component.html',
})
export class ScheduleSceneLandingComponent extends OnInit  implements OnChanges{

    scheduleScene: FullScheduleScene;
    project: ProjectSummary;
    stringPageLength: string;
    characters: LinkedCharacter[] = [];
    scheduleCharacters: ScheduleCharacterWrapper[] = [];

    constructor(
        private _scheduleSceneHttpService: ScheduleSceneHttpService,
        private _scheduleCharacterHttpService: ScheduleCharacterHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
        super();
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scheduleScene: FullScheduleScene, project: ProjectSummary, characters: LinkedCharacter[] }) => {
            this.scheduleScene = data.scheduleScene;
            this.setStringPageLength();
            this.project = data.project;
            this.characters = data.characters;
            this.setScheduleCharacterWrappers();
        });
    }

    ngOnChanges(){
        this.setStringPageLength();
    }

    setStringPageLength(){
        this.stringPageLength = PageLengthHelpers.getPageLengthString(this.scheduleScene.pageLength);
    }

    getScheduleScene(){
        
        let loadingId = this._loadingService.startLoading();

        this._scheduleSceneHttpService.get(this.scheduleScene.id).then(data => {
            this.scheduleScene = data;
            this.setScheduleCharacterWrappers();
            this._loadingService.endLoading(loadingId);
        });
    }

    updateScheduleScene(){
        let loadingId = this._loadingService.startLoading();

        let updatedScheduleScene = new ScheduleScene({
            id: this.scheduleScene.id, 
            pageLength: PageLengthHelpers.getPageLengthNumber(this.stringPageLength),
            sceneId: this.scheduleScene.scene.id,
            scheduleDayId: this.scheduleScene.scheduleDay.id
        });
        this._scheduleSceneHttpService.post(updatedScheduleScene).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScheduleScene();
            }
        }).catch()
        .then(()=>{
            this._loadingService.endLoading(loadingId);
            this.updateScheduleCharacters();
        });
    }

    updateScheduleCharacters(){
        let linksToRemove = this.scheduleCharacters.filter((character)=>!character.isLinked&&character.scheduleCharacterId);
        let linksToAdd = this.scheduleCharacters.filter((character)=> character.isLinked&&!character.scheduleCharacterId);
        
        linksToRemove.forEach((character)=> this.removeScheduleCharacterLink(character));
        linksToAdd.forEach((character)=> this.addScheduleCharacterLink(character));
    }

    removeScheduleCharacterLink(character: ScheduleCharacterWrapper){
        let loadingId = this._loadingService.startLoading();

        this._scheduleCharacterHttpService.removeLink(character.scheduleCharacterId).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScheduleScene();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    addScheduleCharacterLink(character: ScheduleCharacterWrapper){
        let loadingId = this._loadingService.startLoading();

        this._scheduleCharacterHttpService.addLink(this.scheduleScene.id, character.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScheduleScene();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    setScheduleCharacterWrappers(){
        let characters = [];
        for(let sceneCharacter of this.characters){
            let newCharacter = new ScheduleCharacterWrapper(sceneCharacter);
            let existingScheduleCharacters = this.scheduleScene.characters.filter((scheduleCharacter)=> scheduleCharacter.id===sceneCharacter.id);
            if(existingScheduleCharacters.length>0){
                newCharacter.isLinked = true;
                newCharacter.scheduleCharacterId = existingScheduleCharacters[0].linkID;
            }
            characters.push(newCharacter);
        }
        this.scheduleCharacters = characters;
    }
}

export class ScheduleCharacterWrapper extends LinkedCharacter{
    isLinked: boolean;
    scheduleCharacterId: number;
    
    constructor(obj){
        super(obj);
    }
}