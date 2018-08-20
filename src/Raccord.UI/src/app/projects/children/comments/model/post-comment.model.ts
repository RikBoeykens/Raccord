import { BaseComment } from './base-comment.model';
import { ParentCommentType } from '../../../../shared';

export class PostComment extends BaseComment {
    public parentType: ParentCommentType;
    public parentID: number;

    constructor(obj?: {
                        id: number,
                        text: string,
                        parentType: ParentCommentType,
                        parentID: number
                    }) {
        super(obj);
        if (obj) {
            this.parentType = obj.parentType;
            this.parentID = obj.parentID;
        }
    }
}
