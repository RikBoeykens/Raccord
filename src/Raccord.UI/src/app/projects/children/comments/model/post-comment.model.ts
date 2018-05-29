import { BaseComment } from "./base-comment.model";
import { UserProfile } from "../../../../profile/model/user-profile.model";
import { ParentCommentType } from "../../../../shared/enums/parent-comment-type.enum";

export class PostComment extends BaseComment{
    public parentType: ParentCommentType;
    public parentID: number;

    constructor(obj?: {
                        id: number,
                        text: string,
                        parentType: ParentCommentType,
                        parentID: number
                    }){
        super(obj);
        if(obj){
            this.parentType = obj.parentType;
            this.parentID = obj.parentID;
        }
    }
}