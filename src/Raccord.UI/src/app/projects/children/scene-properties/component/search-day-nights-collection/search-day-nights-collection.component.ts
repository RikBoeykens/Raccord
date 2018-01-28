import { Component, Input, Output, EventEmitter } from '@angular/core';
import { DayNight } from '../../model/day-night.model';
import { SearchResult } from '../../../../../search/model/search-result.model';

@Component({
    selector: 'search-day-nights-collection',
    templateUrl: 'search-day-nights-collection.component.html'
})
export class SearchDayNightsCollectionComponent{

    @Output() public onChange = new EventEmitter();
    @Input() public projectID: number;
    public searchEntity: DayNight = new DayNight();
    public entities: DayNight[] = [];


    public ngOnInit () {
        this.resetSearchEntity();
    }

    public addEntity() {
        this.entities.push(this.searchEntity);
        this.resetSearchEntity();
        this.onChange.emit(this.entities);
    }

    public removeEntity(toRemove: DayNight) {
        this.entities = this.entities.filter((entity) => entity.id !== toRemove.id);
        this.onChange.emit(this.entities);
    }

    private resetSearchEntity() {
        this.searchEntity = new DayNight();
        this.searchEntity.projectId = this.projectID;
    }
}
