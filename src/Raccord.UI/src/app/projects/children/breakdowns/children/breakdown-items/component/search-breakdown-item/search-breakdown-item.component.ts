import { Component, Input, Output, EventEmitter } from '@angular/core';
import { BreakdownItem } from '../../model/breakdown-item.model';
import { BreakdownItemHttpService } from '../../service/breakdown-item-http.service';
import { LoadingService } from '../../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../../shared/service/dialog.service';

@Component({
    selector: 'search-breakdown-item',
    templateUrl: 'search-breakdown-item.component.html'
})
export class SearchBreakdownItemComponent {

    @Output() public setItem = new EventEmitter();
    @Input() public searchBreakdownItem: BreakdownItem;
    @Input() public excludedItems: BreakdownItem[] = [];
    @Input() public typeId: number;
    @Input() public breakdownId: number;
    public searchResults: BreakdownItem[] = [];

    constructor(
        private _breakdownItemHttpService: BreakdownItemHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ) {
    }

    public clearSearch() {
        this.searchResults = [];
    }

    public doSearch() {
        this.searchBreakdownItem.id = 0;
        if (!this.searchBreakdownItem.name || this.searchBreakdownItem.name === '') {
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();

        this._breakdownItemHttpService.searchByType({
            searchText: this.searchBreakdownItem.name,
            typeID: this.typeId,
            breakdownID: this.breakdownId,
            excludeIDs: this.excludedItems.map((item: BreakdownItem) => item.id)
        }).then((results) => {
            if (typeof(results) === 'string') {
                this._dialogService.error(results);
            } else {
                this.searchResults = results;
                let exactResult = this.searchResults.find((result) =>
                    result.name.toLowerCase() === this.searchBreakdownItem.name.toLowerCase());
                if (exactResult) {
                    this.searchBreakdownItem.id = exactResult.id;
                }
            }
        }).catch()
        .then(() => this._loadingService.endLoading(loadingId));
    }

    public setResult(result: BreakdownItem) {
        this.searchBreakdownItem.name = result.name;
        this.searchBreakdownItem.id = result.id;
        this.clearSearch();
        this.setItem.emit();
    }
}
