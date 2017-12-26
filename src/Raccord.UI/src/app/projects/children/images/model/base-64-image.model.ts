import { BaseModel } from '../../../../shared/model/base.model';

export class Base64Image extends BaseModel{
    content: string;
    hasContent: boolean;

    constructor(obj?: {
                        content: string, 
                        hasContent: boolean
                    }) {
        super();
        if (obj) {
            this.content = obj.content;
            this.hasContent = obj.hasContent;
        }
    }
}