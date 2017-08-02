import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { AppSettings } from '../../../app.settings';
import { FullUser } from '../model/full-user.model';
import { CreateUser } from '../model/create-user.model';
import { UserSummary } from '../model/user-summary.model';
import { User } from '../model/user.model';

@Injectable()
export class AdminUserHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/users`;
    }

    getAll(): Promise<UserSummary[]> {

        var uri = this._baseUri;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullUser>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<UserSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    add(user: CreateUser): Promise<Number> {
        var uri = `${this._baseUri}/create`;

        return this.doPost(user, uri);
    }

    update(user: User): Promise<Number> {
        var uri = `${this._baseUri}/update`;

        return this.doPost(user, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
