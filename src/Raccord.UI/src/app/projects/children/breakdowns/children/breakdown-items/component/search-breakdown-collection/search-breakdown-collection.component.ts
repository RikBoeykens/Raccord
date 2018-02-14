import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { BreakdownType } from '../../../breakdown-types/model/breakdown-type.model';
import { BreakdownItem } from '../../model/breakdown-item.model';
import { FullBreakdown } from '../../../../model/full-breakdown.model';

@Component({
    selector: 'search-breakdown-collection',
    templateUrl: 'search-breakdown-collection.component.html'
})
export class SearchBreakdownCollectionComponent implements OnInit {

    @Output() public onChange = new EventEmitter();
    @Input() public projectID: number;
    @Input() public breakdown: FullBreakdown;
    public selectedType: number;
    public searchEntity: BreakdownItem = new BreakdownItem();
    public entities: BreakdownItem[] = [];

    public ngOnInit () {
        this.resetSearchEntity();
        if (this.breakdown.types.length) {
            this.selectedType = this.breakdown.types[0].id;
        }
    }

    public addEntity() {
        this.entities.push(this.searchEntity);
        this.resetSearchEntity();
        this.onChange.emit(this.entities);
    }

    public removeEntity(toRemove: BreakdownItem) {
        this.entities = this.entities.filter((entity) => entity.id !== toRemove.id);
        this.onChange.emit(this.entities);
    }

    private resetSearchEntity() {
        this.searchEntity = new BreakdownItem();
    }
}
