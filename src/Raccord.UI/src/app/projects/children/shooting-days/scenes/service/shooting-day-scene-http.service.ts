import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { ShootingDaySceneScene } from "../model/shooting-day-scene-scene.model";
import { ShootingDaySceneDay } from "../model/shooting-day-scene-day.model";
import { ShootingDayScene } from "../model/shooting-day-scene.model";

@Injectable()
export class ShootingDaySceneHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/shootingdayscenes`;
    }

    getScenes(id): Promise<ShootingDaySceneScene[]> {

        var uri = `${this._baseUri}/${id}/day`;

        return this.doGetArray(uri);
    }

    getDays(id): Promise<ShootingDaySceneDay[]> {

        var uri = `${this._baseUri}/${id}/scene`;

        return this.doGetArray(uri);
    }

    post(shootingDayScene: ShootingDayScene): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(shootingDayScene, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}