import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { SearchEntity } from '../../model/search-entity.model';
import { EntityType } from '../../../shared/enums/entity-type.enum';

@Component({
    selector: 'search-entities-collection',
    templateUrl: 'search-entities-collection.component.html'
})
export class SearchEntitiesCollectionComponent implements OnInit {

    @Output() public onChange = new EventEmitter();
    @Input() public projectID: number;
    @Input() public entityType: EntityType;
    @Input() public entityTypeName: string;
    public searchEntity: SearchEntity = new SearchEntity();
    public entities: SearchEntity[] = [];

    public ngOnInit () {
        this.resetSearchEntity();
    }

    public addEntity() {
        this.entities.push(this.searchEntity);
        this.resetSearchEntity();
        this.onChange.emit(this.entities);
    }

    public removeEntity(toRemove: SearchEntity) {
        this.entities = this.entities.filter((entity) => entity.id !== toRemove.id);
        this.onChange.emit(this.entities);
    }

    private resetSearchEntity() {
        this.searchEntity = new SearchEntity();
    }
}
