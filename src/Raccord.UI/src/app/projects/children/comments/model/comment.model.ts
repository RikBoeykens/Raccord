import { BaseComment } from "./base-comment.model";
import { UserProfileSummary } from "../../../../profile/model/user-profile-summary.model";

export class Comment extends BaseComment{
    user: UserProfileSummary;

    constructor(obj?: {
                        id: number,
                        text: string,
                        user: UserProfileSummary
                    }) {
        super(obj);
        if (obj) {
            this.user = obj.user;
        }
    }
}