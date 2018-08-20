import { Component, OnInit } from '@angular/core';
import { SearchTypeResult, SearchRequest, SearchResult } from '../../../shared/children/search';
import { SearchEngineHttpService } from '../../service/search-engine-http.service';
import { LoadingWrapperService, EntityType, RouteHelpers } from '../../../shared';

@Component({
  selector: 'search-dashboard',
  templateUrl: 'search-dashboard.component.html'
})
export class SearchDashboardComponent {
  public searchText: string;
  public searchTypeResults: SearchTypeResult[];
  public showResults: boolean = false;

  constructor(
    private _searchEngineHttpService: SearchEngineHttpService,
    private _loadingWrapperService: LoadingWrapperService
  ) {
  }

  public clearSearchBar() {
    this.searchText = '';
    this.searchTypeResults = [];
    this.showResults = false;
  }

  public doSearch() {
    if (this.searchText === '') {
      this.clearSearchBar();
      return;
    }

    this._loadingWrapperService.Load(
      this._searchEngineHttpService.search(new SearchRequest({
        searchText: this.searchText,
        includeTypes: [],
        excludeTypes: [
          EntityType.sceneIntro,
          EntityType.timeOfDay,
          EntityType.user,
          EntityType.userInvitation
        ],
        excludeTypeIDs: []
      })),
      (data: SearchTypeResult[]) => {
        this.searchTypeResults = data.filter((typeResult: SearchTypeResult) =>
          typeResult.count > 0);
        this.showResults = true;
      }
    );
  }

  public getSearchResultLink(result: SearchResult) {
    return RouteHelpers.getRouteArray(result.routeInfo);
  }
}
