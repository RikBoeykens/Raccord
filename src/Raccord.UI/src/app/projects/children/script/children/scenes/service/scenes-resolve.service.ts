import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SceneHttpService } from './scene-http.service';
import { SceneSummary } from '../../../../../../shared/children/scenes';
import { SceneFilterRequest } from '../model/scene-filter-request.model';
import { PageRequest, PagedData } from '../../../../../../shared/children/paging';
import { AppSettings } from '../../../../../../app.settings';

@Injectable()
export class ScenesResolve implements Resolve<PagedData<SceneSummary>> {

    constructor(
        private _sceneHttpService: SceneHttpService,
    ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['projectId'];
        const sceneFilterRequest = new SceneFilterRequest();
        sceneFilterRequest.projectID = id;
        const paginationRequest = new PageRequest({
            page: 1,
            pageSize: AppSettings.DEFAULT_PAGE_SIZE,
            full: false
        });
        return this._sceneHttpService.filter(
            sceneFilterRequest,
            paginationRequest
        ).then((data: PagedData<SceneSummary>) => data);
    }
}
