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

@Injectable()
export class ScheduleSceneHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/schedulescenes`;
    }

    public getScenes(id): Promise<ScheduleSceneScene[]> {

        let uri = `${this._baseUri}/${id}/day`;

        return this.doGetArray(uri);
    }

    public getDays(id): Promise<ScheduleSceneDay[]> {

        let uri = `${this._baseUri}/${id}/scene`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullScheduleScene>{

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public post(scheduleScene: ScheduleScene): Promise<number> {
        let uri = this._baseUri;

        return this.doPost(scheduleScene, uri);
    }

    public delete(id: Number): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    public sort(id: number, sortIds: number[]): Promise<any>{
        let uri = `${this._baseUri}/sort`;

        let sortOrder = new SortOrder({parentId: id, sortIds});

        return this.doSort(sortOrder, uri);
    }
}
