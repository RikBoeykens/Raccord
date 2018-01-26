import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ScriptLocation } from '../../model/script-location.model';
import { SearchResult } from '../../../../../search/model/search-result.model';

@Component({
    selector: 'search-script-locations-collection',
    templateUrl: 'search-script-locations-collection.component.html'
})
export class SearchScriptLocationsCollectionComponent{

    @Output() public onChange = new EventEmitter();
    @Input() public projectID: number;
    public searchEntity: ScriptLocation = new ScriptLocation();
    public entities: ScriptLocation[] = [];


    public ngOnInit () {
        this.resetSearchEntity();
    }

    public addEntity() {
        this.entities.push(this.searchEntity);
        this.resetSearchEntity();
        this.onChange.emit(this.entities);
    }

    public removeEntity(toRemove: ScriptLocation) {
        this.entities = this.entities.filter((entity) => entity.id !== toRemove.id);
        this.onChange.emit(this.entities);
    }

    private resetSearchEntity() {
        this.searchEntity = new ScriptLocation();
        this.searchEntity.projectID = this.projectID;
    }
}
