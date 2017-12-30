import { BaseModel } from './base.model';

export class Base64Image extends BaseModel{
    fileName: string;
    content: string;
    hasContent: boolean;

    constructor(obj?: {
                        fileName: string,
                        content: string, 
                        hasContent: boolean
                    }) {
        super();
        if (obj) {
            this.fileName = obj.fileName;
            this.content = obj.content;
            this.hasContent = obj.hasContent;
        }
    }
}