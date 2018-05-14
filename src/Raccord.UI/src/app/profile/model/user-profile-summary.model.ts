import { BaseModel } from '../../shared/model/base.model';

export class UserProfileSummary extends BaseModel {
    public id: string;
    public firstName: string;
    public lastName: string;
    public hasImage: boolean;

    constructor(obj?: {
                        id: string,
                        firstName: string,
                        lastName: string,
                        hasImage: boolean
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.firstName = obj.firstName;
            this.lastName = obj.lastName;
            this.hasImage = obj.hasImage;
        }
    }
}
