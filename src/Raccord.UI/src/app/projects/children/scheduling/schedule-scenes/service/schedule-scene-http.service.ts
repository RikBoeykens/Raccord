import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullScheduleScene } from '../model/full-schedule-scene.model';
import { ScheduleSceneDay } from '../model/schedule-scene-day.model';
import { ScheduleSceneScene } from '../model/schedule-scene-scene.model';
import { ScheduleScene } from '../model/schedule-scene.model';
import { JsonResponse } from '../../../../../shared/model/json-response.model';

@Injectable()
export class ScheduleSceneHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/schedulescenes`;
    }

    getScenes(id): Promise<ScheduleSceneScene[]> {

        var uri = `${this._baseUri}/${id}/day`;

        return this.doGetArray(uri);
    }

    getDays(id): Promise<ScheduleSceneDay[]> {

        var uri = `${this._baseUri}/${id}/scene`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullScheduleScene>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    post(scheduleScene: ScheduleScene): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(scheduleScene, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}