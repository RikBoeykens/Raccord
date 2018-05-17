import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { CharacterCall } from "../../../";
import { AuthService } from '../../../../../../security/service/auth.service';

@Injectable()
export class CharacterCallHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/charactercalls`;
    }

    post(characterCall: CharacterCall): Promise<any>{
        var uri = `${this._baseUri}`;

        return this.doPost(characterCall, uri);
    }
}
