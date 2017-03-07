import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { Character } from '../../model/character.model';

@Component({
    selector: 'edit-character',
    templateUrl: 'edit-character.component.html'
})
export class EditCharacterComponent{

    @Output() submitCharacter = new EventEmitter();
    @Input() character: Character;

    constructor(
    ){
    }

    doCharacterSubmit(){
        this.submitCharacter.emit();
    }
}