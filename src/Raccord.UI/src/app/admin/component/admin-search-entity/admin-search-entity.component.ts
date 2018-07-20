import { Component, Input, Output, EventEmitter } from '@angular/core';
import { SearchResult, SearchRequest, SearchTypeResult } from '../../../shared/children/search';
import { EntityType } from '../../../shared';
import { LoadingWrapperService } from '../../../shared/service/loading-wrapper.service';
// tslint:disable-next-line:max-line-length
import { AdminSearchEngineService } from '../../children/search/service/admin-search-engine.service';

@Component({
  selector: 'admin-search-entity',
  templateUrl: 'admin-search-entity.component.html',
})
export class AdminSearchEntityComponent {
  @Input() public entityType: EntityType;
  @Output() public onSelect: EventEmitter<SearchResult> = new EventEmitter();
  @Input() public projectId?: number;
  public searchText: string;
  public filteredResults: SearchResult[] = [];

  constructor(
    private _adminSearchEngineService: AdminSearchEngineService,
    private _loadingWrapperService: LoadingWrapperService,
  ) {}

  public search() {
    if (this.searchText && this.searchText !== '') {
      this._loadingWrapperService.Load(
        this._adminSearchEngineService.search(new SearchRequest({
          searchText: this.searchText,
          projectId: this.projectId,
          includeTypes: [this.entityType],
          excludeTypes: [],
          excludeTypeIDs: []
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
