import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Character } from '../../model/character.model';
import { SearchEngineService } from '../../../../../search/service/search-engine.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { SearchResult } from '../../../../../search/model/search-result.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    selector: 'search-character',
    templateUrl: 'search-character.component.html'
})
export class SearchCharacterComponent{

    @Output() public setCharacter = new EventEmitter();
    @Input() searchCharacter: Character;
    searchResults: SearchResult[] = [];

    constructor(
        private _searchEngineService: SearchEngineService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    clearSearch(){
        this.searchResults = [];
    }

    doSearch(){
        this.searchCharacter.id = 0;
        if(!this.searchCharacter.name || this.searchCharacter.name ===''){
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        
        this._searchEngineService.search({ searchText: this.searchCharacter.name, includeTypes: [EntityType.character], excludeTypes: [], projectId: this.searchCharacter.projectId}).then(results=>{
            if(typeof(results)=='string'){
                this._dialogService.error(results);
            }
            else{
                this.searchResults = results[0].results;
                var exactResult = this.searchResults.find(result=> result.displayName.toLowerCase()==this.searchCharacter.name.toLowerCase());
                if(exactResult)
                    this.searchCharacter.id = exactResult.id;
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }

    setResult(result: SearchResult){
        this.searchCharacter.name = result.displayName;
        this.searchCharacter.id = result.id;
        this.clearSearch();
        this.setCharacter.emit();
    }
}