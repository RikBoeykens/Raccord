import { BaseComment } from "./base-comment.model";
import { UserProfile } from "../../../../profile/model/user-profile.model";

export class PostComment extends BaseComment{
    projectID?: number;
    commentID?: number;

    constructor(obj?: {
                        id: number,
                        text: string,
                        projectID?: number,
                        commentID?: number
                    }){
        super(obj);
        if(obj){
            this.projectID = obj.projectID;
            this.commentID = obj.commentID;
        }
    }
}