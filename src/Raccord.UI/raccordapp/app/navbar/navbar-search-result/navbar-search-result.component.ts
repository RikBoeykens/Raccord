import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { SearchResult } from '../../search-engine/model/search-result.model';
import { SearchType } from '../../shared/enums/search-type.enum';

@Component({
    selector: 'raccord-navbar-search-result',
    templateUrl: 'navbar-search-result.component.html',
})
export class NavbarSearchResultComponent {
    @Output() resetSearchBar = new EventEmitter();
    @Input() result: SearchResult;
    @Input() searchText: string;
    
    constructor(
        private router: Router
    ){
    }

    navigateToResult(){
        if(this.result.type==SearchType.project)
            this.router.navigate(['projects', this.result.routeIDs[0]]);
        if(this.result.type==SearchType.scene)
            this.router.navigate(['projects', this.result.routeIDs[0], 'scenes', this.result.routeIDs[1]]);
        if(this.result.type==SearchType.location)
            this.router.navigate(['projects', this.result.routeIDs[0], 'locations', this.result.routeIDs[1]]);
        this.resetSearchBar.emit();
    }
}