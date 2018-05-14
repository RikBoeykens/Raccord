import { BaseModel } from '../../../shared/model/base.model';
import { UserSummary } from '../../users/model/user-summary.model';
import { ProjectUserUser } from './project-user-user.model';

export class LinkedProjectUserUser extends ProjectUserUser {
    public linkID: number;

    constructor(obj?: {
        id: number,
        user: UserSummary,
        linkID: number
    }){
        super(obj);
        if (obj) {
            this.linkID = obj.linkID;
        }
    }
}