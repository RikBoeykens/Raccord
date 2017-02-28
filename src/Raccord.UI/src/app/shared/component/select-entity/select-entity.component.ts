import { Component, Input, Output, EventEmitter } from '@angular/core';
import { SearchEngineService } from '../../../search/service/search-engine.service';
import { LoadingService } from '../../../loading/service/loading.service';
import { SearchResult } from '../../../search/model/search-result.model';
import { SelectedEntity } from '../../model/selected-entity.model';
import { EntityType } from '../../enums/entity-type.enum';
import { DialogService } from '../../service/dialog.service';

@Component({
    selector: 'select-entity',
    templateUrl: 'select-entity.component.html'
})
export class SelectEntityComponent{

    @Input() projectId: number;
    @Input() includeTypes: EntityType[];
    @Input() excludeTypes: EntityType[];
    @Output() entitySelected = new EventEmitter<SelectedEntity>();

    searchText: string;
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
        if(this.searchText ===''){
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        
        this._searchEngineService.search({ searchText: this.searchText, includeTypes: this.includeTypes, excludeTypes: this.excludeTypes, projectId: this.projectId}).then(results=>{
            if(typeof(results)=='string'){
                this._dialogService.error(results);
            }
            else{
                this.searchResults = results[0].results;
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }

    setResult(result: SearchResult){
        var selectedEntity = new SelectedEntity({ entityId: result.id, type: result.type });
        this.entitySelected.emit(selectedEntity);
        this.clearSearch();
    }
}