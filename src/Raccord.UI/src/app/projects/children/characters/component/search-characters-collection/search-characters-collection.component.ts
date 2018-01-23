import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Character } from '../../model/character.model';
import { SearchEngineService } from '../../../../../search/service/search-engine.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { SearchResult } from '../../../../../search/model/search-result.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    selector: 'search-characters-collection',
    templateUrl: 'search-characters-collection.component.html'
})
export class SearchCharactersCollectionComponent{

    @Output() public onChange = new EventEmitter();
    @Input() public projectID: number;
    public searchCharacter: Character = new Character();
    public characters: Character[] = [];


    public ngOnInit () {
        this.resetSearchCharacter();
    }
    public addCharacter() {
        this.characters.push(this.searchCharacter);
        this.resetSearchCharacter();
        this.onChange.emit(this.characters);
    }

    public removeCharacter(toRemove: Character) {
        this.characters = this.characters.filter((character) => character.id !== toRemove.id);
        this.onChange.emit(this.characters);
    }

    private resetSearchCharacter() {
        this.searchCharacter = new Character();
        this.searchCharacter.projectId = this.projectID;
    }
}
