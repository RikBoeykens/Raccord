import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SceneHttpService } from '../../service/scene-http.service';
import { SceneSummary } from '../../model/scene-summary.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { SceneFilterRequest } from '../../model/scene-filter-request.model';
import { BreakdownTypeSummary } from
    '../../../breakdowns/breakdown-types/model/breakdown-type-summary.model';

@Component({
    templateUrl: 'scenes-list.component.html',
})
export class ScenesListComponent implements OnInit {

    public scenes: SceneSummary[] = [];
    public project: ProjectSummary;
    public sceneFilter: SceneFilterRequest = new SceneFilterRequest();
    public breakdownTypes: BreakdownTypeSummary[];

    constructor(
        private _sceneHttpService: SceneHttpService,
        private _loadingService: LoadingService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            scenes: SceneSummary[],
            project: ProjectSummary,
            breakdownTypes: BreakdownTypeSummary[] 
        }) => {
            this.scenes = data.scenes;
            this.project = data.project;
            this.sceneFilter.projectID = this.project.id;
            this.breakdownTypes = data.breakdownTypes;
        });
    }

    public filterScenes() {
        let loadingId = this._loadingService.startLoading();
        this._sceneHttpService.filter(this.sceneFilter, null).then((pagedData) => {
            this.scenes = pagedData.data;
            this._loadingService.endLoading(loadingId);
        });
    }
}