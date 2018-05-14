import { Component, Input, Output, EventEmitter } from '@angular/core';
import { IntExt } from '../../model/int-ext.model';
import { SearchEngineService } from '../../../../../search/service/search-engine.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { SearchResult } from '../../../../../search/model/search-result.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    selector: 'search-int-ext',
    templateUrl: 'search-int-ext.component.html'
})
export class SearchIntExtComponent {

    @Output() public setIntExt = new EventEmitter();
    @Input() public sceneIntExt: IntExt;
    @Input() public excludeIntExts: IntExt[] =  [];
    public searchResults: SearchResult[] = [];

    constructor(
        private _searchEngineService: SearchEngineService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ) {
    }

    public clearSearch() {
        this.searchResults = [];
    }

    public doSearch() {
        this.sceneIntExt.id = 0;
        if (!this.sceneIntExt.name || this.sceneIntExt.name === '') {
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();

        this._searchEngineService.search({
            searchText: this.sceneIntExt.name,
            includeTypes: [EntityType.intExt],
            excludeTypes: [],
            projectId: this.sceneIntExt.projectId,
            excludeTypeIDs: [{
                type: EntityType.intExt,
                ids: this.excludeIntExts.map((intExt: IntExt) => intExt.id)
            }]}).then(results=>{
            if(typeof(results)=='string'){
                this._dialogService.error(results);
            }
            else{
                this.searchResults = results[0].results;
                var exactResult = this.searchResults.find(result=> result.displayName.toLowerCase()==this.sceneIntExt.name.toLowerCase());
                if(exactResult)
                    this.sceneIntExt.id = exactResult.id;
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }

    setResult(result: SearchResult){
        this.sceneIntExt.name = result.displayName;
        this.sceneIntExt.id = result.id;
        this.clearSearch();
        this.setIntExt.emit();
    }
}