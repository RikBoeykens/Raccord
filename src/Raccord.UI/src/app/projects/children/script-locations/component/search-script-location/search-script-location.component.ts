import { Component, Input } from '@angular/core';
import { ScriptLocation } from '../../model/script-location.model';
import { SearchEngineService } from '../../../../../search/service/search-engine.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { SearchResult } from '../../../../../search/model/search-result.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    selector: 'search-script-location',
    templateUrl: 'search-script-location.component.html'
})
export class SearchScriptLocationComponent{

    @Input() sceneScriptLocation: ScriptLocation;
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
        this.sceneScriptLocation.id = 0;
        if(!this.sceneScriptLocation.name || this.sceneScriptLocation.name ===''){
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        this._searchEngineService.search({ searchText: this.sceneScriptLocation.name, includeTypes: [EntityType.scriptLocation], excludeTypes: [], projectId: this.sceneScriptLocation.projectID}).then(results=>{
            if(typeof(results)=='string'){
                this._dialogService.error(results);
            }
            else{
                this.searchResults = results[0].results;
                var exactResult = this.searchResults.find(result=> result.displayName.toLowerCase()==this.sceneScriptLocation.name.toLowerCase());
                if(exactResult)
                    this.sceneScriptLocation.id = exactResult.id;
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }

    setResult(result: SearchResult){
        this.sceneScriptLocation.name = result.displayName;
        this.sceneScriptLocation.id = result.id;
        this.clearSearch();
    }
}