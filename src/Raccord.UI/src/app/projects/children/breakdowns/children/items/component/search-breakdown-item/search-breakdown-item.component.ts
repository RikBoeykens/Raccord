import { Component, Input, Output, EventEmitter } from '@angular/core';
import { SearchEngineHttpService } from '../..';
import { BreakdownItem } from '../../model/breakdown-item.model';
import { BreakdownItemHttpService } from '../../service/breakdown-item-http.service';
import { LoadingWrapperService } from '../../../../../../../shared/service/loading-wrapper.service';
import { SearchBreakdownItemRequest } from '../../model/search-breakdown-item-request.model';

@Component({
  selector: 'search-breakdown-item',
  templateUrl: 'search-breakdown-item.component.html',
})
export class SearchBreakdownItemComponent {
  @Output() public onSelect: EventEmitter<BreakdownItem> = new EventEmitter();
  @Input() public projectId: number;
  @Input() public excludedItems: BreakdownItem[] = [];
  @Input() public typeId: number;
  @Input() public breakdownId: number;
  public searchText: string;
  public filteredResults: BreakdownItem[] = [];

  constructor(
    private _breakdownItemHttpService: BreakdownItemHttpService,
    private _loadingWrapperService: LoadingWrapperService,
  ) {}

  public search() {
    if (this.searchText && this.searchText !== '') {
      this._loadingWrapperService.Load(
        this._breakdownItemHttpService.searchByType(new SearchBreakdownItemRequest({
          searchText: this.searchText,
          typeID: this.typeId,
          breakdownID: this.breakdownId,
          excludeIDs: this.excludedItems.map((item: BreakdownItem) => item.id)
        })),
        (data: BreakdownItem[]) => {
          if (data) {
            this.filteredResults = data;
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
