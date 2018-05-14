import { Component, Input, Output, EventEmitter } from '@angular/core';
import { IntExt } from '../../model/int-ext.model';
import { SearchResult } from '../../../../../search/model/search-result.model';

@Component({
    selector: 'search-int-exts-collection',
    templateUrl: 'search-int-exts-collection.component.html'
})
export class SearchIntExtsCollectionComponent{

    @Output() public onChange = new EventEmitter();
    @Input() public projectID: number;
    public searchEntity: IntExt = new IntExt();
    public entities: IntExt[] = [];


    public ngOnInit () {
        this.resetSearchEntity();
    }

    public addEntity() {
        this.entities.push(this.searchEntity);
        this.resetSearchEntity();
        this.onChange.emit(this.entities);
    }

    public removeEntity(toRemove: IntExt) {
        this.entities = this.entities.filter((entity) => entity.id !== toRemove.id);
        this.onChange.emit(this.entities);
    }

    private resetSearchEntity() {
        this.searchEntity = new IntExt();
        this.searchEntity.projectId = this.projectID;
    }
}
