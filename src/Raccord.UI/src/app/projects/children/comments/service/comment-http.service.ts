import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { Comment } from '../model/comment.model';
import { PostComment } from '../model/post-comment.model';

@Injectable()
export class CommentHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/comments`;
    }

    getAll(projectId?: number, commentId?: number): Promise<Comment[]> {

        var uri = `${this._baseUri}?projectId=${projectId}&commentId=${commentId}`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<Comment> {

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    post(comment: PostComment): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(comment, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
