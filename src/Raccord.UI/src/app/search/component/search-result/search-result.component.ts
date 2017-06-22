import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { SearchResult } from '../../model/search-result.model';
import { EntityType } from '../../../shared/enums/entity-type.enum';

@Component({
    selector: 'raccord-search-result',
    templateUrl: 'search-result.component.html',
})
export class SearchResultComponent {
    @Output() resetSearchBar = new EventEmitter();
    @Input() result: SearchResult;
    @Input() searchText: string;
    
    constructor(
        private router: Router
    ){
    }

    navigateToResult(){
        if(this.result.type==EntityType.project)
            this.router.navigate(['projects', this.result.routeIDs[0]]);
        if(this.result.type==EntityType.scene)
            this.router.navigate(['projects', this.result.routeIDs[0], 'scenes', this.result.routeIDs[1]]);
        if(this.result.type==EntityType.scriptLocation)
            this.router.navigate(['projects', this.result.routeIDs[0], 'scriptlocations', this.result.routeIDs[1]]);
        if(this.result.type==EntityType.image)
            this.router.navigate(['projects', this.result.routeIDs[0], 'images', this.result.routeIDs[1]]);
        if(this.result.type==EntityType.character)
            this.router.navigate(['projects', this.result.routeIDs[0], 'characters', this.result.routeIDs[1]]);
        if(this.result.type==EntityType.breakdownItem)
            this.router.navigate(['projects', this.result.routeIDs[0], 'breakdowns', 'breakdownItems', this.result.routeIDs[1]]);
        this.resetSearchBar.emit();
    }
}