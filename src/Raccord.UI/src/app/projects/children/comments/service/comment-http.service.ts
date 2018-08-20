import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';
import { ParentCommentType } from '../../../../shared';
import { PostComment, Comment } from '../../..';

@Injectable()
export class CommentHttpService extends BaseProjectHttpService {

    constructor(protected _http: HttpClient) {
        super(_http, 'comments');
    }

    public getAll(
        authProjectId: number,
        parentId: number,
        parentType: ParentCommentType
    ): Promise<Comment[] | void> {

        const uri =
            `${this.getUri(authProjectId)}` +
                `?parentID=${parentId}` +
                `&parentType=${parentType}`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<Comment | void> {

        const uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public post(authProjectId: number, comment: PostComment): Promise<number> {
        const uri = this.getUri(authProjectId);

        return this.doPost(comment, uri);
    }

    public delete(authProjectId: number, id: number): Promise<any> {
        const uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }
}
