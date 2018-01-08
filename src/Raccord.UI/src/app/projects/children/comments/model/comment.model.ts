import { BaseComment } from "./base-comment.model";
import { UserProfileSummary } from "../../../../profile/model/user-profile-summary.model";

export class Comment extends BaseComment{
    user: UserProfileSummary;
    comments: Comment[];

    constructor(obj?: {
                        id: number,
                        text: string,
                        user: UserProfileSummary,
                        comments: Comment[]
                    }){
        super(obj);
        if(obj){
            this.user = obj.user;
            this.comments = obj.comments;
        }
    }
}