import { Component, Input, Output, EventEmitter } from '@angular/core';
import { EntityType, LoadingWrapperService } from '../../../shared';
import {
  SearchResult,
  SearchRequest,
  SearchTypeResult,
  SearchEntity,
  ExcludeTypeIDs
} from '../../../shared/children/search';
import { SearchEngineHttpService } from '../..';

@Component({
  selector: 'search-entity',
  templateUrl: 'search-entity.component.html',
})
export class SearchEntityComponent {
  @Input() public entityType: EntityType;
  @Input() public entityTypeName: string;
  @Output() public onSelect: EventEmitter<SearchResult> = new EventEmitter();
  @Input() public projectId: number;
  @Input() public excludeEntities: SearchEntity[] =  [];
  public searchText: string;
  public filteredResults: SearchResult[] = [];

  constructor(
    private _searchEngineService: SearchEngineHttpService,
    private _loadingWrapperService: LoadingWrapperService,
  ) {}

  public search() {
    if (this.searchText && this.searchText !== '') {
      this._loadingWrapperService.Load(
        this._searchEngineService.search(new SearchRequest({
          searchText: this.searchText,
          projectId: this.projectId,
          includeTypes: [this.entityType],
          excludeTypes: [],
          excludeTypeIDs: [new ExcludeTypeIDs({
            type: this.entityType,
            ids: this.excludeEntities.map((entity: SearchEntity) => entity.id)
          })]
        })),
        (data: SearchTypeResult[]) => {
          if (data && data.length && data[0].results) {
            this.filteredResults = data[0].results;
          }
        }
      );
    } else {
      this.filteredResults = [];
    }
  }

  public onSelectionChanged(event$) {
    this.onSelect.next(event$.option.value);
  }

  public clearSearch(value) {
    this.searchText = '';
    this.filteredResults = [];
    return '';
  }
}
