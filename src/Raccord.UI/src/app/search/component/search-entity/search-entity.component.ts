import { Component, Input, Output, EventEmitter } from '@angular/core';
import { EntityType } from '../../../shared/enums/entity-type.enum';
import { SearchResult } from '../../model/search-result.model';
import { SearchEngineService } from '../../service/search-engine.service';
import { LoadingWrapperService } from '../../../shared/service/loading-wrapper.service';
import { SearchTypeResult } from '../../model/search-type-result.model';
import { SearchEntity } from '../../model/search-entity.model';

@Component({
    selector: 'search-entity',
    templateUrl: 'search-entity.component.html'
})
export class SearchEntityComponent {

    @Output() public setEntity = new EventEmitter();
    @Input() public projectId: number;
    @Input() public searchEntity: SearchEntity;
    @Input() public entityType: EntityType;
    @Input() public entityTypeName: string;
    @Input() public excludeEntities: SearchEntity[] =  [];
    public searchResults: SearchResult[] = [];

    constructor(
        private _searchEngineService: SearchEngineService,
        private _loadingWrapperService: LoadingWrapperService
    ) {
    }

    public clearSearch() {
        this.searchResults = [];
    }

    public doSearch() {
        if (!this.searchEntity.name || this.searchEntity.name === '') {
            this.clearSearch();
            return;
        }

        this._loadingWrapperService.Load(
            this._searchEngineService.search({
                searchText: this.searchEntity.name,
                includeTypes: [this.entityType],
                excludeTypes: [],
                projectId: this.projectId,
                excludeTypeIDs: [{
                    type: this.entityType,
                    ids: this.excludeEntities.map((entity: SearchEntity) => entity.id)
                }]
            }),
            (results: SearchTypeResult) => {
                this.searchResults = results[0].results;
            }
        );
    }

    public setResult(result: SearchResult) {
        this.searchEntity.name = result.displayName;
        this.searchEntity.id = result.id;
        this.clearSearch();
        this.setEntity.emit();
    }
}
