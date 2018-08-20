import { BaseComment } from './base-comment.model';
import { UserProfileSummary } from '../../../../shared/children/users';

export class Comment extends BaseComment {
    public user: UserProfileSummary;
    public commentCount: number;
    public comments: Comment[];

    constructor(obj?: {
                        id: number,
                        text: string,
                        user: UserProfileSummary,
                        commentCount: number;
                        comments: Comment[]
                    }) {
        super(obj);
        if (obj) {
            this.user = obj.user;
            this.commentCount = obj.commentCount;
            this.comments = obj.comments;
        }
    }
}
