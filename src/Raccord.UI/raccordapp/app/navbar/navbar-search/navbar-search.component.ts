import { Component, Output, EventEmitter, ViewChild, Directive, ElementRef } from '@angular/core';
import { SearchEngineService } from '../../search-engine/service/search-engine.service';
import { LoadingService } from '../../loading/service/loading.service';
import { SearchTypeResult } from '../../search-engine/model/search-type-result.model';
import { SearchType } from '../../shared/enums/search-type.enum';
import { DialogService } from '../../shared/service/dialog.service';

@Component({
    selector: 'raccord-navbar-search',
    templateUrl: 'navbar-search.component.html',
})
export class NavbarSearchComponent {
    @Output() toggleSearchBar = new EventEmitter<boolean>();
    searchText: string;
    searchTypeResults: SearchTypeResult[] = [];
    showSearchResults: boolean = false;
    
    constructor(
        private _searchEngineService: SearchEngineService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    resetSearchBar(){
        this.toggleSearchBar.emit(false);
        this.clearSearchBar();
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
        
        this._searchEngineService.search({ searchText: this.searchText, includeTypes: [], excludeTypes: [SearchType.dayNight, SearchType.intExt]}).then(results=>{
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