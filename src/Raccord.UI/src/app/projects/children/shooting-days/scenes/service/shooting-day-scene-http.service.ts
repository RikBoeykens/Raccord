import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { ShootingDaySceneScene } from '../model/shooting-day-scene-scene.model';
import { ShootingDaySceneDay } from '../model/shooting-day-scene-day.model';
import { ShootingDayScene } from '../model/shooting-day-scene.model';
import { AuthService } from '../../../../../security/service/auth.service';

@Injectable()
export class ShootingDaySceneHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/shootingdayscenes`;
    }

    public getScenes(id): Promise<ShootingDaySceneScene[]> {

        let uri = `${this._baseUri}/${id}/day`;

        return this.doGetArray(uri);
    }

    public getDays(id): Promise<ShootingDaySceneDay[]> {

        let uri = `${this._baseUri}/${id}/scene`;

        return this.doGetArray(uri);
    }

    public post(shootingDayScene: ShootingDayScene): Promise<number> {
        let uri = this._baseUri;

        return this.doPost(shootingDayScene, uri);
    }

    public delete(id: Number): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
