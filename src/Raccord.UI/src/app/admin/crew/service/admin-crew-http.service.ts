import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from "../../../shared/service/base-http.service";
import { CrewUserProject } from "../model/crew-user-project.model";
import { CrewUserUser } from "../model/crew-user-user.model";
import { FullCrewUser } from "../model/full-crew-user.model";
import { CrewUser } from "../model/crew-user.model";

@Injectable()
export class AdminCrewHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/crew`;
    }

    getProjects(id): Promise<CrewUserProject[]> {

        var uri = `${this._baseUri}/${id}/projects`;
        console.log("getting projects");
        return this.doGetArray(uri);
    }

    getUsers(id): Promise<CrewUserUser[]> {

        var uri = `${this._baseUri}/${id}/users`;
        console.log("getting users");
        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullCrewUser>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    post(crewUser: CrewUser): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(crewUser, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}