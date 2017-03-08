import { Component, Input, OnInit } from '@angular/core';
import { LinkedCharacter } from '../../../characters/model/linked-character.model';
import { Character } from '../../../characters/model/character.model';
import { CharacterSceneHttpService } from '../../service/character-scene-http.service';
import { CharacterHttpService } from '../../../characters/service/character-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';

@Component({
    selector: 'scene-characters',
    templateUrl: 'scene-characters.component.html'
})
export class SceneCharactersComponent implements OnInit{

    @Input() projectId: number;
    @Input() sceneId: number;
    @Input() characters: LinkedCharacter[];

    viewNewCharacter: Character;
    newCharacter: Character;


    constructor(
        private _characterSceneHttpService: CharacterSceneHttpService,
        private _characterHttpService: CharacterHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
        this.viewNewCharacter = new Character();
    }

    ngOnInit(){
        this.resetNewCharacter();
    }

    getCharacters(){
        let loadingId = this._loadingService.startLoading();

        this._characterSceneHttpService.getCharacters(this.sceneId).then(data => {
            this.characters = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    resetNewCharacter(){
        this.viewNewCharacter = new Character();
        this.viewNewCharacter.projectId = this.projectId;
        this.newCharacter = null;
    }

    addLink(){
        if(this.viewNewCharacter.id!==0){
            this.addCharacterLink(this.viewNewCharacter.id);
        }
        else{
            // first create character, then link it
            let loadingId = this._loadingService.startLoading();

            this.newCharacter = this.viewNewCharacter;

            this._characterHttpService.post(this.newCharacter).then(data=>{
                if(typeof(data)=='string'){
                    this._dialogService.error(data);
                }else{
                    this.addCharacterLink(data);
                }
            }).catch()
            .then(()=>
                this._loadingService.endLoading(loadingId)
            );
        }
    }

    addCharacterLink(characterId: number){
        let loadingId = this._loadingService.startLoading();

        this._characterSceneHttpService.addLink(characterId, this.sceneId).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getCharacters();
                this.resetNewCharacter();
                this._dialogService.success("Successfully added link between character and scene.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeLink(character: LinkedCharacter){
        let loadingId = this._loadingService.startLoading();

        this._characterSceneHttpService.removeLink(character.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getCharacters();
                this._dialogService.success("Successfully removed link between character and scene.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}