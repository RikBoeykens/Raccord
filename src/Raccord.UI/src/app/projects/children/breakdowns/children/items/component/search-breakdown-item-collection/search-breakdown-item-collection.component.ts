import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { BreakdownItem } from '../../model/breakdown-item.model';
import { SelectedBreakdown } from '../../../../model/selected-breakdown.model';

@Component({
    selector: 'search-breakdown-item-collection',
    templateUrl: 'search-breakdown-item-collection.component.html'
})
export class SearchBreakdownItemCollectionComponent {

    @Output() public onChange = new EventEmitter();
    @Input() public projectId: number;
    @Input() public breakdown: SelectedBreakdown;
    public selectedType: number;
    public entities: BreakdownItem[] = [];

    public addEntity(searchEntity: BreakdownItem) {
        this.entities.push(searchEntity);
        this.onChange.emit(this.entities);
    }

    public removeEntity(toRemove: BreakdownItem) {
        this.entities = this.entities.filter((entity) => entity.id !== toRemove.id);
        this.onChange.emit(this.entities);
    }
}
