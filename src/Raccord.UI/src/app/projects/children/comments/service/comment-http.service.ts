import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AppSettings } from '../../../../app.settings';
import { Comment } from '../model/comment.model';
import { PostComment } from '../model/post-comment.model';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';

@Injectable()
export class CommentHttpService extends BaseProjectHttpService {

    constructor(protected _http: Http) { 
        super(_http, 'comments');
    }

    getAll(authProjectId: number, parentProjectId?: number, parentCommentId?: number): Promise<Comment[]> {

        var uri = `${this.getUri(authProjectId)}?parentProjectId=${parentProjectId}&parentCommentId=${parentCommentId}`;

        return this.doGetArray(uri);
    }

    get(authProjectId: number, id: number): Promise<Comment> {

        var uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    post(authProjectId: number, comment: PostComment): Promise<number> {
        var uri = this.getUri(authProjectId);

        return this.doPost(comment, uri);
    }

    delete(authProjectId: number, id: Number): Promise<any> {
        var uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }
}
