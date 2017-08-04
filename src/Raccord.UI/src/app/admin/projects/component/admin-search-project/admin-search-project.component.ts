import { Component, Input } from '@angular/core';
import { Character } from '../../model/character.model';
import { LoadingService } from '../../../../loading/service/loading.service';
import { SearchResult } from '../../../../search/model/search-result.model';
import { EntityType } from '../../../../shared/enums/entity-type.enum';
import { DialogService } from '../../../../shared/service/dialog.service';
import { Project } from "../../../../projects";
import { AdminSearchEngineService } from "../../../search/service/admin-search-engine.service";

@Component({
    selector: 'admin-search-project',
    templateUrl: 'admin-search-project.component.html'
})
export class AdminSearchProjectComponent{

    @Input() searchProject: Project;
    searchResults: SearchResult[] = [];

    constructor(
        private _searchEngineService: AdminSearchEngineService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    clearSearch(){
        this.searchResults = [];
    }

    doSearch(){
        this.searchProject.id = 0;
        if(!this.searchProject.title || this.searchProject.title ===''){
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        
        this._searchEngineService.search({ searchText: this.searchProject.title, includeTypes: [EntityType.project], excludeTypes: []}).then(results=>{
            if(typeof(results)=='string'){
                this._dialogService.error(results);
            }
            else{
                this.searchResults = results[0].results;
                var exactResult = this.searchResults.find(result=> result.displayName.toLowerCase()==this.searchProject.title.toLowerCase());
                if(exactResult)
                    this.searchProject.id = exactResult.id;
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }

    setResult(result: SearchResult){
        this.searchProject.title = result.displayName;
        this.searchProject.id = result.id;
        this.clearSearch();
    }
}