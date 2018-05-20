import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../../app.settings';
import { Comment } from '../model/comment.model';
import { PostComment } from '../model/post-comment.model';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';

@Injectable()
export class CommentHttpService extends BaseProjectHttpService {

    constructor(protected _http: HttpClient) {
        super(_http, 'comments');
    }

    public getAll(
        authProjectId: number,
        parentProjectId?: number,
        parentCommentId?: number
    ): Promise<Comment[] | void> {

        let uri =
            `${this.getUri(authProjectId)}` +
                `?parentProjectId=${parentProjectId}` +
                `&parentCommentId=${parentCommentId}`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<Comment | void> {

        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public post(authProjectId: number, comment: PostComment): Promise<number> {
        let uri = this.getUri(authProjectId);

        return this.doPost(comment, uri);
    }

    public delete(authProjectId: number, id: Number): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }
}
