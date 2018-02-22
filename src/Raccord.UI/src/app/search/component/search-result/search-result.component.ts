import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { SearchResult } from '../../model/search-result.model';
import { EntityType } from '../../../shared/enums/entity-type.enum';

@Component({
    selector: 'raccord-search-result',
    templateUrl: 'search-result.component.html',
})
export class SearchResultComponent {
    @Output() public resetSearchBar = new EventEmitter();
    @Input() public result: SearchResult;
    @Input() public searchText: string;

    constructor(
        private router: Router
    ) {
    }

    public navigateToResult() {
        if (this.result.type === EntityType.project) {
            this.router.navigate(['projects', this.result.routeIDs[0]]);
        }
        if (this.result.type === EntityType.scene) {
            this.router.navigate(
                ['projects', this.result.routeIDs[0], 'scenes', this.result.routeIDs[1]]
            );
        }
        if (this.result.type === EntityType.scriptLocation) {
            this.router.navigate(
                ['projects', this.result.routeIDs[0], 'scriptlocations', this.result.routeIDs[1]]
            );
        }
        if (this.result.type === EntityType.image) {
            this.router.navigate(
                ['projects', this.result.routeIDs[0], 'images', this.result.routeIDs[1]]
            );
        }
        if (this.result.type === EntityType.character) {
            this.router.navigate(
                ['projects', this.result.routeIDs[0], 'characters', this.result.routeIDs[1]]
            );
        }
        if (this.result.type === EntityType.breakdownItem) {
            this.router.navigate([
                'projects',
                this.result.routeIDs[0],
                'breakdowns',
                this.result.routeIDs[1],
                'breakdownItems',
                this.result.routeIDs[2]
            ]);
        }
        if (this.result.type === EntityType.location) {
            this.router.navigate(
                ['projects', this.result.routeIDs[0], 'locations', this.result.routeIDs[1]]
            );
        }
        if (this.result.type === EntityType.slate) {
            this.router.navigate(
                ['projects', this.result.routeIDs[0], 'slates', this.result.routeIDs[1]]
            );
        }
        if (this.result.type === EntityType.crewMember) {
            this.router.navigate(['projects', this.result.routeIDs[0], 'crew']);
        }
        if (this.result.type === EntityType.castMember) {
            this.router.navigate(
                ['projects', this.result.routeIDs[0], 'cast', this.result.routeIDs[1]]
            );
        }
        this.resetSearchBar.emit();
    }
}
