import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SceneSummary } from '../../../../../../../shared/children/scenes';
import { PagedData, PageRequest } from '../../../../../../../shared/children/paging';
import { SceneHttpService } from '../../service/scene-http.service';
import { SceneFilterRequest } from '../../model/scene-filter-request.model';
import { LoadingWrapperService, RouteSettings } from '../../../../../../../shared';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { AppSettings } from '../../../../../../../app.settings';
import { SelectedBreakdown } from '../../../../../breakdowns/model/selected-breakdown.model';

@Component({
  selector: 'scenes-list',
  templateUrl: 'scenes-list.component.html'
})
export class ScenesListComponent implements OnInit {
  public pagedScenes: PagedData<SceneSummary>;
  public project: ProjectSummary;
  public selectedBreakdown: SelectedBreakdown;
  public sceneFilterRequest: SceneFilterRequest = new SceneFilterRequest();
  public showFilter: boolean = false;

  constructor(
      private _route: ActivatedRoute,
      private _sceneHttpService: SceneHttpService,
      private _loadingWrapperService: LoadingWrapperService
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        scenes: PagedData<SceneSummary>,
        selectedBreakdown: SelectedBreakdown
      }) => {
          this.pagedScenes = data.scenes;
          this.selectedBreakdown = data.selectedBreakdown;
      });
      this.project = ProjectHelpers.getCurrentProject();
      this.sceneFilterRequest.projectID = this.project.id;
  }

  public doShowFilter() {
    this.showFilter = true;
  }

  public doHideFilter() {
    this.showFilter = false;
  }

  public filterScenes() {
    this._loadingWrapperService.Load(
      this._sceneHttpService.filter(
        this.sceneFilterRequest,
        new PageRequest({
          page: 1,
          pageSize: AppSettings.DEFAULT_PAGE_SIZE,
          full: false
      })),
      (data: PagedData<SceneSummary>) => {
        this.pagedScenes.pageInfo = data.pageInfo;
        this.pagedScenes.data = data.data;
      }
    );
  }

  public getMoreScenes() {
    this._loadingWrapperService.Load(
      this._sceneHttpService.filter(
        this.sceneFilterRequest,
        new PageRequest({
        page: this.pagedScenes.pageInfo.page + 1,
        pageSize: this.pagedScenes.pageInfo.pageSize,
        full: false
      })),
      (data: PagedData<SceneSummary>) => {
        this.pagedScenes.pageInfo = data.pageInfo;
        this.pagedScenes.data.push.apply(this.pagedScenes.data, data.data);
      }
    );
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPT}`;
  }
}
