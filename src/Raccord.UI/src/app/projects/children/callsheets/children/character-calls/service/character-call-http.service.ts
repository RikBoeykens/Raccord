import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { CharacterCall } from "../../../";

@Injectable()
export class CharacterCallHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/charactercalls`;
    }

    post(characterCall: CharacterCall): Promise<any>{
        var uri = `${this._baseUri}`;

        return this.doPost(characterCall, uri);
    }
}
