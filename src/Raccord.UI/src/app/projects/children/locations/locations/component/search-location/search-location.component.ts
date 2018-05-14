import { Component, Input, EventEmitter, Output } from '@angular/core';
import { Location } from '../../model/location.model';
import { SearchResult } from '../../../../../../search/model/search-result.model';
import { SearchEngineService } from '../../../../../../search/service/search-engine.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { EntityType } from '../../../../../../shared/enums/entity-type.enum';

@Component({
    selector: 'search-location',
    templateUrl: 'search-location.component.html'
})
export class SearchLocationComponent{

    @Output() public setLocation = new EventEmitter();
    @Input() public searchLocation: Location;
    @Input() public excludeLocations: Location[] =  [];
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
        this.searchLocation.id = 0;
        if(!this.searchLocation.name || this.searchLocation.name ===''){
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        
        this._searchEngineService.search({
            searchText: this.searchLocation.name,
            includeTypes: [EntityType.location],
            excludeTypes: [],
            projectId: this.searchLocation.projectId,
            excludeTypeIDs: [{
                type: EntityType.location,
                ids: this.excludeLocations.map((location: Location) => location.id)
            }]
        }).then(results=>{
            if(typeof(results)=='string'){
                this._dialogService.error(results);
            }
            else{
                this.searchResults = results[0].results;
                var exactResult = this.searchResults.find(result=> result.displayName.toLowerCase()==this.searchLocation.name.toLowerCase());
                if(exactResult)
                    this.searchLocation.id = exactResult.id;
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }

    setResult(result: SearchResult){
        this.searchLocation.name = result.displayName;
        this.searchLocation.id = result.id;
        this.clearSearch();
        this.setLocation.emit();
    }
}