import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Location } from '../../model/location.model';
import { SearchResult } from '../../../../../search/model/search-result.model';

@Component({
    selector: 'search-locations-collection',
    templateUrl: 'search-locations-collection.component.html'
})
export class SearchLocationsCollectionComponent{

    @Output() public onChange = new EventEmitter();
    @Input() public projectID: number;
    public searchEntity: Location = new Location();
    public entities: Location[] = [];


    public ngOnInit () {
        this.resetSearchEntity();
    }

    public addEntity() {
        this.entities.push(this.searchEntity);
        this.resetSearchEntity();
        this.onChange.emit(this.entities);
    }

    public removeEntity(toRemove: Location) {
        this.entities = this.entities.filter((entity) => entity.id !== toRemove.id);
        this.onChange.emit(this.entities);
    }

    private resetSearchEntity() {
        this.searchEntity = new Location();
        this.searchEntity.projectId = this.projectID;
    }
}
