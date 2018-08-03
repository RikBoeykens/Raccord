import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { EntityType } from '../../../shared';
import { SearchEntity } from '../../../shared/children/search';

@Component({
    selector: 'search-entities-collection',
    templateUrl: 'search-entities-collection.component.html'
})
export class SearchEntitiesCollectionComponent {

    @Output() public onChange = new EventEmitter();
    @Input() public projectId: number;
    @Input() public entityType: EntityType;
    @Input() public entityTypeName: string;
    public entities: SearchEntity[] = [];

    public addEntity(searchEntity: SearchEntity) {
        this.entities.push(searchEntity);
        this.onChange.emit(this.entities);
    }

    public removeEntity(toRemove: SearchEntity) {
        this.entities = this.entities.filter((entity) => entity.id !== toRemove.id);
        this.onChange.emit(this.entities);
    }
}
