import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullScheduleScene } from '../model/full-schedule-scene.model';
import { ScheduleSceneDay } from '../model/schedule-scene-day.model';
import { ScheduleSceneScene } from '../model/schedule-scene-scene.model';
import { ScheduleScene } from '../model/schedule-scene.model';
import { JsonResponse } from '../../../../../shared/model/json-response.model';
import { SortOrder } from '../../../../../shared/model/sort-order.model';
import { BaseProjectHttpService } from '../../../../shared/service/base-project-http.service';
import { AuthService } from '../../../../../security/service/auth.service';

@Injectable()
export class ScheduleSceneHttpService extends BaseProjectHttpService {

    constructor(protected _http: Http, protected _authService: AuthService) {
        super(_http, _authService, 'schedulescenes');
    }

    public getScenes(authProjectId: number, scheduleDayId: number): Promise<ScheduleSceneScene[]> {

        let uri = `${this.getUri(authProjectId)}/${scheduleDayId}/day`;

        return this.doGetArray(uri);
    }

    public getDays(authProjectId: number, sceneId: number): Promise<ScheduleSceneDay[]> {

        let uri = `${this.getUri(authProjectId)}/${sceneId}/scene`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullScheduleScene> {

        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public post(authProjectId: number, scheduleScene: ScheduleScene): Promise<number> {
        let uri = this.getUri(authProjectId);

        return this.doPost(scheduleScene, uri);
    }

    public delete(authProjectId: number, id: Number): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }

    public sort(authProjectId: number, id: number, sortIds: number[]): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/sort`;

        let sortOrder = new SortOrder({parentId: id, sortIds});

        return this.doSort(sortOrder, uri);
    }
}
