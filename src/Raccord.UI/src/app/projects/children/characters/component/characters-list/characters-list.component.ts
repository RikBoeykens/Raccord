import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CharacterHttpService } from '../../service/character-http.service';
import { CharacterSummary } from '../../model/character-summary.model';
import { Character } from '../../model/character.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';

@Component({
    templateUrl: 'characters-list.component.html',
})
export class CharactersListComponent extends OnInit {

    characters: CharacterDroppableWrapper[] = [];
    deleteCharacters: CharacterDroppableWrapper[]=[];
    project: ProjectSummary;
    viewNewCharacter: Character;
    newCharacter: Character;
    draggingToMerge: boolean;
    draggingToDelete: boolean;

    constructor(
        private _characterHttpService: CharacterHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private dragulaService: DragulaService
    ) {
        super();
        this.viewNewCharacter = new Character();

        dragulaService.drag.subscribe((value) => {
            this.onCharacterDrag(value.splice(1));
        });
        dragulaService.dragend.subscribe(() => {
            this.onCharacterDragEnd();
        });
        dragulaService.dropModel.subscribe((value) => {
            this.onCharacterDrop(value.slice(1));
        });
        dragulaService.over.subscribe((value) => {
            this.onOver(value.slice(1));
        });
        dragulaService.out.subscribe((value) => {
            this.onOut(value.slice(1));
        });
        const bag: any = this.dragulaService.find('character-bag');
        if (bag !== undefined ) this.dragulaService.destroy('character-bag');
        dragulaService.setOptions('character-bag', {
            moves: function (el, container, handle) {
                return HtmlClassHelpers.hasClass(handle, 'drag-handle');
            }
        });
    }

    ngOnInit() {
        this._route.data.subscribe((data: { characters: CharacterSummary[], project: ProjectSummary }) => {
            this.characters = data.characters.map(function(character){ return new CharacterDroppableWrapper(character); });
            this.project = data.project;
            this.resetNewCharacter();
        });
    }

    resetNewCharacter(){
        this.viewNewCharacter = new Character();
        this.viewNewCharacter.projectId = this.project.id;
        this.newCharacter = null;
    }

    getCharacters(){
        
        let loadingId = this._loadingService.startLoading();

        this._characterHttpService.getAll(this.project.id).then(data => {
            this.characters = data.map(function(character){ return new CharacterDroppableWrapper(character); });
            this._loadingService.endLoading(loadingId);
        });
    }

    addCharacter(){
        let loadingId = this._loadingService.startLoading();

        this.newCharacter = this.viewNewCharacter;

        this._characterHttpService.post(this.newCharacter).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getCharacters();
                this.resetNewCharacter();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    private onCharacterDrag(args) {
        let draggedElement = args[0];
        this.draggingToMerge = true;
        if(draggedElement && HtmlClassHelpers.hasClass(draggedElement, 'can-delete'))
            this.draggingToDelete = true;
    }
    private onCharacterDragEnd() {
        this.draggingToMerge = false;
        this.draggingToDelete = false;
    }
    private onCharacterDrop(args) {

        // Delete if necessary
        if(this.deleteCharacters.length > 0)
            this.remove(this.deleteCharacters.splice(0, 1)[0].character);

        // Merge if necessary
        var mergeCharacterWrapper;
        this.characters.forEach(function(characterWrapper){
            if(characterWrapper.dropCharacters.length){
                mergeCharacterWrapper = characterWrapper;
            }
        });
        if(mergeCharacterWrapper)
            this.merge(mergeCharacterWrapper.character, mergeCharacterWrapper.dropCharacters.splice(0, 1)[0].character);
    }
    
    private onOver(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.addClass(el, 'hovering');
    }

    private onOut(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.removeClass(el, 'hovering');
    }

    remove(character: CharacterSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove character ${character.name}?`)){

            let loadingId = this._loadingService.startLoading();

            this._characterHttpService.delete(character.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getCharacters();
                }else{
                    this._dialogService.success('The character was successfully removed');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getCharacters();
        }

    }

    merge(toCharacter: CharacterSummary, mergeCharacter: CharacterSummary){
        if(this._dialogService.confirm(`Are you sure you want to merge character ${mergeCharacter.name} to character ${toCharacter.name}?`)){
            let loadingId = this._loadingService.startLoading();

            this._characterHttpService.merge(toCharacter.id, mergeCharacter.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getCharacters();
                }else{
                    toCharacter.sceneCount += mergeCharacter.sceneCount;
                    this._dialogService.success('The characters were successfully merged');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getCharacters();
        }
    }
}

export class CharacterDroppableWrapper{
    character: CharacterSummary;
    dropCharacters: CharacterSummary[] = [];

    constructor(character: CharacterSummary){
        this.character = character;
    }
}