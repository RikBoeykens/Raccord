import { Component, Input } from '@angular/core';
import { LocationSummary } from '../model/location-summary.model';
import { SearchEngineService } from '../../../../search-engine/service/search-engine.service';
import { LoadingService } from '../../../../loading/service/loading.service';
import { SearchResult } from '../../../../search-engine/model/search-result.model';
import { SearchType } from '../../../../shared/enums/search-type.enum';
import { DialogService } from '../../../../shared/service/dialog.service';

@Component({
    selector: 'search-location',
    templateUrl: 'search-location.component.html'
})
export class SearchLocationComponent{

    @Input() sceneLocation: LocationSummary;
    searchResults: SearchResult[] = [];
    showSearchResults: boolean = false;

    constructor(
        private _searchEngineService: SearchEngineService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    clearSearch(){
        this.searchResults = [];
        this.showSearchResults = false;
    }

    doSearch(){
        this.sceneLocation.id = 0;
        if(!this.sceneLocation.name || this.sceneLocation.name ===''){
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        
        this._searchEngineService.search({ searchText: this.sceneLocation.name, includeTypes: [SearchType.location], excludeTypes: [], projectId: this.sceneLocation.projectId}).then(results=>{
            if(typeof(results)=='string'){
                this._dialogService.error(results);
            }
            else{
                this.searchResults = results[0].results;
                this.showSearchResults = true;
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }

    setResult(result: SearchResult){
        this.sceneLocation.name = result.displayName;
        this.sceneLocation.id = result.id;
        this.clearSearch();
    }
}