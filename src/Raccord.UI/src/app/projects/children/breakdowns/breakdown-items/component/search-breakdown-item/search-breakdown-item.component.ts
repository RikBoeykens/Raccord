import { Component, Input } from '@angular/core';
import { BreakdownItem } from '../../model/breakdown-item.model';
import { BreakdownItemHttpService } from '../../service/breakdown-item-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';

@Component({
    selector: 'search-breakdown-item',
    templateUrl: 'search-breakdown-item.component.html'
})
export class SearchBreakdownItemComponent{

    @Input() searchBreakdownItem: BreakdownItem;
    @Input() typeId: number;
    searchResults: BreakdownItem[] = [];

    constructor(
        private _breakdownItemHttpService: BreakdownItemHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    clearSearch(){
        this.searchResults = [];
    }

    doSearch(){
        this.searchBreakdownItem.id = 0;
        if(!this.searchBreakdownItem.name || this.searchBreakdownItem.name ===''){
            this.clearSearch();
            return;
        }

        let loadingId = this._loadingService.startLoading();
        
        this._breakdownItemHttpService.searchByType(this.searchBreakdownItem.name, this.typeId).then(results=>{
            if(typeof(results)=='string'){
                this._dialogService.error(results);
            }
            else{
                this.searchResults = results;
                var exactResult = this.searchResults.find(result=> result.name.toLowerCase()==this.searchBreakdownItem.name.toLowerCase());
                if(exactResult)
                    this.searchBreakdownItem.id = exactResult.id;
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }

    setResult(result: BreakdownItem){
        this.searchBreakdownItem.name = result.name;
        this.searchBreakdownItem.id = result.id;
        this.clearSearch();
    }
}