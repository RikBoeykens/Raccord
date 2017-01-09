import { Component, Input } from '@angular/core';
import { IntExtSummary } from '../model/int-ext-summary.model';
import { SearchEngineService } from '../../../../search-engine/service/search-engine.service';
import { LoadingService } from '../../../../loading/service/loading.service';
import { SearchResult } from '../../../../search-engine/model/search-result.model';
import { SearchType } from '../../../../shared/enums/search-type.enum';
import { DialogService } from '../../../../shared/service/dialog.service';

@Component({
    selector: 'search-int-ext',
    templateUrl: 'search-int-ext.component.html'
})
export class SearchIntExtComponent{

    @Input() sceneIntExt: IntExtSummary;
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
        this.sceneIntExt.id = 0;
        if(!this.sceneIntExt.name || this.sceneIntExt.name ===''){
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        
        this._searchEngineService.search({ searchText: this.sceneIntExt.name, includeTypes: [SearchType.intExt], excludeTypes: [], projectId: this.sceneIntExt.projectId}).then(results=>{
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
        this.sceneIntExt.name = result.displayName;
        this.sceneIntExt.id = result.id;
        this.clearSearch();
    }
}