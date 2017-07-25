import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { CallsheetCharacterCharacter } from "../../../";

@Injectable()
export class CallsheetCharacterHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/callsheetcharacters`;
    }

    getCharacters(callsheetId: number): Promise<CallsheetCharacterCharacter[]>{
        var uri = `${this._baseUri}/${callsheetId}/characters`;

        return this.doGetArray(uri);
    }

    setCharacters(callsheetId: number, projectId: number): Promise<any>{
        var uri = `${this._baseUri}/${projectId}/${callsheetId}/setcharacters`;

        return this.doPost(null, uri);
    }
}
