import { Component, Input } from '@angular/core';
import { DayNight } from '../../model/day-night.model';
import { SearchEngineService } from '../../../../../search/service/search-engine.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { SearchResult } from '../../../../../search/model/search-result.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    selector: 'search-day-night',
    templateUrl: 'search-day-night.component.html'
})
export class SearchDayNightComponent{

    @Input() sceneDayNight: DayNight;
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
        this.sceneDayNight.id = 0;
        if(!this.sceneDayNight.name || this.sceneDayNight.name ===''){
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        
        this._searchEngineService.search({ searchText: this.sceneDayNight.name, includeTypes: [EntityType.dayNight], excludeTypes: [], projectId: this.sceneDayNight.projectId}).then(results=>{
            if(typeof(results)=='string'){
                this._dialogService.error(results);
            }
            else{
                this.searchResults = results[0].results;
                var exactResult = this.searchResults.find(result=> result.displayName.toLowerCase()==this.sceneDayNight.name.toLowerCase());
                if(exactResult)
                    this.sceneDayNight.id = exactResult.id;
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