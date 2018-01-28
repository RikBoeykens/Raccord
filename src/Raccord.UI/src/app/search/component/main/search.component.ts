import { Component } from '@angular/core';
import { SearchEngineService } from '../../service/search-engine.service';
import { LoadingService } from '../../../loading/service/loading.service';
import { SearchTypeResult } from '../../model/search-type-result.model';
import { EntityType } from '../../../shared/enums/entity-type.enum';
import { DialogService } from '../../../shared/service/dialog.service';

@Component({
    styleUrls: ['search.component.css'],
    templateUrl: 'search.component.html',
})
export class SearchComponent {
    searchText: string;
    searchTypeResults: SearchTypeResult[] = [];
    showSearchResults: boolean = false;
    
    constructor(
        private _searchEngineService: SearchEngineService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    clearSearchBar(){
        this.searchText = "";
        this.searchTypeResults = [];
        this.showSearchResults = false;
    }

    doSearch(){
        if(this.searchText===''){
            this.clearSearchBar();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        
        this._searchEngineService.search({ searchText: this.searchText, includeTypes: [], excludeTypes: [EntityType.dayNight, EntityType.intExt], excludeTypeIDs: []}).then(results=>{
            if(typeof(results)=='string'){
                this._dialogService.error(results);
            }
            else{
                this.searchTypeResults = results.filter(typeResult=> typeResult.count>0);
                this.showSearchResults = true;
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }
}