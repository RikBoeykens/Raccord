import { Component, Input } from '@angular/core';
import { DayNightSummary } from '../model/day-night-summary.model';
import { SearchEngineService } from '../../../../search-engine/service/search-engine.service';
import { LoadingService } from '../../../../loading/service/loading.service';
import { SearchResult } from '../../../../search-engine/model/search-result.model';
import { SearchType } from '../../../../shared/enums/search-type.enum';
import { DialogService } from '../../../../shared/service/dialog.service';

@Component({
    selector: 'search-day-night',
    templateUrl: 'search-day-night.component.html'
})
export class SearchDayNightComponent{

    @Input() sceneDayNight: DayNightSummary;
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
        this.sceneDayNight.id = 0;
        if(!this.sceneDayNight.name || this.sceneDayNight.name ===''){
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        
        this._searchEngineService.search({ searchText: this.sceneDayNight.name, includeTypes: [SearchType.dayNight], excludeTypes: [], projectId: this.sceneDayNight.projectId}).then(results=>{
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
        this.sceneDayNight.name = result.displayName;
        this.sceneDayNight.id = result.id;
        this.clearSearch();
    }
}